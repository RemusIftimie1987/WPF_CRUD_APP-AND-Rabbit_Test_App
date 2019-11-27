using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;


namespace Lab_08_TDD_Collections
{
    class ChallengesDay1_CodeWars
    {
        public static void ExArrManipulation()
        {
            int[] myIntArray = new int[5] { 1, 2, 3, 4, 5 };
            Object[] myObjArray = new Object[5] { 26, 27, 28, 29, 30 };

            //Prints the initial values of both arrays
            Console.WriteLine("Initially,");
            Console.WriteLine("Integer array:");
            printValues(myIntArray);
            Console.WriteLine("Object array: ");
            PrintValues(myObjArray);

            //copies the first two elements from integer array to Object array
            System.Array.Copy(myIntArray, myObjArray, 2);

            //prints the values of the modified array
            Console.WriteLine("\nNew Object array is now: ");
            PrintValues(myObjArray);

            void printValues(int[] myArr)
            {
                foreach (int i in myArr)
                {
                    Console.Write("\t{0}", i);
                }
                Console.WriteLine();
            }
            void PrintValues(Object[] myArr)
            {
                foreach (Object i in myArr)
                {
                    Console.Write("\t{0}", i);
                }
                Console.WriteLine();
            }
        }
        public static void ExMultiDimArrManipulation()
            {
            Array myArr = Array.CreateInstance(typeof(Int32),2,3,4);
            for (int i = myArr.GetLowerBound(0); i <= myArr.GetUpperBound(0); i++)
            {
                for (int j = myArr.GetLowerBound(1); j <= myArr.GetUpperBound(1); j++)
                {
                    for (int k = myArr.GetLowerBound(2); k <= myArr.GetUpperBound(2); k++)
                    {
                        myArr.SetValue((i*100) + (j*10) + k,i,j,k);
                    }
                }
            }
            // Displays the properties of the array
            Console.WriteLine("The Array has {0} dimension(s) and a total of {1} elements", myArr.Rank, myArr.Length);
            Console.WriteLine("\tLength\tLower\tUpper");
            for (int i = 0; i < myArr.Rank; i++)
            {
                Console.Write("{0}:\t{1}", i, myArr.GetLength(i));
                Console.WriteLine("\t{0}\t{1}", myArr.GetLowerBound(i), myArr.GetUpperBound(i));
            }

            //display the content of the array
            Console.WriteLine("The Array contains the following values:");
            PrintValues(myArr);

            void PrintValues(Array myArray)
            {
                System.Collections.IEnumerator myEnumerator = myArray.GetEnumerator();
                int i = 0;
                int cols = myArray.GetLength(myArray.Rank - 1);
                while (myEnumerator.MoveNext())
                {
                    if (i < cols)
                    {
                        i++;
                    }
                    else
                    {
                        Console.WriteLine();
                        i = 1;
                    }
                    Console.Write("\t{0}", myEnumerator.Current);
                }
                Console.WriteLine();
            }
        }

        public static int DuplicateCountOfChars(string str)
        {
            //string str1;
            int i, cnt;

            Console.WriteLine("Enter any sentence: ");
            //str = Console.ReadLine();
            char ch;

            for (ch = (char)65; ch <= 90; ch++)
            {
                cnt = 0;

                for (i = 0; i < str.Length; i++)
                {
                    if (ch == str[i] || (ch + 32) ==str[i])
                    {
                        cnt++;
                    }
                }
            

            if (cnt > 0)
            {
                Console.WriteLine(ch + "=" + cnt);
            }
            }
            Console.ReadLine();
            return -1;
        }
        


    }
}
