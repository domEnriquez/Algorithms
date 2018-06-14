using ElementarySorts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortsTiming
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numInts = new int[1000];

            populateArrayFromFile(numInts, @"C:\Users\Boi\Videos\Algorithms\Coursera\3 - Elementary Sorts\Projects\Sorting\1Kints.txt");

            List<AbstractSort<int>> sorts = new List<AbstractSort<int>>();
            populateSorts(sorts);

            foreach(AbstractSort<int> sort in sorts)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                sort.Sort(numInts);
                sw.Stop();

                Console.WriteLine("{0}\t\t\t\t\t{1}", sort.GetSortName(), sw.Elapsed);
            }

            Console.ReadLine();
        }

        private static void populateSorts(List<AbstractSort<int>> sorts)
        {
            sorts.Add(new InsertionSort<int>());
            sorts.Add(new InsertionSortWithoutExchanges<int>());
            sorts.Add(new InsertionSortWithSentinel<int>());
            sorts.Add(new SelectionSort<int>());
            sorts.Add(new ShellSort<int>());
            sorts.Add(new MergeSort<int>());
            sorts.Add(new BottomUpMergeSort<int>());
            sorts.Add(new MergeSortWithFasterMerge<int>());
            sorts.Add(new MergeWithInsertionSort<int>());
            sorts.Add(new MergeSortWithSortedArrayTest<int>());
        }

        private static void populateArrayFromFile(int[] numInts, string fileName)
        {
            StreamReader file = new StreamReader(fileName);
            string line;
            int counter = 0;
            while ((line = file.ReadLine()) != null)
            {
                numInts[counter] = Convert.ToInt32(line.Trim());
                counter++;
            }
            file.Close();
        }
    }
}
