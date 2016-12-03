using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayTests
{
    class Program
    {
        static public void Foo(int[] array)
        {
            array[0] = -1;
        }

        static void Main(string[] args)
        {
            // Testing Reference interactions
            int[] array = new int[5] { 7, 4, 6, 5, 6 };
            Foo(array);
            Console.WriteLine(array[0]);

            int[] array2 = array;

            array2[0] = -2;

            Console.WriteLine(array[0]);
            Console.WriteLine(array2[0]);
            /**************************************************************************/

            // Creating and sorting a single array

            int[] array3 = new int[10];
            Random rnd = new Random(); // class for random numbers

            Console.WriteLine();
            for (int i = 0; i < array3.Length; i++)
            {
                array3[i] = rnd.Next(1, 11); // assigns a random number between 1 and 10
                Console.Write(array3[i] + " ");
            }
                        
            // Now we're going to bubble sort it
            Console.WriteLine("\nBubble sorting:\n");
            bool haveSwapped = false;
            int temp;

            for (int i = 0; i < array3.Length; i++)
            {
                haveSwapped = false;
                for (int j = 0; j < (array3.Length - 1); j++)
                {
                    if (array3[j] > array3[j + 1]) // then we swap their values
                    {
                        temp = array3[j];
                        array3[j] = array3[j + 1];
                        array3[j + 1] = temp;
                        haveSwapped = true;
                    }
                }

                if (haveSwapped == false) // then we made no swaps and list is already sorted
                {
                    i = array3.Length;
                }
            }

            foreach(int value in array3)
            {
                Console.Write(value + " ");
            }

            Console.WriteLine();

      /**************************************************************************/

            // Making a two dimensional array, it will hold
            // five arrays of integers of yet to be defined size
            int[][] bigArray = new int[5][];
            

            // iterate through array of integer arrays
            for (int i = 0; i < bigArray.Length; i++)
            {
                bigArray[i] = new int[7]; // Create an array of size 7 to assign to each "row" element
            }

            // Iterate through all rows
            foreach(int[] row in bigArray)
            {
                // Iterate through each value in current row
                for (int i = 0; i < row.Length; i++)
                {
                    row[i] = rnd.Next(1, 11); // Assigns a random number between 1 and 10
                }
            }

            Console.WriteLine("\n");

            // Display table of numbers on console
            foreach(int[] row in bigArray)
            {
                foreach(int element in row)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine();
            }

     /**************************************************************************/

            // Two dimensional bucket sort begins

            Console.WriteLine("\nNow Bucket Sorting:");
            // Each sub-array contains numbers between 1 and 10
            // so we need 10 elements in our count
            int[] numCount = new int[10];
            
            // This tracks our current index for writing in sorted order
            int startIndex = 0;
            bool cont = false;

            // Assign a zero to each element
            for (int i = 0; i < numCount.Length; i++)
            {
                numCount[i] = 0;
            }

            // Iterate through each row
            for (int j = 0; j < bigArray.Length; j++)
            {
                // This will count each time a number is seen in a row
                for (int i = 0; i < bigArray[j].Length; i++)
                {
                    numCount[bigArray[j][i] - 1] += 1;
                }

                // reset our count index
                startIndex = 0;

                // This is for writing new values into our row
                for (int i = 0; i < bigArray[j].Length; i++)
                {
                    cont = false;

                    while (!cont)
                    {
                        // if count of current number is zero, we will increment
                        // until we find a number we have seen in the unsorted row
                        if (numCount[startIndex] == 0)
                        {
                            startIndex += 1;
                        }
                        else
                        {
                            bigArray[j][i] = startIndex + 1;  // Write this value into the array
                            numCount[startIndex] -= 1; // Subtract it from the count of unwritten values
                            cont = true; // we now exit the while loop
                        }
                    }
                }
            }

            // Bucketsort ends

     /**************************************************************************/

            Console.WriteLine("\n");

            // Write new array contents to console
            foreach (int[] row in bigArray)
            {
                foreach (int element in row)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
