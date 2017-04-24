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

            public static void MaxHeapify(int[] array, int index, int heapSize, int low)
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

            //public void DownHeap(int[] array, int i, int n, int lo)
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
            internal static int QuickSortPartition(int[] array, int left, int right)
            {
                //pick pivote point
                int pivote = array[(left + right) / 2];
                pivote.Print("Pivote:\n");
                while (left <= right)
                {
                    array.Print("Sub Array:", left, right);
                    //Find element on left that should be on right
                    while (array[left] < pivote)
                    {
                        left++;
                        left.Print("Left:\n");
                    }
                    //Find element on right that should be on left
                    while (array[right] > pivote)
                    {
                        right--;
                        right.Print("Right:\n");
                    }
                    //Swap elements, and move left and right indices
                    if (left <= right)
                    {
                        //swaps elements Swap(arr, left, right);
                        array.Swap(left, right);
                        array.Print($"Swap left-{left} right-{right}");
                        left++;
                        right--;
                    }
                }

                left.Print("Median\\Index:\n");
                return left;
            }

            internal static void Sort(int[] arr, int left, int right)
            {
                arr.Print("Input:", left, right);
                int index = QuickSortPartition(arr, left, right);
                //Sort left half
                if (left < index - 1)
                {
                    Sort(arr, left, index - 1);
                }
                //Sort right half
                if (index < right)
                {
                    Sort(arr, index, right);
                }
            }
        }

        internal class MergeSort
        {
            private void Sort(int[] arr)
            {
                int[] helper = new int[arr.Length];
                Sort(arr, helper, 0, arr.Length);
            }

            private void Sort(int[] arr, int[] helper, int low, int high)
            {
                if (low < high)
                {
                    int middle = (low + high) / 2;
                    Sort(arr, helper, low, middle);
                    Sort(arr, helper, low, middle);
                    Merge(arr, helper, low, middle, high);
                }
            }

            private void Merge(int[] arr, int[] helper, int low, int middle, int high)
            {
                //Copy both halves into a helper array
                for (int i = low; i <= high; i++)
                {
                    helper[i] = arr[i];
                }

                int helperLeft = low;
                int helperRight = middle + 1;
                int current = low;
                /*
                 Iterate through helper arry. Compare the left and riht half, Copying back
                 the smaller element from the two halves into the original array.
                 */
                while (helperLeft <= middle && helperRight <= high)
                {
                    if (helper[helperLeft] <= helper[helperRight])
                    {
                        arr[current] = helper[helperLeft];
                        helperLeft++;
                    }
                    //If right element is small than left element
                    else
                    {
                        arr[current] = helper[helperRight];
                        helperRight++;
                    }
                    current++;
                }

                //Copy the rest of the left side of the arry inot the target array
                int remaining = middle - helperLeft;
                for (int i = 0; i <= remaining; i++)
                {
                    arr[current + i] = helper[helperLeft + i];
                }
            }
        }
    }
}