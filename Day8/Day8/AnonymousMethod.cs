using System;

namespace AnonymousMethod
{
    delegate int Compare(int a, int b);
    class MainApp
    {
        static void BubbleSort(int[] DataSet, Compare Comparer)
        {
            int temp = 0;
            for (int i = 0; i < DataSet.Length - 1; i++) 
            {
                for (int j = 0; j < DataSet.Length - (i + 1); j++) 
                {
                    if(Comparer(DataSet[j], DataSet[j+1]) > 0)
                    {
                        temp = DataSet[j + 1];
                        DataSet[j + 1] = DataSet[j];
                        DataSet[j] = temp;
                    }
                }

            }
        }
        static void Main(string[] args)
        {
            int[] array = { 3, 7, 4, 2, 10 };

            Console.WriteLine("Sorting ascending...");
            BubbleSort(array, 
            delegate (int a, int b)   //익명 메소드
            {
                if (a > b)
                    return 1;
                else if (a == b)
                    return 0;
                else
                    return -1;
            });

            for (int i = 0; i < array.Length; i++)
                Console.Write($"{array[i]} ");

            int[] array2 = { 7, 2, 8, 10, 11 };
            Console.WriteLine("\nSorting descending...");
            BubbleSort(array2,
            delegate (int a, int b)   //익명 메소드
            {
                if (a < b)
                    return 1;
                else if (a == b)
                    return 0;
                else
                    return -1;
            });

            for (int i = 0; i < array.Length; i++)
                Console.Write($"{array2[i]} ");

            Console.WriteLine();
        }
    }
}
