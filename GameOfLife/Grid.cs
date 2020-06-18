using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Grid
    {
        public int Length { get; }
        public int Height { get; }
        public Cell[,] Cells { get; }
        public Grid(int length, int height)
        {
            Length = length;
            Height = height;
            Cells = new Cell[length,height];
        }

        public void SetCellAliveAtCoords(int[] coords)
        {
            Cells[coords[0] - 1, coords[1] - 1].isAlive = true;
        }
        
        public void SetCellDeadAtCoords(int[] coords)
        {
            Cells[coords[0] - 1, coords[1] - 1].isAlive = false;
        }

        public bool CellIsAliveAtCoords(int[] coords)
        {
            return Cells[coords[0] - 1, coords[1] - 1].isAlive;
        }

        public void ToggleCellLifeStatusAtCoords(int[] coords)
        {
            if (CellIsAliveAtCoords(coords))
            {
                SetCellDeadAtCoords(coords);
            }
            else
            {
                SetCellAliveAtCoords(coords);
            }
        }
        
        public Grid DeepCopy()
        {
            var gridCopy = new Grid(Length, Height);
            
            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Length; x++)
                {
                    gridCopy.Cells[x, y] = Cells[x, y];
                }
            }
            return gridCopy;
        }
        
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
        
        private bool CoordsAreWithinBounds(int[] coords)
        {
            const int xIndex = 0;
            const int yIndex = 1;
            
            return coords[xIndex] > 0 && coords[xIndex] <= Length && 
                   coords[yIndex] > 0 && coords[yIndex] <= Height;
        }
    }
}