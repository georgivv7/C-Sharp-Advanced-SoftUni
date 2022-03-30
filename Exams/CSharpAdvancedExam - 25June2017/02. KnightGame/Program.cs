using System;

namespace _02._KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int columns = rows;
            char[,] board = new char[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine();
                for (int col = 0; col < columns; col++)
                {
                    board[row, col] = input[col];
                }
            }
            int removedknights = 0;
            while (true)
            {
                int attackedKnights = 0;
                int mostAttacks = 0;
                int rowAttacker = 0;
                int colAttacker = 0;
                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        if (board[row, col] == 'K')
                        {
                            if (row - 1 >= 0 && row - 1 < board.GetLength(0)
                                && col - 2 >= 0 && col - 2 < board.GetLength(1))
                            {
                                if (board[row - 1, col - 2] == 'K')
                                {
                                    attackedKnights++;
                                }
                            }
                            if (row - 1 >= 0 && row - 1 < board.GetLength(0)
                                && col + 2 >= 0 && col + 2 < board.GetLength(1))
                            {
                                if (board[row - 1, col + 2] == 'K')
                                {
                                    attackedKnights++;
                                }
                            }
                            if (row + 1 >= 0 && row + 1 < board.GetLength(0)
                                && col - 2 >= 0 && col - 2 < board.GetLength(1))
                            {
                                if (board[row + 1, col - 2] == 'K')
                                {
                                    attackedKnights++;
                                }
                            }
                            if (row + 1 >= 0 && row + 1 < board.GetLength(0)
                                && col + 2 >= 0 && col + 2 < board.GetLength(1))
                            {
                                if (board[row + 1, col + 2] == 'K')
                                {
                                    attackedKnights++;
                                }
                            }
                            if (row - 2 >= 0 && row - 2 < board.GetLength(0)
                                && col - 1 >= 0 && col - 1 < board.GetLength(1))
                            {
                                if (board[row - 2, col - 1] == 'K')
                                {
                                    attackedKnights++;
                                }
                            }
                            if (row - 2 >= 0 && row - 2 < board.GetLength(0)
                                && col + 1 >= 0 && col + 1 < board.GetLength(1))
                            {
                                if (board[row - 2, col + 1] == 'K')
                                {
                                    attackedKnights++;
                                }
                            }
                            if (row + 2 >= 0 && row + 2 < board.GetLength(0)
                                && col - 1 >= 0 && col - 1 < board.GetLength(1))
                            {
                                if (board[row + 2, col - 1] == 'K')
                                {
                                    attackedKnights++;
                                }
                            }
                            if (row + 2 >= 0 && row + 2 < board.GetLength(0)
                                && col + 1 >= 0 && col + 1 < board.GetLength(1))
                            {
                                if (board[row + 2, col + 1] == 'K')
                                {
                                    attackedKnights++;
                                }
                            }
                        }
                        if (attackedKnights > mostAttacks)
                        {
                            mostAttacks = attackedKnights;
                            rowAttacker = row;
                            colAttacker = col;
                        }
                        attackedKnights = 0;
                    }
                }

                if (mostAttacks != 0)
                {
                    board[rowAttacker, colAttacker] = '0';
                    removedknights++;
                    mostAttacks = 0;
                }
                else if (mostAttacks == 0)
                {
                    break;
                }

            }

            Console.WriteLine(removedknights);
        }
    }
}
