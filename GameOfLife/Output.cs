using System;
using System.Collections.Generic;
using System.Threading;

namespace GameOfLife
{
    //TODO used output classed to keep all strings in one place, and to be able to test variable output is how we expected.
    public static class Output
    {
        private const string LiveCell = " # ";
        private const string DeadCell = " . ";

        public const string Welcome = "Welcome to the Game of Life!";
        public const string PromptForGridLength = "Please specify the grid length (max 40): ";
        public const string PromptForGridHeight = "Please specify the grid height: (max 40): ";
        public const string InvalidDimension = "Invalid input! Please enter a positive integer (max 40): ";
        public const string CurrentGridHeader = "Current grid: ";
        public const string PromptForCoordsToToggle =
            "Enter coords of cells to activate/deactive in the format `x,y` within the world bounds.";
        public const string PromptForNextCoord =
            "Enter next coord of cell to toggle, or press return to begin simulation: ";
        public const string InvalidCoords = "Invalid coordinates! Correct format is x,y where x,y are positive integers within the grid bounds: ";
        public const string StartingSimulation = "Starting simulation...";
        public const string PromptToProgressTime = "Press return to progress time, or esc to exit: ";

        public static string GridState(GameGrid grid)
        {
            var gridOutput = AppendColumnNumbers(grid.Length);
            gridOutput += AppendRows(grid);

            return gridOutput;
        }

        private static string AppendColumnNumbers(int gridLength)
        {
            var columnHeader = "    ";
            for (var x = 1; x <= gridLength; x++)
            {
                //less white space needed for single digits
                columnHeader += x < 10 ? $" {x} " : $"{x} ";
            }
            return columnHeader + "(x)\n";
        }
        
        private static string AppendRows(GameGrid grid)
        {
            var rows = "";

            for (var rowNo = 1; rowNo <= grid.Height; rowNo++)
            {
                rows += AppendRowNumber(rowNo) + AppendColumns(rowNo, grid);
            } 
            return rows +"(y)";
        }

        private static string AppendRowNumber(int RowNo)
        {
            //less white space needed for single digits
            return RowNo < 10 ? $"  {RowNo} " : $" {RowNo} ";
        }

        private static string AppendColumns(int rowNo, GameGrid grid)
        {
            var rowContents = "";
            for (var colNo = 1; colNo <= grid.Length; colNo++)
            {
                rowContents += grid.CellIsAliveAtCoords(new[] {colNo, rowNo}) ? LiveCell : DeadCell;
            }

            return rowContents + "\n";
        }
    }
}