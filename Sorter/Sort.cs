using System;
using System.Diagnostics;

namespace Sorter
{
    public abstract class MeasureSort
    {
        public int sortingTime, n;
        public int[]? arr;

        public string? sortingMethod = "";

        public MeasureSort(int n)
        {
            sortingTime = 0;
            this.n = n;
            arr = null;
        }

        public void TemplateMethod()
        {
            InitArray();
            Sort();
            DisplayResults();
        }

        protected void InitArray()
        {
            // Create an array of random numbers
            arr = new int[n];
            Random rand = new();
            for (int i = 0; i < n; i++)
            {
                arr[i] = rand.Next(1000);
            }
        }

        protected abstract void Sort();

        protected void DisplayResults()
        {
            Console.WriteLine("Sorting method: {0}", sortingMethod);
            Console.WriteLine("Sorting time: {0} ms", sortingTime);
        }
    }

    public class BubbleSort : MeasureSort
    {
        public BubbleSort(int n) : base(n)
        {
            this.n = n;
        }
        protected override void Sort()
        {
            sortingMethod = "Bubble Sort";

            Stopwatch stopWatch = new();
            stopWatch.Start();

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < (arr.Length - i - 1); j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // Swap elements
                        (arr[j + 1], arr[j]) = (arr[j], arr[j + 1]);
                    }
                }

            }

            stopWatch.Stop();
            sortingTime = stopWatch.Elapsed.Milliseconds;
        }
    }

    public class MergeSort : MeasureSort
    {
        public MergeSort(int n) : base(n)
        {
            this.n = n;
        }
        protected override void Sort()
        {
            sortingMethod = "Merge Sort";

            Stopwatch stopWatch = new();
            stopWatch.Start();

            MergeSortRecursive(0, arr.Length - 1);

            stopWatch.Stop();
            sortingTime = stopWatch.Elapsed.Milliseconds;
        }

        private void MergeSortRecursive(int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                MergeSortRecursive(left, middle);
                MergeSortRecursive(middle + 1, right);

                Merge(left, middle, middle + 1, right);
            }
        }

        private void Merge(int leftStart, int leftEnd, int rightStart, int rightEnd)
        {
            int leftLength = leftEnd - leftStart + 1;
            int rightLength = rightEnd - rightStart + 1;

            int[] left = new int[leftLength];
            int[] right = new int[rightLength];

            Array.Copy(arr, leftStart, left, 0, leftLength);
            Array.Copy(arr, rightStart, right, 0, rightLength);

            int i = 0, j = 0, k = leftStart;

            while (i < leftLength && j < rightLength)
            {
                if (left[i] <= right[j])
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }

                k++;
            }

            while (i < leftLength)
            {
                arr[k] = left[i];
                i++;
                k++;
            }

            while (j < rightLength)
            {
                arr[k] = right[j];
                j++;
                k++;
            }
        }
    }

}
