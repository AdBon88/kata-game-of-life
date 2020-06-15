using System.Security.Cryptography.X509Certificates;
using Xunit;

namespace GameOfLife.Tests
{
    public class OutputTests
    {
        [Fact]
        public void outputsGridWithRowAndColumnNumbersAndGridLines()
        {
            var grid = new GameGrid(10,10);
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
            
            var actual = Output.GridStateWithGridLines(grid);
            Assert.Equal(expected, actual);
        }
            
        [Fact]
        public void OutputsEmptyGridForNewGrid()
        {
            var grid = new GameGrid(3,3);
            const string expected = "         \n" + 
                                    "         \n" +
                                    "         \n";
        
            var actual = Output.GridStateWithoutGridLines(grid);
            Assert.Equal(expected, actual);
        }
        
                [Fact]
        private void LiveCellWithLessThan2NeighboursDies()
        {
            var grid = new GameGrid(3,3);
            grid.SetCellAliveAtCoords(new[]{2,1},true);
            grid.SetCellAliveAtCoords(new[]{2,2},true);
            
            //    #    
            //    #    
            //         
            var game = new Game(grid);
            game.ProgressTime();

            const string expected = "         \n" + 
                                    "         \n" +
                                    "         \n";

            var actual = Output.GridStateWithoutGridLines(grid);
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        private void LiveCellWithMoreThanThreeNeighboursDies()
        {
            var grid = new GameGrid(3,3);
            
            // #  #    
            //    #    
            //    #  # 
            grid.SetCellAliveAtCoords(new[]{1,1},true);
            grid.SetCellAliveAtCoords(new[]{2,1},true);
            grid.SetCellAliveAtCoords(new[]{2,2},true);
            grid.SetCellAliveAtCoords(new[]{2,3},true);
            grid.SetCellAliveAtCoords(new[]{3,3},true);
            
            var game = new Game(grid);
            game.ProgressTime();
        
            const string expected = " #  #    \n" + 
                                    "         \n" +
                                    "    #  # \n";
        
            var actual = Output.GridStateWithoutGridLines(grid);
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        private void LiveCellWithTwoOrThreeLivesNeighboursStaysAlive()
        {
            var grid = new GameGrid(3,3);
            
            // #  #    
            // #  #    
            //         
            grid.SetCellAliveAtCoords(new[]{1,1},true);
            grid.SetCellAliveAtCoords(new[]{1,2},true);
            grid.SetCellAliveAtCoords(new[]{2,1},true);
            grid.SetCellAliveAtCoords(new[]{2,2},true);
            
            var game = new Game(grid);
            game.ProgressTime();
            const string expected = " #  #    \n" + 
                                    " #  #    \n" +
                                    "         \n";

            var actual = Output.GridStateWithoutGridLines(grid);
            
            Assert.Equal(expected, actual);
        }
        [Fact]
        private void DeadCellWithThreeLivesNeighboursBecomesAlive()
        {
            var grid = new GameGrid(3,3);
            
            // #  #    
            // #       
            //         
            grid.SetCellAliveAtCoords(new[]{1,1},true);
            grid.SetCellAliveAtCoords(new[]{2,1},true);
            grid.SetCellAliveAtCoords(new[]{1,2},true);
            
            var game = new Game(grid);
            game.ProgressTime();
        
            const string expected = " #  #    \n" + 
                                    " #  #    \n" +
                                    "         \n";
        
            var actual = Output.GridStateWithoutGridLines(grid);
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        private void CorrectOutputWhenApplyingMultipleRulesSimultaneously()
        {
            var grid = new GameGrid(3,3);
            
            // #  #    
            // #  #    
            // #       
            grid.SetCellAliveAtCoords(new[]{1,1},true);
            grid.SetCellAliveAtCoords(new[]{2,1},true);
            grid.SetCellAliveAtCoords(new[]{1,2},true);
            grid.SetCellAliveAtCoords(new[]{2,2},true);
            grid.SetCellAliveAtCoords(new[]{1,3},true);
            
            var game = new Game(grid);
            game.ProgressTime();
        
            const string expected = " #  #    \n" + 
                                    "         \n" +
                                    " #  #    \n";
        
            var actual = Output.GridStateWithoutGridLines(grid);
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        private void AnotherTest()
        {
            var grid = new GameGrid(3,4);
            
            //    #    
            // #     # 
            // #     # 
            grid.SetCellAliveAtCoords(new[]{2,1},true);
            grid.SetCellAliveAtCoords(new[]{1,2},true);
            grid.SetCellAliveAtCoords(new[]{3,2},true);
            grid.SetCellAliveAtCoords(new[]{1,3},true);
            grid.SetCellAliveAtCoords(new[]{3,3},true);
            
            var game = new Game(grid);
            game.ProgressTime();
        
            const string expected = "    #    \n" + 
                                    " #     # \n" +
                                    "         \n" +
                                    "         \n";
        
            var actual = Output.GridStateWithoutGridLines(grid);
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        private void CorrectOutputForXKCDRipJohnConwayPattern()
        {
            var grid = new GameGrid(7,10);
            
            //                     
            //       #  #  #       
            //       #     #         
            //       #     #       
            //          #          
            // #     #  #  #       
            //    #     #     #    
            //          #        # 
            //       #     #       
            //       #     #       
            
            grid.SetCellAliveAtCoords(new[]{3,2},true);
            grid.SetCellAliveAtCoords(new[]{4,2},true);
            grid.SetCellAliveAtCoords(new[]{5,2},true);
            grid.SetCellAliveAtCoords(new[]{3,3},true);
            grid.SetCellAliveAtCoords(new[]{5,3},true);
            grid.SetCellAliveAtCoords(new[]{3,4},true);
            grid.SetCellAliveAtCoords(new[]{5,4},true);
            grid.SetCellAliveAtCoords(new[]{4,5},true);
            grid.SetCellAliveAtCoords(new[]{1,6},true);
            grid.SetCellAliveAtCoords(new[]{3,6},true);
            grid.SetCellAliveAtCoords(new[]{4,6},true);
            grid.SetCellAliveAtCoords(new[]{5,6},true);
            grid.SetCellAliveAtCoords(new[]{2,7},true);
            grid.SetCellAliveAtCoords(new[]{4,7},true);
            grid.SetCellAliveAtCoords(new[]{6,7},true);
            grid.SetCellAliveAtCoords(new[]{4,8},true);
            grid.SetCellAliveAtCoords(new[]{7,8},true);
            grid.SetCellAliveAtCoords(new[]{3,9},true);
            grid.SetCellAliveAtCoords(new[]{5,9},true);
            grid.SetCellAliveAtCoords(new[]{3,10},true);
            grid.SetCellAliveAtCoords(new[]{5,10},true);
            
            var game = new Game(grid);
            game.ProgressTime();
        
            const string expected = "          #          \n" + 
                                    "       #     #       \n" +
                                    "    #  #     #  #    \n" +
                                    "       #     #       \n" +
                                    "    #                \n" +
                                    "    #                \n" +
                                    "    #           #    \n" +
                                    "          #     #    \n" +
                                    "       #     #  #    \n" +
                                    "                     \n";
        
            var actual = Output.GridStateWithoutGridLines(grid);
            
            Assert.Equal(expected, actual);
        }
    }
}