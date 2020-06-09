using System;
using System.ComponentModel.DataAnnotations;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Output.Welcome);
            Console.WriteLine(Output.PromptForGridLength);
            
            //TODO refactor this so that we take the dimensions with 1 prompt
            int length;
            while (!InputValidator.TryParseGridDimension(Console.ReadLine(), out length))
            {
                Console.WriteLine(Output.InvalidDimension);
            }
            Console.WriteLine(Output.PromptForGridHeight);
            int height;
            while (!InputValidator.TryParseGridDimension(Console.ReadLine(), out height))
            {
                Console.WriteLine(Output.InvalidDimension);
            }
            Console.WriteLine(Output.GeneratingGrid);
        }
    }
}
