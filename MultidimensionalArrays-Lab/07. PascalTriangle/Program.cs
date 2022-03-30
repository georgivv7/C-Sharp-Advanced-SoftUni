using System;

namespace _07._PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            long[][] triangle = new long[height][];

            for (int currentHeight = 0; currentHeight < height; currentHeight++)
            {
                triangle[currentHeight] = new long[currentHeight+1];
                triangle[currentHeight][0] = 1;
                triangle[currentHeight][currentHeight] = 1;
                if (currentHeight >= 2)
                {
                    for (int widthCounter = 1; widthCounter < currentHeight; widthCounter++)
                    {
                        triangle[currentHeight][widthCounter] =
                            triangle[currentHeight - 1][widthCounter - 1] + triangle[currentHeight - 1][widthCounter];
                    }
                }
            }

            for (int i = 0; i < triangle.Length; i++)
            {
                Console.WriteLine(String.Join(" ",triangle[i]));
            }
        }
    }
}
