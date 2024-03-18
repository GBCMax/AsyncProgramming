using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessLogic.Business_Logic
{
    public class AsyncSort
    {
        /// <summary>
        /// метод для обмена элементов массива
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void Swap(ref long x, ref long y)
        {
            var t = x;
            x = y;
            y = t;
        }

        /// <summary>
        /// метод возвращающий индекс опорного элемента
        /// </summary>
        /// <param name="mas"></param>
        /// <param name="minIndex"></param>
        /// <param name="maxIndex"></param>
        /// <returns></returns>
        //private async Task<long> Partition(long[] mas, long minIndex, long maxIndex)
        private long Partition(long[] mas, long minIndex, long maxIndex, CancellationToken token)
        {
            long pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (token.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested();
                }
                if (mas[i] < mas[maxIndex])
                {
                    pivot++;
                    Swap(ref mas[pivot], ref mas[i]);
                }
            }

            pivot++;
            Swap(ref mas[pivot], ref mas[maxIndex]);
            return pivot;
        }

        /// <summary>
        /// быстрая сортировка
        /// </summary>
        /// <param name="mas"></param>
        /// <param name="minIndex"></param>
        /// <param name="maxIndex"></param>
        /// <returns></returns>
        private long[] QuickSort(long[] mas, long minIndex, long maxIndex, CancellationToken token)
        {
                if (minIndex >= maxIndex)
                {
                    return mas;
                }
                long pivotIndex = Partition(mas, minIndex, maxIndex, token);
                QuickSort(mas, minIndex, pivotIndex - 1, token);
                QuickSort(mas, pivotIndex + 1, maxIndex, token);
                return mas;
        }

        public async Task<long[]> QuickSort(long[] mas, CancellationToken token)
        {
            return await Task.Run(() =>
            {
                return QuickSort(mas, 0, mas.Length - 1, token);
            });
        }
    }
}
