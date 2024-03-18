using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogic.Business_Logic
{
    public class MergeSortWithoutBlock
    {
        //метод для слияния массивов
        private static void Merge(long[] array, long lowIndex, long middleIndex, long highIndex, CancellationToken token)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new long[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                if (token.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested();
                }
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                if (token.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested();
                }
                tempArray[index] = array[i];
                index++;
                //if (token.IsCancellationRequested)
                //    throw new OperationCanceledException(token);
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                if (token.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested();
                }
                array[lowIndex + i] = tempArray[i];
            }
        }

        //сортировка слиянием
        private static long[] MergeSort(long[] array, long lowIndex, long highIndex, CancellationToken token)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(array, lowIndex, middleIndex, token);
                MergeSort(array, middleIndex + 1, highIndex, token);
                Merge(array, lowIndex, middleIndex, highIndex, token);
            }

            return array;
        }

        public long[] MergeSort(long[] array, CancellationToken token)
        {
                return MergeSort(array, 0, array.Length - 1, token);
        }
    }
}
