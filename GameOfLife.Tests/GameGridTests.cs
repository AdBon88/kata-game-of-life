using System;
using System.Collections.Generic;
using Xunit;

namespace GameOfLife.Tests
{
    public class GameGridTests
    {
        [Fact]
        public void GeneratesGridOfSpecifiedLengthAndWidth()
        {
            var grid = new Grid(3,4);

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
            var grid = new Grid(3,3);

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
            var grid = new Grid(3,3);
            Assert.False(grid.CellIsAliveAtCoords(new []{3,3}));
        }
        
        [Fact]
        public void CanSetCellAsAliveAtGivenCoords()
        {
            var grid = new Grid(3,3);
            grid.SetCellAliveAtCoords(new[] {2, 2});
            Assert.True(grid.CellIsAliveAtCoords(new[]{2,2}));
        }
        
        [Fact]
        public void CanSetCellAsDeadAtGivenCoords()
        {
            var grid = new Grid(3,3);
            grid.SetCellDeadAtCoords(new[] {2, 2});
            Assert.False(grid.CellIsAliveAtCoords(new[]{2,2}));
        }
        
        [Fact]
        public void CanToggleCellAliveOrDeadAtGivenCoords()
        {
            var grid = new Grid(3,3);
            grid.ToggleCellLifeStatusAtCoords(new[] {2, 2});
            Assert.True(grid.CellIsAliveAtCoords(new[]{2,2}));
            grid.ToggleCellLifeStatusAtCoords(new[] {2, 2});
            Assert.False(grid.CellIsAliveAtCoords(new[]{2,2}));
        }

        [Fact]
        public void CanMakeDeepCopyOfGrid()
        {
            var grid = new Grid(2,2);
            grid.SetCellAliveAtCoords(new[]{2,2});
            var gridCopy = grid.DeepCopy();
           
            var gridContent = new[] {grid.Cells[0, 0], grid.Cells[0, 1], grid.Cells[1, 0], grid.Cells[1, 1]};
            var gridCopyContent = new[] {gridCopy.Cells[0, 0], gridCopy.Cells[0, 1], gridCopy.Cells[1, 0], gridCopy.Cells[1, 1]};
            
            Assert.Equal(gridContent, gridCopyContent);
            Assert.NotEqual(grid, gridCopy);
        }

        [Fact]
        public void ShouldFindNeighbourCoordsOfGivenCoords_WhereCoordIsOnBoundary()
        {
            var grid = new Grid(3,3);

            var expected = new List<int[]> {new[]{2,2}, new []{3,2}, new []{2,3}};
            var actual = grid.FindNeighbourCoordsOf(new[] {3, 3});

            Assert.Equal(expected, actual);

        }
        
        [Fact]
        public void ShouldFindNeighbourCoordsOfGivenCoords_WhereGivenCoordsNotOnBoundary()
        {
            var grid = new Grid(3,3);

            var expected = new List<int[]> {new[]{1,1}, new []{2,1}, new []{3,1}, new[]{1,2}, 
                new[]{3,2}, new []{1,3}, new[]{2,3}, new[]{3,3}};
            
            var actual = grid.FindNeighbourCoordsOf(new[] {2, 2});
            
            Assert.Equal(expected, actual);

        }
    }
}
