using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Grid
    {
        public int Length { get; }
        public int Height { get; }
        public Cell[,] Cells { get; }

        private const int XIndex = 0;
        private const int YIndex = 1;
        
        public Grid(int length, int height)
        {
            Length = length;
            Height = height;
            Cells = new Cell[length,height];
        }

        public void SetCellAliveAtCoords(int[] coords)
        {
            var x = coords[XIndex] - 1;
            var y = coords[YIndex] - 1;
            
            Cells[x, y].IsAlive = true;
        }
        
        public void SetCellDeadAtCoords(int[] coords)
        {
            var x = coords[XIndex] - 1;
            var y = coords[YIndex] - 1;
            
            Cells[x, y].IsAlive = false;
        }

        public bool CellIsAliveAtCoords(int[] coords)
        {
            var x = coords[XIndex] - 1;
            var y = coords[YIndex] - 1;
            return Cells[x, y].IsAlive;
        }

        public void ToggleCellAliveAtCoords(int[] coords)
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
            var neighbourCoordsList = new List<int[]>();

            for (var y = -1; y <= 1; y++)
            {
                for (var x = -1; x <= 1; x++)
                {
                    var isCurrentCellCoords = x == 0 && y == 0;
                    if (isCurrentCellCoords ) continue;
                    var neighbourCoords = new[] {cellCoords[XIndex] + x, cellCoords[YIndex] + y};
                    neighbourCoords = WrapOutOfBoundsCoordinates(neighbourCoords);
                    neighbourCoordsList.Add(neighbourCoords);
                }
            }
            
            return neighbourCoordsList;
        }

        private int[] WrapOutOfBoundsCoordinates(int[] coords)
        {
            const int min = 1;
            
            if (coords[XIndex] < min)
            {
                coords[XIndex] = Length;
            }
            else if (coords[XIndex] > Length)
            {
                coords[XIndex] = min;
            }

            if (coords[YIndex] < min)
            {
                coords[YIndex] = Height;
            }
            else if (coords[YIndex] > Height)
            {
                coords[YIndex] = min;
            }

            return coords;
        }
    }
}