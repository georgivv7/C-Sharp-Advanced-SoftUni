using System;

namespace _07._KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int columns = rows;
            char[,] field = new char[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine();
                for (int col = 0; col < columns; col++)
                {
                    field[row, col] = input[col];
                }
            }
            int numRemovedKnights = 0;
            while (true)
            {
                int maxAttackedKnights = int.MinValue;
                int rowMax = int.MinValue;
                int colMax = int.MinValue;
                int attackedKnights = 0;
                for (int row = 0; row < field.GetLength(0); row++)
                {
                    for (int col = 0; col < field.GetLength(1); col++)
                    {
                        if (field[row, col] == 'K')
                        {
                            if (row + 1 >= 0 && row + 1 < field.GetLength(0) && col + 2 >= 0 && col + 2 < field.GetLength(1))
                            {
                                if (field[row + 1, col + 2] == 'K')
                                {
                                    attackedKnights++;
                                }
                            }
                            if (row - 1 >= 0 && row - 1 < field.GetLength(0) && col + 2 >= 0 && col + 2 < field.GetLength(1))
                            {
                                if (field[row - 1, col + 2] == 'K')
                                {
                                    attackedKnights++;
                                }
                            }
                            if (row + 1 >= 0 && row + 1 < field.GetLength(0) && col - 2 >= 0 && col - 2 < field.GetLength(1))
                            {
                                if (field[row + 1, col - 2] == 'K')
                                {
                                    attackedKnights++;
                                }
                            }
                            if (row - 1 >= 0 && row - 1 < field.GetLength(0) && col - 2 >= 0 && col - 2 < field.GetLength(1))
                            {
                                if (field[row - 1, col - 2] == 'K')
                                {
                                    attackedKnights++;
                                }
                            }
                            if (row + 2 >= 0 && row + 2 < field.GetLength(0) && col + 1 >= 0 && col + 1 < field.GetLength(1))
                            {
                                if (field[row + 2, col + 1] == 'K')
                                {
                                    attackedKnights++;
                                }
                            }
                            if (row + 2 >= 0 && row + 2 < field.GetLength(0) && col - 1 >= 0 && col - 1 < field.GetLength(1))
                            {
                                if (field[row + 2, col - 1] == 'K')
                                {
                                    attackedKnights++;
                                }
                            }
                            if (row - 1 >= 0 && row - 1 < field.GetLength(0) && col + 2 >= 0 && col + 2 < field.GetLength(1))
                            {
                                if (field[row - 1, col + 2] == 'K')
                                {
                                    attackedKnights++;
                                }
                            }
                            if (row - 2 >= 0 && row - 2 < field.GetLength(0) && col + 1 >= 0 && col + 1 < field.GetLength(1))
                            {
                                if (field[row - 2, col + 1] == 'K')
                                {
                                    attackedKnights++;
                                }
                            }
                            if (row - 2 >= 0 && row - 2 < field.GetLength(0) && col - 1 >= 0 && col - 2 < field.GetLength(1))
                            {
                                if (field[row - 2, col - 1] == 'K')
                                {
                                    attackedKnights++;
                                }
                            }
                        }
                        if (attackedKnights > maxAttackedKnights)
                        {
                            maxAttackedKnights = attackedKnights;
                            rowMax = row;
                            colMax = col;
                        }
                        attackedKnights = 0;
                    }
                }
                if (maxAttackedKnights != 0)
                {
                    field[rowMax, colMax] = '0';
                    numRemovedKnights++;
                    maxAttackedKnights = 0;
                }
                else if (maxAttackedKnights == 0)
                {
                    break;
                }
            }
            Console.WriteLine(numRemovedKnights);
        }
    }
}
