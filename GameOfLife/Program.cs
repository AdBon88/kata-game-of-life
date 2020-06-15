using System;
using System.ComponentModel.DataAnnotations;

namespace GameOfLife
{
    class Program
    {
        private static GameGrid _grid;
        private static void Main(string[] args)
        {
            Console.WriteLine(Output.Welcome);
            
            Console.Write(Output.PromptForGridLength);
            var length = GetGridDimensionFromUser();
            
            Console.Write(Output.PromptForGridHeight);
            var height = GetGridDimensionFromUser();
            
            _grid = new GameGrid(length, height);
            SetUpGridStartingState();
            
            var game = new Game(_grid);
            StartSimulation(game);
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

        private static void SetUpGridStartingState()
        {
            Console.WriteLine(Output.PromptForCoordsToToggle);
            Console.WriteLine();
            string nextInput;
            do
            {
                nextInput = GetNextCoordsFromUser();
                if (nextInput == "") continue;
                if (InputValidator.TryParseCoords(nextInput, _grid, out var cellCoordToToggle))
                {
                    _grid.ToggleCellLifeStatusAtCoords(cellCoordToToggle);
                }
                else
                {
                    Console.Write(Output.InvalidCoords);
                }

            } while (nextInput != "");
        }

        private static string GetNextCoordsFromUser()
        {
            Console.WriteLine(Output.CurrentGridHeader);
            Console.WriteLine();
            Console.WriteLine(Output.GridState(_grid));
            Console.Write(Output.PromptForNextCoord);
                
            return Console.ReadLine();
        }

        private static void StartSimulation(Game game)
        {
            var cki = new ConsoleKeyInfo();
            Console.WriteLine();
            Console.WriteLine(Output.StartingSimulation);
            while (cki.Key != ConsoleKey.Escape)
            {
                Console.WriteLine(Output.CurrentGridHeader);
                Console.WriteLine(Output.GridState(_grid));
                Console.WriteLine(Output.PromptToProgressTime);
                cki = Console.ReadKey();
                game.ProgressTime();
            }
        }
    }
}
