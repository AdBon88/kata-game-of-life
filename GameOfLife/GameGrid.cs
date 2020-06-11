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
        public Cell[,] Cells { get; }
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
        
        public List<int[]> GetNeighbourCoordsOf(int[] cellCoords)
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

            return adjacentCoords.Where(coord => coord[xIndex] > 0 && coord[xIndex] <= Length && 
                                                 coord[yIndex] > 0 && coord[yIndex] <= Height).ToList();
        }
    }
}