using Xunit;

namespace GameOfLife.Tests
{
    public class IntegrationTests
    
    {
     [Fact]
        private void LiveCellWithLessThan2NeighboursDies()
        {
            var grid = new Grid(3,3);
            grid.SetCellAliveAtCoords(new[]{2,1});
            grid.SetCellAliveAtCoords(new[]{2,2});
            
            //    #    
            //    #    
            //         
            var game = new Game(grid);
            game.ProgressTime();

            const string expected = "         \n" + 
                                    "         \n" +
                                    "         \n";

            var actual = GridFormatter.OutputWithoutGridLinesAndNumbers(grid);
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        private void LiveCellWithMoreThanThreeNeighboursDies()
        {
            var grid = new Grid(3,3);
            
            // #  #    
            //    #    
            //    #  # 
            grid.SetCellAliveAtCoords(new[]{1,1});
            grid.SetCellAliveAtCoords(new[]{2,1});
            grid.SetCellAliveAtCoords(new[]{2,2});
            grid.SetCellAliveAtCoords(new[]{2,3});
            grid.SetCellAliveAtCoords(new[]{3,3});
            
            var game = new Game(grid);
            game.ProgressTime();
        
            const string expected = " #  #    \n" + 
                                    "         \n" +
                                    "    #  # \n";
        
            var actual = GridFormatter.OutputWithoutGridLinesAndNumbers(grid);
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        private void LiveCellWithTwoOrThreeLivesNeighboursStaysAlive()
        {
            var grid = new Grid(3,3);
            
            // #  #    
            // #  #    
            //         
            grid.SetCellAliveAtCoords(new[]{1,1});
            grid.SetCellAliveAtCoords(new[]{1,2});
            grid.SetCellAliveAtCoords(new[]{2,1});
            grid.SetCellAliveAtCoords(new[]{2,2});
            
            var game = new Game(grid);
            game.ProgressTime();
            const string expected = " #  #    \n" + 
                                    " #  #    \n" +
                                    "         \n";

            var actual = GridFormatter.OutputWithoutGridLinesAndNumbers(grid);
            
            Assert.Equal(expected, actual);
        }
        [Fact]
        private void DeadCellWithThreeLivesNeighboursBecomesAlive()
        {
            var grid = new Grid(3,3);
            
            // #  #    
            // #       
            //         
            grid.SetCellAliveAtCoords(new[]{1,1});
            grid.SetCellAliveAtCoords(new[]{2,1});
            grid.SetCellAliveAtCoords(new[]{1,2});
            
            var game = new Game(grid);
            game.ProgressTime();
        
            const string expected = " #  #    \n" + 
                                    " #  #    \n" +
                                    "         \n";
        
            var actual = GridFormatter.OutputWithoutGridLinesAndNumbers(grid);
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        private void CorrectOutputWhenApplyingAllRulesSimultaneously()
        {
            var grid = new Grid(3,3);
            
            // #  #    
            // #  #    
            // #    #  
            
            grid.SetCellAliveAtCoords(new[]{1,1});
            grid.SetCellAliveAtCoords(new[]{2,1});
            grid.SetCellAliveAtCoords(new[]{1,2});
            grid.SetCellAliveAtCoords(new[]{2,2});
            grid.SetCellAliveAtCoords(new[]{1,3});
            grid.SetCellAliveAtCoords(new[]{3,3});
            
            var game = new Game(grid);
            game.ProgressTime();
        
            const string expected = " #  #    \n" + 
                                    "       # \n" +
                                    " #       \n";
        
            var actual = GridFormatter.OutputWithoutGridLinesAndNumbers(grid);
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        private void CorrectOutputForXKCDRipJohnConwayPattern()
        {
            var grid = new Grid(7,10);
            
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
            
            grid.SetCellAliveAtCoords(new[]{3,2});
            grid.SetCellAliveAtCoords(new[]{4,2});
            grid.SetCellAliveAtCoords(new[]{5,2});
            grid.SetCellAliveAtCoords(new[]{3,3});
            grid.SetCellAliveAtCoords(new[]{5,3});
            grid.SetCellAliveAtCoords(new[]{3,4});
            grid.SetCellAliveAtCoords(new[]{5,4});
            grid.SetCellAliveAtCoords(new[]{4,5});
            grid.SetCellAliveAtCoords(new[]{1,6});
            grid.SetCellAliveAtCoords(new[]{3,6});
            grid.SetCellAliveAtCoords(new[]{4,6});
            grid.SetCellAliveAtCoords(new[]{5,6});
            grid.SetCellAliveAtCoords(new[]{2,7});
            grid.SetCellAliveAtCoords(new[]{4,7});
            grid.SetCellAliveAtCoords(new[]{6,7});
            grid.SetCellAliveAtCoords(new[]{4,8});
            grid.SetCellAliveAtCoords(new[]{7,8});
            grid.SetCellAliveAtCoords(new[]{3,9});
            grid.SetCellAliveAtCoords(new[]{5,9});
            grid.SetCellAliveAtCoords(new[]{3,10});
            grid.SetCellAliveAtCoords(new[]{5,10});
            
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
        
            var actual = GridFormatter.OutputWithoutGridLinesAndNumbers(grid);
            
            Assert.Equal(expected, actual);
        }
    }
}