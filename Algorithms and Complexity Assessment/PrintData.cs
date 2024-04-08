using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_and_Complexity_Assessment
{
    internal class PrintData
    {
        //Program--------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Prints data in decending order, looping backwards from the end of the array printing the index values
        /// depending on the length of the array either prints, 50th or 10th value in array 
        /// </summary>
        /// <param name="sortedData"></param>
        private void PrintDataD(int[] sortedData) //works as intended
        {
            Console.WriteLine("Decending:");
            Console.WriteLine("__________________________________________________________________");
            for (int i = sortedData.Length - 1; i >= 0; i--)
            {
                if (sortedData.Length <= 256)
                {
                    if (i % 10 == 0) { Console.WriteLine(sortedData[i]); }
                }
                else
                {
                    if (i % 50 == 0) { Console.WriteLine(sortedData[i]); }
                }
            }
            Console.WriteLine("__________________________________________________________________");
        }
        /// <summary>
        /// Prints data in ascending order, looping through the array and printing the index values
        /// depending on the length of the array either prints, 50th or 10th value in array 
        /// </summary>
        /// <param name="sortedData"></param>
        private void PrintDataA(int[] sortedData) //works as intended
        {
            Console.WriteLine("Ascending: ");
            Console.WriteLine("__________________________________________________________________");
            for (int i = 0; i < sortedData.Length; i++)
            {
                if (sortedData.Length <= 256)
                {
                    if (i % 10 == 0) { Console.WriteLine(sortedData[i]); }
                }
                else
                {
                    if (i % 50 == 0) { Console.WriteLine(sortedData[i]); }
                }

            }
            Console.WriteLine("__________________________________________________________________");
        }
        /// <summary>
        /// Prompts the user how they would like the data displayed and called corresponding methods accordingly
        /// </summary>
        /// <param name="sortedData"></param>
        public void PrintDataOptions(int[] sortedData) //works as intended
        {
            Console.WriteLine("__________________________________________________________________");
            Console.WriteLine("Would You like to print the data in \n1: Ascending\n2: Descending\n3: Ascending and Descending");
            Console.WriteLine("__________________________________________________________________");

            bool validChoice = false;
            while (!validChoice)
            {
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        PrintDataA(sortedData);
                        validChoice = true;
                        break;
                    case "2":
                        PrintDataD(sortedData);
                        validChoice = true;
                        break;
                    case "3":
                        PrintDataA(sortedData);
                        PrintDataD(sortedData);
                        validChoice = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please only enter 1, 2, or 3");
                        break;
                }
            }
        }

        //Get Data-------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Prints out the data options for the files the user can open.
        /// </summary>
        public void ShowData() //works as intended
        {
            string[] options = { "Net_1_256", "Net_1_2048", "Net_2_256", "Net_2_2048", "Net_3_256", "Net_3_2048"};
            Console.WriteLine("__________________________________________________________________");
            Console.WriteLine("Please Enter the Number of the data you would like to analyse.");
            Console.WriteLine("__________________________________________________________________");
            int counter = 1;
            for (int i = 0; i < options.Length; i++)
            {
                Console.Write($"{counter}: ");
                Console.WriteLine(options[i]);
                counter++;
            }
            Console.WriteLine("__________________________________________________________________");

        }
        //Sorting and Searching-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Prints out the algorithms defined in the options paramater to display to the user.
        /// </summary>
        /// <param name="options"></param>
        public void PrintAlgorithms(string[] options) // works as intended
        {
            Console.WriteLine("__________________________________________________________________");
            Console.WriteLine("Please Enter the Number of the Algorithm you would like to Use.");
            Console.WriteLine("__________________________________________________________________");
            int counter = 1;
            for (int i = 0; i < options.Length; i++)
            {
                Console.Write($"{counter}: ");
                Console.WriteLine(options[i]);
                counter++;
            }
            Console.WriteLine("__________________________________________________________________");
        }   
    }
}
