using System;
using System.Collections.Generic;
using System.Threading;

namespace GameOfLife
{
    public static class Output
    {
        public const string Welcome = "Welcome to the Game of Life!";
        public const string PromptForGridLength = "Please specify the grid length (max 40): ";
        public const string PromptForGridHeight = "Please specify the grid height: (max 40): ";
        public const string InvalidDimension = "Invalid input! Please enter a positive integer (max 40): ";
        public const string CurrentGridHeader = "Current grid: ";
        public const string PromptForCoordsToToggle =
            "Enter coords of cells to activate/deactive in the format `x,y` within the grid bounds:";
        public const string PromptForNextCoord =
            "Enter next coord of cell to toggle, or press return to begin simulation: ";
        public const string InvalidCoords = "Invalid coordinates! Correct format is x,y where x,y are positive integers within the grid bounds: ";
        public const string StartingSimulation = "Starting simulation...";
        public const string PromptToProgressTime = "Press return to progress time, or esc to exit: ";
    }
}