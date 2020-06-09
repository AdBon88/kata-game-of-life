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
            coords = Array.ConvertAll(stringCoords, s=> int.TryParse(s, out var coord) ? coord : -1);

            return coordsAreValid(coords, grid);
        }

        private static bool coordsAreValid(int[]coords, GameGrid grid)
        {
            var gridLength = grid.Cells.GetLength(0);
            var gridHeight = grid.Cells.GetLength(1);
            return coords.Length == 2 && coords[0] < gridLength && coords[1] < gridHeight && !coords.Contains(-1);
        }
    }
}