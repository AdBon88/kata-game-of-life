using Xunit;

namespace GameOfLife.Tests
{
    public class GridFormatterTests
    {
        [Fact]
        public void outputsGridWithRowAndColumnNumbersAndGridLines()
        {
            var grid = new Grid(10,10);
            const string expected = "     1  2  3  4  5  6  7  8  9 10 (x)\n" +
                                    "  1  .  .  .  .  .  .  .  .  .  . \n" +
                                    "  2  .  .  .  .  .  .  .  .  .  . \n" +
                                    "  3  .  .  .  .  .  .  .  .  .  . \n" +
                                    "  4  .  .  .  .  .  .  .  .  .  . \n" +
                                    "  5  .  .  .  .  .  .  .  .  .  . \n" +
                                    "  6  .  .  .  .  .  .  .  .  .  . \n" +
                                    "  7  .  .  .  .  .  .  .  .  .  . \n" +
                                    "  8  .  .  .  .  .  .  .  .  .  . \n" +
                                    "  9  .  .  .  .  .  .  .  .  .  . \n" +
                                    " 10  .  .  .  .  .  .  .  .  .  . \n" + 
                                    "(y)";
            
            var actual = GridFormatter.OutputWithGridLinesAndNumbers(grid);
            Assert.Equal(expected, actual);
        }
            
        [Fact]
        public void OutputsEmptyGridForNewGrid()
        {
            var grid = new Grid(3,3);
            const string expected = "         \n" + 
                                    "         \n" +
                                    "         \n";
        
            var actual = GridFormatter.OutputWithoutGridLinesAndNumbers(grid);
            Assert.Equal(expected, actual);
        }
    }
}