using Android.App;
using System.Collections.Generic;

namespace FinalProject.ArraySorter
{
    public class InsertionSort
    {
        public static int Counter { get; private set; } = 0;

        public static void Sort(List<double> numbers)
        {
            Counter = 0;
            for (int i = 1; i < numbers.Count; i++)
            {
                var temp = numbers[i];
                var j = i;
                while (j > 0 && temp < numbers[j - 1])
                {
                    numbers[j] = numbers[j - 1];
                    j--;
                    Counter++;
                }
                numbers[j] = temp;
            }
        }
    }
}