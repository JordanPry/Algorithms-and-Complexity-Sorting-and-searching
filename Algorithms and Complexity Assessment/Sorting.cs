using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_and_Complexity_Assessment
{
    internal class Sorting
    {
        /// <summary>
        /// Algorithm that prompt user for which sorting algorithm to use.
        /// </summary>
        /// <param name="_data"></param>
        /// <returns>the array sorted </returns>
        public int[] ChooseAlgorithm(int[] _data) //Finish error handling user input.
        {
            PrintData printer = new PrintData();
            string[] sortingAlgorithms = { "Bubble", "Quick", "Merge", "Insertion", "Selection", "Heap", "Most Efficent" };
            printer.PrintAlgorithms(sortingAlgorithms);
            string userChoice = Console.ReadLine();
            int[] timer = new int[_data.Length];
            int counter = 0;
            switch (userChoice)
            {
                case "1": //Bubble
                    return BubbleSort(_data);
                case "2": //Quick
                    return QuickSort(_data, 0, _data.Length - 1, ref counter);
                case "3": //Merge
                    return MergeSort(_data, ref counter);
                case "4": //Insertion
                    return InsertionSort(_data);
                case "5": //Selection
                    return SelectionSort(_data);
                case "6": // Heap
                    return HeapSort(_data);
                case "7": // Most Efficent (Heap)
                    return HeapSort(_data);
                default:
                    Console.WriteLine("Please enter only between 1-7");
                    break;
            }
            return BubbleSort(_data);
        }
        /// <summary>
        /// Bubble Sort Algorithm
        /// Iteratites through the array and compares adjacent items
        /// swaps if theyre in wrong order
        /// repeated until no swaps occur
        /// </summary>
        /// <param name="_data">The unsorted array</param>
        /// <returns>The sorted array</returns>
        public int[] BubbleSort(int[] _data)
        {
            bool itemsSwapped;
            int counter = 0;
            do
            {
                itemsSwapped = false;
                for (int i = 0; i < _data.Length - 1; i++)
                {
                    if (_data[i] > _data[i + 1])
                    {
                        (_data[i + 1], _data[i]) = (_data[i], _data[i + 1]);
                        itemsSwapped = true;
                    }
                    counter++;
                }
            }
            while (itemsSwapped);
            Console.WriteLine($"BubbleSort Took {counter} iterations");

            return _data;
        }
        /// <summary>
        /// Insertion Sort Algorithm
        /// Builds the sorted array one item at a time
        /// repeatedly taking next item from unsorted and inserting into the correct position
        /// </summary>
        /// <param name="_data">The unsorted array</param>
        /// <returns>The sorted array</returns>
        public int[] InsertionSort(int[] _data)
        {
            int counter = 0;
            for (int i = 1; i < _data.Length - 1; ++i)
            {
                int j = i;
                do
                {
                    (_data[j], _data[j - 1]) = (_data[j - 1], _data[j]);
                    counter++;
                    j--;

                } while (j > 0 && _data[j - 1] > _data[j]);
            }
            Console.WriteLine($"InsertionSort Took {counter} iterations");
            return _data;
        }
        /// <summary>
        /// Selection Sort Algorithm
        /// Divides array into two parts
        /// a sorted and unsorted sublist, repeatedly takes smallest from unsorted
        /// and adds to the beginning of the sorted
        /// </summary>
        /// <param name="_data">The unsorted array</param>
        /// <returns>The sorted array</returns>
        public int[] SelectionSort(int[] _data)
        {
            int counter = 0;
            for (int i = 0; i < _data.Length - 1; ++i)
            {
                int arrayMin = i;
                for (int j = i + 1; j < _data.Length; ++j)
                {
                    if (_data[j] < _data[arrayMin])
                    {
                        arrayMin = j;
                    }
                    counter++;
                }
                if (arrayMin != i)
                {
                    (_data[i], _data[arrayMin]) = (_data[arrayMin], _data[i]);

                }
            }
            Console.WriteLine($"SelectionSort Took {counter} iterations");
            return _data;
        }
        /// <summary>
        /// Merge Sort Algorithm
        /// It divides the input array into two halves
        /// recursively sorts each half
        /// merges the sorted halves to create the sorted array
        /// </summary>
        /// <param name="_data">The unsorted array</param>
        /// <returns>The sorted array</returns>
        public int[] MergeSort(int[] _data, ref int counter)
        {
            if (_data.Length == 1)
            {
                Console.WriteLine($"SelectionSort Took {counter} iterations");
                return _data;
            }
            else
            {
                int mid = _data.Length / 2;
                int[] arrayOne = new int[mid];
                int[] arrayTwo = new int[_data.Length - mid];
                Array.Copy(_data, 0, arrayOne, 0, mid);
                Array.Copy(_data, mid, arrayTwo, 0, _data.Length - mid);

                arrayOne = MergeSort(arrayOne, ref counter);
                arrayTwo = MergeSort(arrayTwo, ref counter);

                return Merge(arrayOne, arrayTwo, ref counter);
            }
        }
        public int[] Merge(int[] arrayOne, int[] arrayTwo, ref int counter)
        {
            int[] arrayThree = new int[arrayOne.Length + arrayTwo.Length];
            int i = 0, j = 0, k = 0;

            while (i < arrayOne.Length && j < arrayTwo.Length)
            {
                if (arrayOne[i] <= arrayTwo[j])
                    arrayThree[k++] = arrayOne[i++];
                else
                    arrayThree[k++] = arrayTwo[j++];
                counter++;
            }

            while (i < arrayOne.Length)
                arrayThree[k++] = arrayOne[i++];

            while (j < arrayTwo.Length)
                arrayThree[k++] = arrayTwo[j++];

            return arrayThree;

        }
        /// <summary>
        /// Quick Sort Algorithm
        /// It selects a pivot item from the array
        /// partitions the other items into two sub-arrays 
        /// according to whether they are less than or greater than the pivot
        /// recursively sorts the sub-arrays.
        /// </summary>
        /// <param name="_data">The unsorted array</param>
        /// <param name="low">first index</param>
        /// <param name="high">last index</param>
        /// <returns>The sorted array</returns>
        public int[] QuickSort(int[] _data, int low, int high, ref int counter)
        {

            if (low < high)
            {

                int pivotLocation = Partition(_data, low, high, ref counter);
                QuickSort(_data, low, pivotLocation - 1, ref counter);
                QuickSort(_data, pivotLocation + 1, high, ref counter);
            }
            Console.WriteLine($"QuickSort Took {counter} iterations");
            return _data;

        }
        public int Partition(int[] _data, int low, int high, ref int counter)
        {
            int pivot = _data[high];
            int leftWall = low;

            for (int x = low; x < high; x++)
            {
                if (_data[x] <= pivot)
                {
                    (_data[x], _data[leftWall]) = (_data[leftWall], _data[x]);
                    leftWall++;
                }
                counter++;
            }
            (_data[leftWall], _data[high]) = (_data[high], _data[leftWall]);

            return leftWall;

        }
        /// <summary>
        /// Heap Sort Algorithm
        /// Builds a max heap from the input array
        /// repeatedly removing the maximum element from the heap 
        /// placing it at the end of the array
        /// then heapifying the remaining heap.
        /// </summary>
        /// <param name="_data">The unsorted array</param>
        /// <returns>The sorted array</returns>
        public static int MaxHeap(int[] _data)
        {
            int heapSize = _data.Length;
            int counter = 0; 
            for (int i = heapSize / 2 - 1; i >= 0; i--)
            {
                counter += MaxHeapify(_data, heapSize, i);
            }
            return  counter;
        }

        public static int MaxHeapify(int[] _data, int heapSize, int i)
        {
            int counter = 1; // Start with 1 as we are considering the current comparison
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int largest = i;

            if (left < heapSize && _data[left] > _data[largest])
            {
                largest = left;
            }
            if (right < heapSize && _data[right] > _data[largest])
            {
                largest = right;
            }
            if (largest != i)
            {
                (_data[i], _data[largest]) = (_data[largest], _data[i]);
                counter += MaxHeapify(_data, heapSize, largest);
            }
            return counter;
        }

        public static int[] HeapSort(int[] _data)
        {
            int counter = MaxHeap(_data);
            for (int i = _data.Length - 1; i > 0; i--)
            {
                (_data[i], _data[0]) = (_data[0], _data[i]);
                counter += MaxHeapify(_data, i, 0);
            }
            Console.WriteLine($"QuickSort Took {counter} iterations");
            return _data;
        }
    }
}
 
