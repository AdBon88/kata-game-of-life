using System.Security.Cryptography.X509Certificates;
using Xunit;

namespace GameOfLife.Tests
{
    public class OutputTests
    {
        [Theory]
        [InlineData(new []{1,1}, "#..\n...\n...\n")]
        [InlineData(new []{2,2}, "...\n.#.\n...\n")]
        [InlineData(new []{3,3}, "...\n...\n..#\n")]
        [InlineData(new []{3,2}, "...\n..#\n...\n")]
        public void OutputsBoardStateAsString(int[] cellCoords, string expectedOutput)
        {
            var grid = new GameGrid(3,3);
            grid.SetCellAliveAtCoords(cellCoords, true);
        
            var actual = Output.BoardState(grid);
            Assert.Equal(expectedOutput, actual);
        }
    }
}