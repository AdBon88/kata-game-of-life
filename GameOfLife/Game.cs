using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Game
    {
        private readonly Grid _grid;
        public Game(Grid grid)
        {
            _grid = grid;
        }

        public void ProgressTime()
        {
            var gridCopy = _grid.DeepCopy();
            for (var y = 1; y <= _grid.Height; y++)
            {
                for (var x = 1; x <= _grid.Length; x++)
                {
                    var currentCellCoords = new[] {x, y};
                    var neighbourCoords = _grid.FindNeighbourCoordsOf(currentCellCoords);
                    ApplyGameRules(currentCellCoords, neighbourCoords, gridCopy);
                }
            }
        }

        private void ApplyGameRules(int[] currentCellCoords, List<int[]> neighbourCoords, Grid gridCopy)
        {
            
            var liveNeighbourCellCount = neighbourCoords.Count(gridCopy.CellIsAliveAtCoords);
                
            if (gridCopy.CellIsAliveAtCoords(currentCellCoords))
            {
                ApplyRulesForLiveCell(currentCellCoords, liveNeighbourCellCount);
            }
            else
            {
                ApplyRulesForDeadCell(currentCellCoords, liveNeighbourCellCount);
            }
        }

        private void ApplyRulesForLiveCell(int[] currentCellCoords, int liveNeighbourCellCount)
        {
            if (liveNeighbourCellCount < 2 || liveNeighbourCellCount > 3)
                _grid.SetCellDeadAtCoords(currentCellCoords);
        }
        
        private void ApplyRulesForDeadCell(int[] currentCellCoords, int liveNeighbourCellCount)
        {
            if (liveNeighbourCellCount == 3)
                _grid.SetCellAliveAtCoords(currentCellCoords);
        }
    }
}