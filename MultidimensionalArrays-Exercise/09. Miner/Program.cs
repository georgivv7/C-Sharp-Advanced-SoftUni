using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            char[,] field = new char[fieldSize, fieldSize];
            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int startingRow = 0;
            int startingCol = 0;
            int totalCoals = 0;
            for (int rows = 0; rows < fieldSize; rows++)
            {
                var fieldData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                for (int columns = 0; columns < fieldSize; columns++)
                {
                    field[rows, columns] = fieldData[columns];
                    if (field[rows, columns] == 's')
                    {
                        startingRow = rows;
                        startingCol = columns;
                    }
                    else if (field[rows, columns] == 'c')
                    {
                        totalCoals++;
                    }
                }
            }
            foreach (var command in commands)
            {
                int rowIndex = startingRow;
                int colIndex = startingCol;
                switch (command)
                {
                    case "up":
                        rowIndex--;
                        break;
                    case "down":
                        rowIndex++;
                        break;
                    case "left":
                        colIndex--;
                        break;
                    case "right":
                        colIndex++;
                        break;
                }
                if (rowIndex < 0 || rowIndex >= fieldSize || colIndex < 0 || colIndex >= fieldSize)
                {
                    continue;
                }
                startingRow = rowIndex;
                startingCol = colIndex;
                switch (field[rowIndex, colIndex])
                {
                    case 'e':
                        Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
                        Environment.Exit(0);
                        break;
                    case 'c':
                        totalCoals--;
                        field[rowIndex, colIndex] = '*';
                        break;
                }
            }
            if (totalCoals == 0)
            {
                Console.WriteLine($"You collected all coals! ({startingRow}, {startingCol})");
            }
            else
            {
                Console.WriteLine($"{totalCoals} coals left. ({startingRow}, {startingCol})");
            }
        }
    }
}
