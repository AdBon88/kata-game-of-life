using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public static class Output
    {
        private const char LiveCellChar = '#';
        private const char DeadCellChar = '.';

        public const string Welcome = "Welcome to the Game of Life!";
        public const string PromptForGridLength = "Please specify the grid length: ";
        public const string PromptForGridHeight = "Please specify the grid height: ";
        public const string InvalidDimension = "Invalid input! Please enter a positive integer: ";
        public const string GridHeader = "Current grid: ";

        public static string BoardState(GameGrid grid)
        {
            var length = grid.Cells.GetLength(0);
            var height = grid.Cells.GetLength(1);
            var output = "";
            
            for (var y = 1; y <= height; y++)
            {
                var row = "";
                for (var x = 1; x <= length; x++)
                {
                    row += grid.CellIsAliveAtCoords(new[] {x, y}) ? LiveCellChar : DeadCellChar;
                }
                output += string.Join("\n", row);
                output += "\n";
            }
            return output;
        }
    }
}