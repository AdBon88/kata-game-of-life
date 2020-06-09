using System;
using System.ComponentModel.DataAnnotations;

namespace GameOfLife
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(Output.Welcome);
            
            Console.Write(Output.PromptForGridLength);
            var length = GetGridDimensionFromUser();
            
            Console.Write(Output.PromptForGridHeight);
            var height = GetGridDimensionFromUser();
            
            var grid = new GameGrid(length, height);
        }

        private static int GetGridDimensionFromUser()
        {
            int dimension;
            while (!InputValidator.TryParseGridDimension(Console.ReadLine(), out dimension))
            {
                Console.WriteLine(Output.InvalidDimension);
            }
            return dimension;
        }

        private static void ToggleActiveStartingCells(GameGrid grid)
        {
            Console.WriteLine(Output.GridHeader);
            Console.WriteLine(Output.GridState(grid));
            Console.Write(Output.PromptForNextCellToToggleActive);
        }
    }
}
