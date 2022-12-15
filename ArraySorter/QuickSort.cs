using System.Collections.Generic;

namespace FinalProject.ArraySorter
{
    public class QuickSort
    {
        public static int Counter { get; private set; } = 0;
        public static void Sort(List<double> numbers)
        {
            Counter = 0;
            MakeSort(numbers, 0, numbers.Count - 1);
        }
        private static void MakeSort(List<double> numbers, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            var pivot = Quick(numbers, left, right);
            MakeSort(numbers, left, pivot - 1);
            MakeSort(numbers, pivot + 1, right);
        }
        private static int Quick(List<double> numbers, int left, int right)
        {
            var pointer = left;
            for (int i = left; i <= right; i++)
            {
                if (numbers[i] < numbers[right])
                {
                    Swapper.Swap(pointer, i, numbers);
                    pointer++;
                    Counter++;
                }
            }

            Swapper.Swap(pointer, right, numbers);
            Counter++;
            return pointer;
        }
    }
}