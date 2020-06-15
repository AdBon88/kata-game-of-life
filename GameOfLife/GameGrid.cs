using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;

namespace GameOfLife
{
    public class GameGrid
    {
        public int Length { get; }
        public int Height { get; }
        public Cell[,] Cells { get; } //TODO this is the result of TDD. near the beginning, it was the simplest code to pass the tests. The cost/benefit just wasnt there to remove the array and use say, an iEnumerable and query with linq.
        public GameGrid(int length, int height)
        {
            Length = length;
            Height = height;
            
            Cells = new Cell[length,height];
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < length; x++)
                {
                    Cells[x,y] = new Cell();
                }
            }
        }

        public void SetCellAliveAtCoords(int[] coords, bool isAlive)
        {
            Cells[coords[0] - 1, coords[1] - 1].isAlive = isAlive;
        }

        public bool CellIsAliveAtCoords(int[] coords)
        {
            return Cells[coords[0] - 1, coords[1] - 1].isAlive;
        }

        public void ToggleCellLifeStatusAtCoords(int[] coords)
        {
            SetCellAliveAtCoords(coords, !CellIsAliveAtCoords(coords));
        }

        //TODO needed to be able to copy the method otherwise my Cell Transformer wouldn't work, becuase it loops through all cells,
        // and mutates as it goes, causing subsequent rule applications to not work as they are working with a different grid state on each application.
        public GameGrid DeepCopy()
        {
            var gridCopy = new GameGrid(Length, Height);
            
            //TODO did this loop because I didn't want the entire 2d cell array to have a setter. Otherwise other classes could break the implementation.
            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Length; x++)
                {
                    gridCopy.Cells[x, y] = new Cell {isAlive = Cells[x, y].isAlive};
                }
            }
            return gridCopy;
        }
        
        //TODO decided to put these here. Reason being I want to hide the implementation of how the indexes work from the other classes. Other classes just care about 
        //providing coords and getting a results!
        public List<int[]> FindNeighbourCoordsOf(int[] cellCoords)
        {
            const int xIndex = 0;
            const int yIndex = 1;
            var adjacentCoords = new List<int[]>();

            for (var y = -1; y <= 1; y++)
            {
                for (var x = -1; x <= 1; x++)
                {
                    var isCurrentCellCoords = x == 0 && y == 0;
                    if (isCurrentCellCoords ) continue;
                    adjacentCoords.Add(new[]{cellCoords[xIndex] + x, cellCoords[yIndex] + y});
                }
            }
            
            return adjacentCoords.Where(CoordsAreWithinBounds).ToList();
        }

        //TODO previous loop will generate coords that are off the grid. Need to filter those out!
        private bool CoordsAreWithinBounds(int[] coords)
        {
            const int xIndex = 0;
            const int yIndex = 1;
            
            return coords[xIndex] > 0 && coords[xIndex] <= Length && 
                   coords[yIndex] > 0 && coords[yIndex] <= Height;
        }
    }
}