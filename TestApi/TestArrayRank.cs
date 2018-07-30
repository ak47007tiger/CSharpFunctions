using System;

namespace UseCSharp
{
    public class TestArrayRank
    {
        public void Test2RankArray()
        {
            int[][] arrays = new int[3][];
            arrays[0] = new int[1];
            arrays[1] = new int[2];
            arrays[2] = new int[3];

            Console.WriteLine(arrays.Length);
            Console.WriteLine(arrays.Rank);
            Console.ReadKey();
            Console.WriteLine(arrays.GetLength(arrays.Rank - 1));
        }

        public void TestFix2RandArray()
        {
            int[,] arrays = new int[3, 5];
            Console.WriteLine(arrays.Rank);
            Console.WriteLine(arrays.Length);
            Console.WriteLine(arrays.GetLength(0));
            Console.WriteLine(arrays.GetLength(1));
            Console.WriteLine(arrays.Length / arrays.Rank);
        }
    }
}
