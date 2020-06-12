using System;
using System.Collections.Generic;

namespace GameOfLife
{
    //TODO used output classed to keep all strings in one place, and to be able to test variable output is how we expected.
    public static class Output
    {
        private const string LiveCellString = "#";
        private const string DeadCellString = ".";
        public const string Welcome = "Welcome to the Game of Life!";
        public const string PromptForGridLength = "Please specify the grid length: ";
        public const string PromptForGridHeight = "Please specify the grid height: ";
        public const string InvalidDimension = "Invalid input! Please enter a positive integer: ";
        public const string GridHeader = "Current grid: ";
        public const string PromptForCoordsToToggle =
            "Enter coords of cells to activate/deactive in the format `x,y` within the world bounds.";
        public const string PromptForNextCoord =
            "Enter next coord of cell to toggle, or press return to begin simulation: ";
        public const string InvalidCoords = "Invalid coordinates! Correct format is x,y where x,y are positive integers within the grid bounds: ";
        public const string StartingSimulation = "Starting simulation...";
        public const string PromptToProgressTime = "Press return to progress time, or esc to exit: ";

        public static string GridState(GameGrid grid)
        {
            var output = "";
            
            for (var y = 1; y <= grid.Height; y++)
            {
                var row = "";
                for (var x = 1; x <= grid.Length; x++)
                {
                    row += grid.CellIsAliveAtCoords(new[] {x, y}) ? LiveCellString : DeadCellString;
                }
                output += string.Join("\n", row);
                output += "\n";
            }
            return output;
        }
    }
}