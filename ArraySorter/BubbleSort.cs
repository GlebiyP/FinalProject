using System.Collections.Generic;

namespace FinalProject.ArraySorter
{
    public class BubbleSort
    {
        public static int Counter { get; private set; } = 0;
        public static void Sort(List<double> numbers)
        {
            Counter = 0;
            var length = numbers.Count;

            for (int j = 0; j <= length - 2; j++)
            {
                for (int i = 0; i <= length - 2; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        Swapper.Swap(i, i + 1, numbers);
                        Counter++;
                    }
                }
                //length--;
            }
        }
    }
}