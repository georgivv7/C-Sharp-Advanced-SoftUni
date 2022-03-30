using System;
using System.Linq;

namespace _02._ParkingFeud
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            
            int rows = rowsAndCols[0] * 2 - 1;
            int cols =rowsAndCols[1] + 2;
            int entrance = int.Parse(Console.ReadLine());
        }
    }
}
