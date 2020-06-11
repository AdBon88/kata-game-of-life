using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Game
    {
        private GameGrid _grid;
        public Game(GameGrid grid)
        {
            _grid = grid;
        }

        public void ProgressTime()
        {
           // var gridCopy = _
            for (var y = 1; y <= _grid.Height; y++)
            {
                for (var x = 1; x <= _grid.Length; x++)
                {
                    var currentCellCoords = new[] {x, y};
                    var neighbourCoords = FindNeighbourCoordsOf(currentCellCoords);
                    ApplyRules(currentCellCoords, neighbourCoords);
                }
            }
        }

        private void ApplyRules(int[] currentCellCoords, List<int[]> neighbourCoords)
        {
            var liveNeighbourCellCount = neighbourCoords.Count(coord => _grid.CellIsAliveAtCoords(coord));

            if (_grid.CellIsAliveAtCoords(currentCellCoords))
            {
                if (liveNeighbourCellCount < 2)
                    _grid.SetCellAliveAtCoords(currentCellCoords, false);
            }
            else
            {
                if(liveNeighbourCellCount == 3)
                    _grid.SetCellAliveAtCoords(currentCellCoords, true);
            }
        }

        private List<int[]> FindNeighbourCoordsOf(int[] cellCoords)
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
            
            return coords[xIndex] > 0 && coords[xIndex] <= _grid.Length && 
                   coords[yIndex] > 0 && coords[yIndex] <= _grid.Height;
        }
    }
}