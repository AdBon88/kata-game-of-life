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
            SetUpGridStartingState(grid);
            
            var game = new Game(grid);
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

        private static void SetUpGridStartingState(GameGrid grid)
        {
            Console.WriteLine(Output.PromptForCoordsToToggle);
            Console.WriteLine();
            string nextInput;
            do
            {
                nextInput = getNextCoordsFromUser(grid);
                if (nextInput == "") continue;
                if (InputValidator.TryParseCoords(nextInput, grid, out var cellCoordToToggle))
                {
                    grid.ToggleCellLifeStatusAtCoords(cellCoordToToggle);
                }
                else
                {
                    Console.Write(Output.InvalidCoords);
                }

            } while (nextInput != "");
        }

        private static string getNextCoordsFromUser(GameGrid grid)
        {
            Console.WriteLine(Output.GridHeader);
            Console.WriteLine();
            Console.WriteLine(Output.GridState(grid));
            Console.Write(Output.PromptForNextCoord);
                
            return Console.ReadLine();
        }
    }
}
