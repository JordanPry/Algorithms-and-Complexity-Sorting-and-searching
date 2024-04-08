using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_and_Complexity_Assessment
{
    internal class Program
    {
        private static GetData InputData = new GetData();
        private static Sorting SortData = new Sorting();
        private static PrintData printData = new PrintData();
        private static Searching SearchData = new Searching();

        /// <summary>
        /// Starting point UI for the Program
        /// Depending on user input progresses or closes program
        /// </summary>
        static void StartScreen()  //fix error handling
        {
            Console.WriteLine("__________________________________________________________________");
            Console.WriteLine("Welcome Would you Like to \n1: Select data to analyse\n2: Exit Program");
            Console.WriteLine("__________________________________________________________________");
            while (true) 
            {
                
                try
                {
                    int userChoice = int.Parse(Console.ReadLine());
                    switch (userChoice)
                    {
                        case 1:
                            AnalyseData();
                            break;
                        case 2:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Please enter only 1 or 2.");
                            break;
                    }
                    break;
                    
                }
                catch (FormatException) { Console.WriteLine("Integers Only"); }       
            }

        }
        /// <summary>
        /// Method for the user to choose which search algorithm they would like to use
        /// </summary>
        /// <returns> the algorithm choice as an int</returns>
        static int ChooseAlgorithm() 
        {
            string[] searchAlgo = { "Linear Search", "Binary Search", "Interpolation Search", "Most Efficent" };
            printData.PrintAlgorithms(searchAlgo);
            int choice;
            while (true)
            {
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    if (choice >= 1 && choice <= 4) 
                    { break; }
                    else { Console.WriteLine("Enter integers between 1 - 4"); }
                    
                }
                catch (FormatException) { Console.WriteLine("Integers Only"); }
            }
            return choice;

        }
        /// <summary>
        /// Method for searching the dataset for the number the user specified
        /// </summary>
        /// <param name="sortedData"></param>
        static void FindData(int[] sortedData) 
        {
            int sortAlgo = ChooseAlgorithm(); int userChoice; List<int> positions = new List<int>();
            Console.WriteLine("Please enter the Value youd like to search For within the dataset:");
            Console.WriteLine("__________________________________________________________________");
          
            while (true)
            {
                try
                {
                    userChoice = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException) { Console.WriteLine("Integers Only"); }
            }
            switch (sortAlgo) 
            {
                case 1:
                    positions = SearchData.LinearSearch(userChoice, sortedData);
                    break;
                case 2:
                    positions = SearchData.BinarySearch(userChoice, sortedData);
                    break;
                case 3:
                    positions = SearchData.InterpolationSearch(userChoice, sortedData);
                    break;
                case 4:
                    positions = SearchData.InterpolationSearch(userChoice, sortedData);
                    break;
            }
            if (positions.Count > 0)
            {
                foreach (var pos in positions) { Console.WriteLine($"{userChoice} is at position: {pos} in ascending Sorted Array"); }
                foreach (var pos in positions) { Console.WriteLine($"{userChoice} is at position: {sortedData.Length - pos - 1} in descending Sorted Array"); }
                StartScreen(); // returns to start screen
            }
            else 
            {
                DataNotFound(userChoice, sortedData);
                StartScreen();
            }
        }
        /// <summary>
        /// If number specified is not found
        /// this method is called to display to the user where the nearest value and position is
        /// </summary>
        /// <param name="userChoice"></param>
        /// <param name="sortedData"></param>
        static void DataNotFound(int userChoice, int[] sortedData)
        {
            Console.WriteLine("Data not found within array, find nearest value and postion");
            int[] nearestPosValue = SearchData.NearestValue(userChoice, sortedData);
            Console.WriteLine($"Number: {nearestPosValue[1]}\nFound at position: {nearestPosValue[0]}");

        }

        /// <summary>
        /// Method for user To choose which data they would like to open and sort.
        /// </summary>
        static void AnalyseData()  
        {
            int[] chosenData = InputData.DataChoice();
            if (chosenData[0] == -1)
            {
                StartScreen();

            }
            else
            {
                int[] sortedData = SortData.ChooseAlgorithm(chosenData); // Call choose algorithm function to return Data sorted through selected algorithm
                printData.PrintDataOptions(sortedData);
                FindData(sortedData);
            }
            
        }
        /// <summary>
        /// Opening Point of the Program when Ran, Calls the StartScreen() Method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            StartScreen();
        }
    }
}
