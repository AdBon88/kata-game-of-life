using System;
using System.Linq;

namespace GameOfLife
{
    public static class InputValidator
    {
        public static bool TryParseGridDimension(string input, out int dimension)
        {
            if (int.TryParse(input, out var output) && output > 0)
            {
                dimension = output;
                return true;
            }
            dimension = 0;
            return false;
        }

        public static bool TryParseCoords(string input, GameGrid grid, out int[] coords)
        {
            var stringCoords = input.Split(',');
           
            coords = Array.ConvertAll(stringCoords, stringNum=> int.TryParse(stringNum, out var coord) ? coord : -1);
            
            if (coordsAreValid(coords, grid))
            {
                return true;
            }
            coords = new[] {-1};
            return false;
        }

        private static bool coordsAreValid(int[]coords, GameGrid grid)
        {
            var gridLength = grid.Cells.GetLength(0);
            var gridHeight = grid.Cells.GetLength(1);
            
            var hasCountOfTwo = coords.Length == 2;
            var areGreaterThanZero = coords.All(i => i > 0);
            bool areWithinBounds;
            
            if (hasCountOfTwo)
            {
                areWithinBounds = coords[0] <= gridLength && coords[1] <= gridHeight;
            }
            else
            {
                areWithinBounds = false;
            }

            return hasCountOfTwo && areGreaterThanZero && areWithinBounds;
        }
    }
}