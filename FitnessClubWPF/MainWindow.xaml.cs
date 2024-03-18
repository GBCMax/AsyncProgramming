using BusinessLogic.Business_Logic;
using System;
using System.Runtime;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection.Emit;

namespace FitnessClubWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        long[] masForFastSort, mas1ForFastSort, mas2ForFastSort;
        long[] masForBubbleSort, mas1ForBubbleSort, mas2ForBubbleSort;
        long[] masForMergeSort, mas1ForMergeSort, mas2ForMergeSort;
        private readonly RandomNumberArrayGenerator randomNumberArrayGenerator = new RandomNumberArrayGenerator();
        private readonly AsyncSort asyncSort = new AsyncSort();
        private readonly PrintMas printMas = new PrintMas();
        private readonly AsyncSortSecondMethod asyncSortSecondMethod = new AsyncSortSecondMethod();
        private readonly CheckSort checkSort = new CheckSort();
        private readonly BubbleSortWithoutBlock bubbleSortWithoutBlock = new BubbleSortWithoutBlock();
        private readonly MergeSortWithoutBlock mergeSortWithoutBlock = new MergeSortWithoutBlock();
        Stopwatch stopwatch2 = new Stopwatch();
        Stopwatch stopwatch3 = new Stopwatch();
        private string ForQSWithoutBlock = "", ForBSWithoutBlock = "", ForMSWithoutBlock;
        bool finished = false;
        List<SolidColorBrush> brushes;
        Random rnd;


        private void Show_Button_Click(object sender, RoutedEventArgs e)
        {
            Parallel.Invoke(
            () => MessageBox.Show("Асинхронная сортировка без блокировки" + Environment.NewLine + PrintStatsForQuickSort()),
            () => MessageBox.Show("Асинхронная сортировка без блокировки" + Environment.NewLine + PrintStatsForBubbleSort()),
            () => MessageBox.Show("Асинхронная сортировка" + Environment.NewLine + PrintStatsForMergeSort())
            );
            Indicator_Button.Text = "Конец программы";
        }

        private async void AsyncSort_Button_Click(object sender, RoutedEventArgs e)
        {
            Indicator_Button.Text = "Сортировка выполняется";
            {
                string statuses = "";
                CancellationTokenSource cts = new CancellationTokenSource();
                CancellationToken ct = cts.Token;
                Task[] tasks = new Task[3];
                tasks[0] = new Task(() =>
                {
                    statuses += "Quick sort started...\n\r";
                    statuses += "start QuickSort in thread " + Thread.CurrentThread.ManagedThreadId.ToString() + "and task " + Task.CurrentId.ToString() + Environment.NewLine;
                    asyncSortSecondMethod.QuickSort(mas2ForFastSort, ct);
                    statuses += "end QuickcSort in thread " + Thread.CurrentThread.ManagedThreadId.ToString() + "and task " + Task.CurrentId.ToString();
                    statuses += "Quick sort finished.\n\r";
                }, ct);

                tasks[1] = new Task(() =>
                {
                    statuses += "Bubble sort started...\n\r";
                    statuses += "start BubbleSort in thread " + Thread.CurrentThread.ManagedThreadId.ToString() + "and task " + Task.CurrentId.ToString() + Environment.NewLine;
                    bubbleSortWithoutBlock.BubbleSort(mas2ForBubbleSort, ct);
                    statuses += "end BubbleSort in thread " + Thread.CurrentThread.ManagedThreadId.ToString() + "and task " + Task.CurrentId.ToString() + Environment.NewLine;
                    statuses += "Bubble sort finished.\n\r";
                }, ct);

                tasks[2] = new Task(() =>
                {
                    statuses += "Merge sort started...\n\r";
                    statuses += "start MergeSort in thread " + Thread.CurrentThread.ManagedThreadId.ToString() + "and task " + Task.CurrentId.ToString() + Environment.NewLine;
                    mergeSortWithoutBlock.MergeSort(mas2ForMergeSort, ct);
                    statuses += "end MergeSort in thread " + Thread.CurrentThread.ManagedThreadId.ToString() + "and task " + Task.CurrentId.ToString() + Environment.NewLine;
                    statuses += "Merge sort finished.\n\r";
                }, ct);
                statuses += "метод WhenAnyWhenAll после создания задач TaskId = " + Task.CurrentId.ToString() + ", Thread = " + Thread.CurrentThread.ManagedThreadId.ToString() + Environment.NewLine;

                statuses += ShowTaskStatuses(tasks, "перед Start");

                // запускаем задачи
                foreach (var task in tasks)
                {
                    task.Start();
                }

                statuses += ShowTaskStatuses(tasks, "перед WhenAny");

                // Асинхронно дожидаемся первой завершившейся задачи
                // Метод WhenAny возвращает задачу, которая закончилась раньше других
                int firstFinished = Task.WaitAny(tasks);

                statuses += "метод WhenAnyWhenAll после создания задач TaskId = " + Task.CurrentId.ToString() + ", Thread = " + Thread.CurrentThread.ManagedThreadId.ToString() + Environment.NewLine;

                statuses += ShowTaskStatuses(tasks, "сразу после WhenAny");
                cts.Cancel();
                cts.Dispose();
                Task.Delay(100).Wait();
                statuses += ShowTaskStatuses(tasks, "чуть-чуть подождав");

                // Асинхронно дожидаемся выполнения всех оставшихся задач
                statuses += "выход из метода WhenAnyWhenAll TaskId = " + Task.CurrentId.ToString() + ", Thread = " + Thread.CurrentThread.ManagedThreadId.ToString() + Environment.NewLine;
                Indicator_Button.Text = statuses;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Generator_Button_Click(object sender, RoutedEventArgs e)
        {
            masForFastSort = randomNumberArrayGenerator.GenerateRandomNumberArray();
            mas1ForFastSort = (long[])masForFastSort.Clone();
            mas2ForFastSort = (long[])masForFastSort.Clone();
            masForBubbleSort = (long[])masForFastSort.Clone();
            mas1ForBubbleSort = (long[])masForFastSort.Clone();
            mas2ForBubbleSort = (long[])masForFastSort.Clone();
            masForMergeSort = (long[])masForFastSort.Clone();
            mas1ForMergeSort = (long[])masForFastSort.Clone();
            mas2ForMergeSort = (long[])masForFastSort.Clone();
            Indicator_Button.Text = "Массив сгенерирован";
            Show_Button.IsEnabled = true;
            AsyncSort_Button.IsEnabled = true;
            TaskSort_Button.IsEnabled = true;
        }

        private async void TaskSort_Button_Click(object sender, RoutedEventArgs e)
        {
            Indicator_Button.Text = "Сортировка выполняется";
            string statuses = "";
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;
            Task[] tasks = new Task[3];
            tasks[0] = new Task(() =>
            {
                statuses += "Quick sort started...\n\r";
                statuses += "start QuickSort in thread " + Thread.CurrentThread.ManagedThreadId.ToString() + "and task " + Task.CurrentId.ToString() + Environment.NewLine;
                asyncSortSecondMethod.QuickSort(mas1ForFastSort, ct);
                statuses += "end QuickcSort in thread " + Thread.CurrentThread.ManagedThreadId.ToString() + "and task " + Task.CurrentId.ToString();
                statuses += "Quick sort finished.\n\r";
            }, ct);

            tasks[1] = new Task(() =>
            {
                statuses += "Bubble sort started...\n\r";
                statuses += "start BubbleSort in thread " + Thread.CurrentThread.ManagedThreadId.ToString() + "and task " + Task.CurrentId.ToString() + Environment.NewLine;
                bubbleSortWithoutBlock.BubbleSort(mas1ForBubbleSort, ct);
                statuses += "end BubbleSort in thread " + Thread.CurrentThread.ManagedThreadId.ToString() + "and task " + Task.CurrentId.ToString() + Environment.NewLine;
                statuses += "Bubble sort finished.\n\r";
            }, ct);

            tasks[2] = new Task(() =>
            {
                statuses += "Merge sort started...\n\r";
                statuses += "start MergeSort in thread " + Thread.CurrentThread.ManagedThreadId.ToString() + "and task " + Task.CurrentId.ToString() + Environment.NewLine;
                mergeSortWithoutBlock.MergeSort(mas1ForMergeSort, ct);
                statuses += "end MergeSort in thread " + Thread.CurrentThread.ManagedThreadId.ToString() + "and task " + Task.CurrentId.ToString() + Environment.NewLine;
                statuses += "Merge sort finished.\n\r";
            }, ct);
            statuses += "метод WhenAnyWhenAll после создания задач TaskId = " + Task.CurrentId.ToString() + ", Thread = " + Thread.CurrentThread.ManagedThreadId.ToString() + Environment.NewLine;

            statuses += ShowTaskStatuses(tasks, "перед Start");

            // запускаем задачи
            foreach (var task in tasks)
            {
                task.Start();
            }

            statuses += ShowTaskStatuses(tasks, "перед WhenAny");

            // Асинхронно дожидаемся первой завершившейся задачи
            // Метод WhenAny возвращает задачу, которая закончилась раньше других
            Task firstFinished = await Task.WhenAny(tasks);

            statuses += "метод WhenAnyWhenAll после создания задач TaskId = " + Task.CurrentId.ToString() + ", Thread = " + Thread.CurrentThread.ManagedThreadId.ToString() + Environment.NewLine;

            statuses += ShowTaskStatuses(tasks, "сразу после WhenAny");
            cts.Cancel();
            cts.Dispose();
            Task.Delay(100).Wait();
            statuses += ShowTaskStatuses(tasks, "чуть-чуть подождав");

            // Асинхронно дожидаемся выполнения всех оставшихся задач
            //await Task.WhenAll(tasks);
            statuses += "выход из метода WhenAnyWhenAll TaskId = " + Task.CurrentId.ToString() + ", Thread = " + Thread.CurrentThread.ManagedThreadId.ToString() + Environment.NewLine;
            Indicator_Button.Text = statuses;
        }

        private void ColouredButton_Click(object sender, RoutedEventArgs e)
        {
            rnd = new Random();
            brushes = new List<SolidColorBrush>
            {
                Brushes.Aquamarine,
                Brushes.Black,
                Brushes.Chocolate,
                Brushes.Gold,
                Brushes.Green,
                Brushes.Magenta,
                Brushes.Orange,
                Brushes.Orchid
            };
            ColouredButton.Background = brushes[rnd.Next(0, brushes.Count)];
        }
        private string ShowTaskStatuses(Task[] tasks, string when)
        {
            string text = "";
            text += when + Environment.NewLine;
            for (int i = 0; i < tasks.Length; i++)
            {
                Task task = tasks[i];
                text += "статус задачи #" + i.ToString() + " " + task.Status.ToString() + Environment.NewLine;
            }
            return text;
        }

        private string PrintStatsForQuickSort()
        {
            string stats = "";
            if (checkSort.Check(mas1ForFastSort))
                stats += "Быстрая сортировка выполнена успешно\n\r";
            stats += "Время выполнения: " + stopwatch2.ElapsedMilliseconds + Environment.NewLine;
            stats += ForQSWithoutBlock;
            return stats;
        }
        private string PrintStatsForBubbleSort()
        {
            string stats = "";
            if (checkSort.Check(mas1ForBubbleSort))
                stats += "Сортировка пузырьком выполнена успешно\n\r";
            stats += "Время выполнения: " + stopwatch3.ElapsedMilliseconds + Environment.NewLine;
            stats += ForBSWithoutBlock;
            return stats;
        }
        private string PrintStatsForMergeSort()
        {
            string stats = "";
            if (checkSort.Check(mas1ForMergeSort))
                stats += "Сортировка вставками выполнена успешно\n\r";
            stats += "Время выполнения: " + stopwatch3.ElapsedMilliseconds + Environment.NewLine;
            stats += ForMSWithoutBlock;
            return stats;
        }
        private async Task ColorChanged()
        {
            List<SolidColorBrush> brushes;
            Random rnd;
            await Task.Run(() =>
            {
                rnd = new Random();
                brushes = new List<SolidColorBrush>
            {
                Brushes.AliceBlue,
                Brushes.AntiqueWhite,
                Brushes.Aqua,
                Brushes.Aquamarine
            };
                while (!finished)
                {
                        Dispatcher.Invoke(() =>
                        {
                            Indicator_Button.BorderBrush = brushes[rnd.Next(0, brushes.Count)];
                        });
                        Thread.Sleep(10);
                }
            });
        }
    }
}
