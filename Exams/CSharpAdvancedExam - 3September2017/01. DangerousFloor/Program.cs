using System;
using System.Linq;

namespace _01._DangerousFloor
{
    class Program
    {
        static char[,] board;
        static void Main(string[] args)
        {
            int row = 8;
            int col = row;
            board = new char[row, col];
            for (int rows = 0; rows < row; rows++)
            {
                var input = Console.ReadLine().Split(",").Select(char.Parse).ToArray();
                for (int cols = 0; cols < col; cols++)
                {
                    board[rows, cols] = input[cols];
                }
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                char piece = command[0];
                int oldRow = int.Parse(command[1].ToString());
                int oldCol = int.Parse(command[2].ToString());
                int newRow = int.Parse(command[4].ToString());
                int newCol = int.Parse(command[5].ToString());

                if (CheckFigure(piece, oldRow, oldCol) == false)
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }
                if (IsMoveValid(piece, oldRow, oldCol, newRow, newCol) == false)
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }
                if (OutOfBoard(newRow, newCol) == false)
                {
                    Console.WriteLine("Move go out of board!");
                    continue;
                }
                board[newRow, newCol] = piece;
                board[oldRow, oldCol] = 'x';
            }
        }

        private static bool OutOfBoard(int newRow, int newCol)
        {
            bool validRow = newRow >= 0 && newRow <= 7;
            bool validCol = newCol >= 0 && newCol <= 7;

            return validRow && validCol;
        }

        private static bool IsMoveValid(char piece, int oldRow, int oldCol, int newRow, int newCol)
        {
            switch (piece)
            {
                case 'P':
                    return ValidPawnMove(oldRow, oldCol, newRow, newCol);
                case 'R':
                    return ValidStraightMove(oldRow, oldCol, newRow, newCol);
                case 'B':
                    return ValidDiagonalMove(oldRow, oldCol, newRow, newCol);
                case 'Q':
                    return ValidStraightMove(oldRow, oldCol, newRow, newCol) ||
                        ValidDiagonalMove(oldRow, oldCol, newRow, newCol);
                case 'K':
                    return ValidKingMove(oldRow, oldCol, newRow, newCol);
                default:
                    throw new Exception();
            }
        }

        private static bool ValidKingMove(int oldRow, int oldCol, int newRow, int newCol)
        {
            bool validRow = Math.Abs(oldRow - newRow) == 1 ||
               Math.Abs(oldRow - newRow) == 0;
            bool validCol = Math.Abs(oldCol - newCol) == 1 ||
                Math.Abs(oldCol - newCol) == 0;

            return validRow && validCol;
        }

        private static bool ValidDiagonalMove(int oldRow, int oldCol, int newRow, int newCol)
        {
            return Math.Abs(oldRow - newRow) == Math.Abs(oldCol - newCol);
        }

        private static bool ValidStraightMove(int oldRow, int oldCol, int newRow, int newCol)
        {
            bool sameRow = oldRow == newRow;
            bool sameCol = oldCol == newCol;
            return sameRow || sameCol;
        }

        private static bool ValidPawnMove(int oldRow, int oldCol, int newRow, int newCol)
        {
            bool ValidColumn = oldCol == newCol;
            bool ValidRow = oldRow - 1 == newRow;
            return ValidColumn && ValidRow;
        }

        private static bool CheckFigure(char piece, int row, int col)
        {
            return board[row, col] == piece;
        }
    }
}
