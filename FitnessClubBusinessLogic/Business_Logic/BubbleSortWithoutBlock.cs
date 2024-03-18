using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogic.Business_Logic
{
    public class BubbleSortWithoutBlock
    {
        private long[] massive;
        //Метод, сортирующий массив целых чисел (по возрастанию)
        private static void Bubble_Sort(long[] anArray, CancellationToken token)
        {
            //Основной цикл (количество повторений равно количеству элементов массива)
            for (int i = 0; i < anArray.Length; i++)
            {
                //Вложенный цикл (количество повторений, равно количеству элементов массива минус 1 и минус количество выполненных повторений основного цикла)
                for (int j = 0; j < anArray.Length - 1 - i; j++)
                {
                    if (token.IsCancellationRequested)
                    {
                        token.ThrowIfCancellationRequested();
                    }
                    //Если элемент массива с индексом j больше следующего за ним элемента
                    if (anArray[j] > anArray[j + 1])
                    {
                        //Меняем местами элемент массива с индексом j и следующий за ним
                        Swap(ref anArray[j], ref anArray[j + 1]);
                    }
                }
            }
        }

        //Вспомогательный метод, "меняет местами" два элемента
        private static void Swap(ref long aFirstArg, ref long aSecondArg)
        {
            //Временная (вспомогательная) переменная, хранит значение первого элемента
            long tmpParam = aFirstArg;

            //Первый аргумент получил значение второго
            aFirstArg = aSecondArg;

            //Второй аргумент, получил сохраненное ранее значение первого
            aSecondArg = tmpParam;
        }
        public long[] BubbleSort(long[] mas, CancellationToken token)
        {
            massive = mas;
            Bubble_Sort(massive, token);
            return massive;
        }
    }
}
