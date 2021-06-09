using System;

namespace HackerRank
{
    public class PrintNum1to100NoLoop
    {
        private void printNumbersFizzBuzz(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }

        }

        private void mySort(int[] a)
        {
            for (int i = 0; i <= a.Length; i++)
                for (int j = i; j > 0; j--)
                    if (a[j] < a[j-1])
                    {
                        int temp = a[j];
                        a[j] = a[j-1];
                        a[j-1] = temp;
                    }
                    else
                    {
                        break;
                    }
        }
    }


}
