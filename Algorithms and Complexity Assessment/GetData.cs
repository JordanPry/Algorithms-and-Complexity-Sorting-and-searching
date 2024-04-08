using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Algorithms_and_Complexity_Assessment
{
    internal class GetData
    {
        PrintData printer = new PrintData();
        /// <summary>
        /// Error handling for user input, only accepts input of 1 or 2
        /// </summary>
        /// <returns> an integer of either 1 or 2 </returns>
        public int UserFileInput() 
        {
            int choice;
            while (true)
            {
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    if (choice >= 1 && choice <= 2) { break; }
                    else { Console.WriteLine("Enter only 1 or 2"); }

                }
                catch (FormatException) { Console.WriteLine("Integers Only"); }
            }
            return choice;
        }
        /// <summary>
        /// Method for returning whether a user wants to open 1 file or merge 2 together
        /// </summary>
        /// <returns> 1 or 2 </returns>
        public int FileAmount()
        {
            Console.WriteLine("__________________________________________________________________");
            Console.WriteLine("Would you like to \n1: Open 1 file \n2: Merge 2 files");
            Console.WriteLine("__________________________________________________________________");
            return UserFileInput();

        }
        /// <summary>
        /// File selection method for selection one file, gets user input as int and selects corresponding index in an array
        /// </summary>
        /// <returns> index position of file </returns>
        public int OneFile() 
        {
            int userChoice = 0;
            string[] options = { "Net_1_256", "Net_1_2048", "Net_2_256", "Net_2_2048", "Net_3_256", "Net_3_2048", "Return to start screen" };
            
            while (true)
            {
                try
                {
                    userChoice = int.Parse(Console.ReadLine()) - 1;
                    if (userChoice >= 0 && userChoice < options.Length)
                    {
                        return userChoice;
                       
                    }

                    else
                    {
                        Console.WriteLine("Please enter a number between 1-7");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Input, Please enter a number");
                }
            }
        }
        /// <summary>
        /// File selection method for selection of two files, gets user input as int and selects corresponding index in an array
        /// </summary>
        /// <returns>index position of both files </returns>
        public string[] TwoFiles() 
        {
            printer.ShowData();
            int userChoice = 0;
            int userChoice2 = 0;
            string[] options = { "Net_1_256", "Net_1_2048", "Net_2_256", "Net_2_2048", "Net_3_256", "Net_3_2048"};
            string[] mergeTest = { "Net_1_256", "Net_1_2048" };
            while (true)
            {
                try
                {
                    Console.Write("First File: "); userChoice = int.Parse(Console.ReadLine()) - 1;
                    Console.Write("Second File: "); userChoice = int.Parse(Console.ReadLine()) - 1;
                    if (userChoice >= 0 && userChoice < options.Length && userChoice != userChoice2)
                    {
                        mergeTest[0] = options[userChoice];
                        mergeTest[1] = options[userChoice2];
                        return mergeTest;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number between 1-7");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Input, Please enter a number");
                }
            }
        }
        /// <summary>
        /// Method that opens the file(s) the user has selected.
        /// </summary>
        /// <returns> an int array of the file data </returns>
        public int[] DataChoice()
        {
           
            string[] options = { "Net_1_256", "Net_1_2048", "Net_2_256", "Net_2_2048", "Net_3_256", "Net_3_2048"};
            int fileAmount = FileAmount();
            if (fileAmount == 1) //ONE FILE OPENED
            {
                printer.ShowData();
                return OpenData(options[OneFile()]);
       
            }
            else //Get user to select from 2 options, Make sure they arent the same, 
            {
                
                return OpenMergeData(TwoFiles());

            }
   
        }
        //OPENING DATA METHODS
        /// <summary>
        /// Loops through the array of the datafile and converts to int replacing index of the created array
        /// </summary>
        /// <param name="userChoice"></param>
        /// <returns>the opened file data as int array</returns>
        public int[] OpenData(string userChoice)
        {
            string[] fileLines = File.ReadAllLines($"{userChoice}.txt");
            int[] fileData = new int[fileLines.Length];
            for (int i = 0; i < fileLines.Length; i++)
            {
                fileData[i] = int.Parse(fileLines[i]);

            }
            return fileData;
        }
        /// <summary>
        /// loops through the datafile and converts to int, upon completion does the same for second file but starting at the index after the last position added
        /// </summary>
        /// <param name="userChoice"></param>
        /// <returns> the opened file data as int array </returns>
        public int[] OpenMergeData(string[] userChoice) 
        {
            string[] fileLines = File.ReadAllLines($"{userChoice[0]}.txt");
            string[] file2Lines = File.ReadAllLines($"{userChoice[1]}.txt");
            int[] fileData = new int[(fileLines.Length + file2Lines.Length)];
            for (int i = 0; i < fileLines.Length; i++)
            {
                fileData[i] = int.Parse(fileLines[i]);
            }
            for (int i = 0; i < file2Lines.Length; i++)
            {
                fileData[i + fileLines.Length] = int.Parse(file2Lines[i]);
            }

            return fileData;
        }
    }
}