using System;
using System.IO;
using System.Linq;

namespace TestApp.Merge
{
    public class Sort : ITask
    {
        public string Title { get => "Selection sort"; }
        public string Run(string[] data)
        {
            ushort[] test = new ushort[0];
            var arr = File.ReadAllBytes("MergeSortData.txt");
            for (var i = 0; i < 50; i++)
            {
                Array.Resize(ref test, test.Length + 1);
                var n = arr[i * 2] + arr[i * 2 + 1];
                test[test.GetUpperBound(0)] = (ushort)BitConverter.Int32BitsToSingle(n);
            }
            return null;
        }
        //метод для слияния массивов
        static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
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
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
        }

        //сортировка слиянием
        static int[] MergeSort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(array, lowIndex, middleIndex);
                MergeSort(array, middleIndex + 1, highIndex);
                Merge(array, lowIndex, middleIndex, highIndex);
            }

            return array;
        }

        static int[] MergeSort(int[] array)
        {
            return MergeSort(array, 0, array.Length - 1);
        }
    }
}