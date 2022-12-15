using System.Collections.Generic;
using System.Linq;

namespace FinalProject.ArraySorter
{
    public class MergeSort
    {
        public static int Counter { get; private set; } = 0;

        public static List<double> Sort(List<double> numbers)
        {
            Counter = 0;
            numbers = MakeSort(numbers);
            return numbers;
        }

        private static List<double> MakeSort(List<double> numbers)
        {
            if (numbers.Count == 1)
            {
                return numbers;
            }

            var mid = numbers.Count / 2;
            var left = numbers.Take(mid).ToList();
            var right = numbers.Skip(mid).ToList();

            return Merge(MakeSort(left), MakeSort(right));
        }

        private static List<double> Merge(List<double> left, List<double> right)
        {
            var length = left.Count + right.Count;
            var leftPointer = 0;
            var rightPointer = 0;

            var result = new List<double>();

            for (int i = 0; i < length; i++)
            {
                if (leftPointer < left.Count && rightPointer < right.Count)
                {
                    if (left[leftPointer] < right[rightPointer])
                    {
                        result.Add(left[leftPointer]);
                        leftPointer++;
                        Counter++;
                    }
                    else
                    {
                        result.Add(right[rightPointer]);
                        rightPointer++;
                        Counter++;
                    }
                }
                else
                {
                    if (rightPointer < right.Count)
                    {
                        result.Add(right[rightPointer]);
                        rightPointer++;
                    }
                    else
                    {
                        result.Add(left[leftPointer]);
                        leftPointer++;
                    }
                }
            }
            return result;
        }
    }
}