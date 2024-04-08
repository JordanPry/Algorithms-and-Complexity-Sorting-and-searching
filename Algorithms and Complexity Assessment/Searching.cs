using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_and_Complexity_Assessment
{
    internal class Searching
    {
        /// <summary>
        /// Linear Search Algorithm
        /// Iterates over all positions in array, 
        /// appends the index to a list if number matches item in array
        /// </summary>
        /// <param name="num">the number to search for </param>
        /// <param name="_data">the sorted data</param>
        /// <returns></returns>
        public List<int> LinearSearch(int num, int[] _data)
        {
            List<int> positions = new List<int>();
            for (int i = 0; i < _data.Length; i++)
            {
                if (_data[i] == num)
                {
                    positions.Add(i);
                }
            }
            Console.WriteLine($"This Search took {_data.Length} iterations to find");
            return positions;
        }
        /// <summary>
        /// Binary Search Algorithm 
        /// Searches for num within a sorted array by repeatedly dividing the search interval in half
        /// </summary>
        /// <param name="num"> the number to search for </param>
        /// <param name="_data"> the sorted data </param>
        /// <returns>A list of indicies where the number is found</returns>
        public List<int> BinarySearch(int num, int[] _data)
        {
            List<int> positions = new List<int>();
            int counter = 0;
            int arrayMin = 0;
            int arrayMax = _data.Length - 1;
            while (arrayMin <= arrayMax)
            {
                counter++;
                int arrayMid = (arrayMin + arrayMax) / 2;
                if (_data[arrayMid] == num)
                {
                    positions.Add(arrayMid);
                    int temp = arrayMid - 1;
                    while (temp >= arrayMin && _data[temp] == num)
                    {
                        positions.Add(temp); temp--;
                    }
                    temp = arrayMid + 1;
                    while (temp <= arrayMax && _data[temp] == num)
                    {
                        positions.Add(temp); temp++;
                    }
                    Console.WriteLine($"Binary Search took {counter} iterations to find num(s)");
                    return positions;
                }
                else if (_data[arrayMid] < num){arrayMin = arrayMid + 1;}
                else{arrayMax = arrayMid - 1;}
            }
            
            return positions;
        }
        /// <summary>
        /// Interpolation Search Algorithm
        /// Searches for the number in a sorted array by estimating the position
        /// does this based on the numbers value
        /// </summary>
        /// <param name="num">number to search for </param>
        /// <param name="_data">the sorted data </param>
        /// <returns>list of indeces where the number is found</returns>
        public List<int> InterpolationSearch(int num, int[] _data)
        {
            List<int> positions = new List<int>();
            int high = _data.Length - 1;
            int low = 0;
            int counter = 0;
            if (num < _data[low] || num > _data[high])
            {
                Console.WriteLine("Number not found in the array.");
                return positions;
            }

            while (low <= high)
            {
                counter++;
                int probe = low + (int)(((double)(high - low) / (_data[high] - _data[low])) * (num - _data[low]));
                probe = Math.Min(probe, high);
                probe = Math.Max(probe, low);

                if (_data[probe] == num)
                {
                    positions.Add(probe);
                    int temp = probe - 1;
                    while (temp >= low && _data[temp] == num)
                    {
                        positions.Add(temp);
                        temp--;
                    }
                    temp = probe + 1;
                    while (temp <= high && _data[temp] == num)
                    {
                        positions.Add(temp);
                        temp++;
                    }
                    Console.WriteLine($"Interpolation Search took {counter} iterations to find num(s)");
                    return positions;
                }
                else if (_data[probe] < num)
                {
                    low = probe + 1;
                }
                else
                {
                    high = probe - 1;
                }
            }

            return positions;
        }
        /// <summary>
        /// Nearest Value Algorithm
        /// Find the nearest value to a number in an array
        /// </summary>
        /// <param name="num">number to find nearest balue</param>
        /// <param name="_data">the array of data </param>
        /// <returns>an array with the index and position of the nearest number </returns>
        public int[] NearestValue(int num, int[] _data) //works as intended
        {
            int closest = _data[0];
            for (int i = 0; i <= _data.Length - 1; i++) 
            {
                int difference = Math.Abs(num - _data[i]); 
                if (difference < Math.Abs(num- closest))
                {
                    closest = _data[i];
                }       
            }
            List<int> pos = BinarySearch(closest, _data);
            int[] valuePos = { pos[0], closest };
            return valuePos;
        }
    }
}

