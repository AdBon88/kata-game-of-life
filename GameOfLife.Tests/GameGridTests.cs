using System;
using Xunit;

namespace GameOfLife.Tests
{
    public class GameGridTests
    {
        [Fact]
        public void GeneratesGridOfSpecifiedLengthAndWidth()
        {
            var grid = new GameGrid(3,4);

            const int expectedLength = 3;
            const int expectedHeight = 4;
            
            var actualLength = grid.Cells.GetLength(0);
            var actualHeight = grid.Cells.GetLength(1);

            Assert.Equal(expectedLength, actualLength);
            Assert.Equal(expectedHeight, actualHeight);
        }
        
        [Fact]
        public void AllCellsAreInactiveWhenGridFirstInitialised()
        {
            var grid = new GameGrid(3,3);

            var aCellIsAlive = false;         
            foreach (var cell in grid.Cells)
            {
                aCellIsAlive = cell.isAlive;
            }
            Assert.False(aCellIsAlive);
        }

        [Fact]
        public void CanGetCellIsActiveAtGivenCoords()
        {
            var grid = new GameGrid(3,3);
            Assert.False(grid.CellIsAliveAtCoords(new []{3,3}));
        }
        
        [Fact]
        public void CanSetCellAsAliveAtGivenCoords()
        {
            var grid = new GameGrid(3,3);
            grid.SetCellAliveAtCoords(new[] {2, 2}, true);
            Assert.True(grid.CellIsAliveAtCoords(new[]{2,2}));
        }
        
        [Fact]
        public void CanToggleCellAliveOrDeadAtGivenCoords()
        {
            var grid = new GameGrid(3,3);
            grid.ToggleCellLifeStatusAtCoords(new[] {2, 2});
            Assert.True(grid.CellIsAliveAtCoords(new[]{2,2}));
            grid.ToggleCellLifeStatusAtCoords(new[] {2, 2});
            Assert.False(grid.CellIsAliveAtCoords(new[]{2,2}));
        }
    }
}
