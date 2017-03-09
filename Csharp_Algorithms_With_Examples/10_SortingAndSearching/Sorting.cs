using TWL_Algorithms_Samples;
using TWL_Algorithms_Samples.Arrays;

namespace TWL_Algorithms_Samples.SortingAndSearching
{
    internal class Sorting
    {
        public void Run()
        {
            //Console.WriteLine($"Start {this.GetType().Name}.Run");
            //int[] array = Constants.cArrayNumbers;

            ////QuickSort.Sort(array, 0, array.Length - 1);
            ////HeapSort.Sort(array, 0, array.Length - 1);
            //HeapSort.Sort(new int[] { 10, 20, 25, 60, 30, 58, 71, 99, 70, 82, 50, 90, 85 });
            ////HeapSort.Sort(Constants.cArrayNumbersHeap);
            //Console.WriteLine($"End {this.GetType().Name}.Run");
        }

        internal class HeapSort
        {
            internal static void Sort(int[] array, int lo, int hi)
            {
                int n = hi - lo + 1;
                for (int i = n / 2; i >= 1; i = i - 1)
                {
                    MaxHeapify(array, i, n, lo);
                }
                array.Print("Array after first iteration");
                for (int i = n; i > 1; i = i - 1)
                {
                    array.Swap(lo, lo + i - 1);
                    MaxHeapify(array, 1, i - 1, lo);
                }
                array.Print("Array after second iteration");
            }

            internal static void Sort(int[] array)
            {
                //Build-Max-Heap
                int heapSize = array.Length;
                for (int p = (heapSize - 1) / 2; p >= 0; p--)
                {
                    MaxHeapify(array, p, heapSize, 0);
                }

                for (int i = array.Length - 1; i > 0; i--)
                {
                    array.Swap(0, i);
                    MaxHeapify(array, 0, i - 1, 0);
                }
            }

            private static void MaxHeapify(int[] array, int index, int heapSize, int low)
            {
                array.Print("\n");
                int left = (index + 1) * 2 - 1;
                int right = (index + 1) * 2;
                int largest = 0;

                if (left < heapSize && array[left] > array[index])
                    largest = left;
                else
                    largest = index;

                if (right < heapSize && array[right] > array[largest])
                    largest = right;

                if (largest != index)
                {
                    array.Swap(index, largest);

                    MaxHeapify(array, largest, heapSize, left);
                }
            }

            //private void DownHeap(int[] array, int i, int n, int lo)
            //{
            //    Object d = keys.GetValue(lo + i - 1);
            //    Object dt = (items != null) ? items.GetValue(lo + i - 1) : null;
            //    int child;
            //    while (i <= n / 2)
            //    {
            //        child = 2 * i;
            //        if (child < n && comparer.Compare(keys.GetValue(lo + child - 1), keys.GetValue(lo + child)) < 0)
            //        {
            //            child++;
            //        }

            //        if (!(comparer.Compare(d, keys.GetValue(lo + child - 1)) < 0))
            //            break;

            //        keys.SetValue(keys.GetValue(lo + child - 1), lo + i - 1);
            //        if (items != null)
            //            items.SetValue(items.GetValue(lo + child - 1), lo + i - 1);
            //        i = child;
            //    }
            //    keys.SetValue(d, lo + i - 1);
            //    if (items != null)
            //        items.SetValue(dt, lo + i - 1);
            //}
        }

        internal class QuickSort
        {
            internal static int Partition(int[] array, int left, int right)
            {
                //pick pivote point
                int pivote = array[(left + right) / 2];
                pivote.Print("Pivote:\n");
                while (left <= right)
                {
                    array.Print("Sub Array:", left, right);
                    while (array[left] < pivote)
                    {
                        left++;
                        left.Print("Left:\n");
                    }

                    while (array[right] > pivote)
                    {
                        right--;
                        right.Print("Right:\n");
                    }

                    if (left <= right)
                    {
                        array.Swap(left, right);
                        array.Print($"Swap left-{left} right-{right}");
                        left++;
                        right--;
                    }
                }

                left.Print("Median\\Index:\n");
                return left;
            }

            internal static void Sort(int[] array, int left, int right)
            {
                array.Print("Input:", left, right);
                int index = Partition(array, left, right);
                if (left < index - 1)
                {
                    Sort(array, left, index - 1);
                }
                if (index < right)
                {
                    Sort(array, index, right);
                }
            }
        }
    }
}