using System;

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
    }
}