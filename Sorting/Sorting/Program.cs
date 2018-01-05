using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            p.Run();
        }

        public void Run()
        {
            var listToSort = new List<int> { 5, 23, 542, 11, 21, 1, 12 ,541, 542};
            Console.WriteLine("Selection sort:");
            PrintList(SelectionSort(listToSort));

            var listToSort2 = new List<int> { 5, 13, 54, 1, 121, 1, 12, 11,12 };
            Console.WriteLine("Insertion sort:");
            PrintList(InsertionSort(listToSort2));

            var listToSort3 = new List<int> {1, 2, 3, 4, 12, 421, 2342, 53453, 666};
            Console.WriteLine("Merge sort");
            PrintList(MergeSort(listToSort3));

            //RUN TIMED TESTS
            var massiveList = new List<int>();
            var massiverList = new List<int>();
            var random = new Random();
            for (int i = 0; i < 30000; i++)
            {
                massiverList.Add(random.Next(1000));
                if (i % 2 == 0)
                {
                    massiveList.Add(random.Next(1000));
                }
            }
            Console.WriteLine("Selection Sort Time Test:");
            var time = Stopwatch.StartNew();
            Console.WriteLine("GO!");
            SelectionSort(massiveList);
            Console.WriteLine(time.Elapsed);
            time = Stopwatch.StartNew();
            Console.WriteLine("GO!");
            SelectionSort(massiverList);
            Console.WriteLine(time.Elapsed);

            Console.WriteLine("Insertion Sort Time Test:");
            time = Stopwatch.StartNew();
            Console.WriteLine("GO!");
            InsertionSort(massiveList);
            Console.WriteLine(time.Elapsed);
            time = Stopwatch.StartNew();
            Console.WriteLine("GO!");
            InsertionSort(massiverList);
            Console.WriteLine(time.Elapsed);

            Console.WriteLine("Merge Sort Time Test:");
            time = Stopwatch.StartNew();
            Console.WriteLine("GO!");
            MergeSort(massiveList);
            Console.WriteLine(time.Elapsed);
            time = Stopwatch.StartNew();
            Console.WriteLine("GO!");
            MergeSort(massiverList);
            Console.WriteLine(time.Elapsed);


        }

        public List<int> SelectionSort(List<int> list)
        {
            for (int startingValue = 0; startingValue < list.Count; startingValue++)
            {
                var indexOfSmallest = startingValue;
                for (int i = startingValue; i < list.Count; i++)
                {
                    if (list[i] < list[indexOfSmallest])
                    {
                        indexOfSmallest = i;
                    }
                }
                var temp = list[indexOfSmallest];
                list[indexOfSmallest] = list[startingValue];
                list[startingValue] = temp;
            }
            return list;
        }

        public List<int> InsertionSort(List<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                var firstSmallerElement = -1;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (list[i] >= list[j])
                    {
                        firstSmallerElement = j;
                        break;
                    }
                }
                if (firstSmallerElement + 1 != i)
                {
                    var temp = list[i];
                    list.RemoveAt(i);
                    list.Insert(firstSmallerElement + 1, temp);
                }
            }
            return list;
        }

        public List<int> MergeSort(List<int> list)
        {
            //Split into lists
            //Sort those
            //Merge

            if (list.Count == 1)
            {
                return list;
            }

            var left = list.Take(list.Count / 2).ToList();
            var right = list.Skip(list.Count / 2).ToList();

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left,right);
        }

        public List<int> Merge(List<int> left, List<int> right)
        {
            var total = new List<int>();
            while (left.Count > 0 && right.Count > 0)
            {
                while (left[0] <= right[0])
                {
                    total.Add(left[0]);
                    left.RemoveAt(0);
                    if (left.Count == 0)
                    {
                        total.AddRange(right);
                        break;
                    }
                }
                if (left.Count == 0) break;
                while (right[0] <= left[0])
                {
                    total.Add(right[0]);
                    right.RemoveAt(0);
                    if (right.Count== 0)
                    {
                        total.AddRange(left);
                        break;
                    }
                }
            }
            return total;
        }

        public void PrintList(List<int> list)
        {
            for(int i=0;i<list.Count;i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
