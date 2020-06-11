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
            var gridCopy = _grid.DeepCopy();
            for (var y = 1; y <= _grid.Height; y++)
            {
                for (var x = 1; x <= _grid.Length; x++)
                {
                    var currentCellCoords = new[] {x, y};
                    var neighbourCoords = _grid.FindNeighbourCoordsOf(currentCellCoords);
                    ApplyRules(currentCellCoords, neighbourCoords, gridCopy);
                }
            }
        }

        private void ApplyRules(int[] currentCellCoords, List<int[]> neighbourCoords, GameGrid gridCopy)
        {
            
            var liveNeighbourCellCount = neighbourCoords.Count(gridCopy.CellIsAliveAtCoords);
                
            if (gridCopy.CellIsAliveAtCoords(currentCellCoords))
            {
                if (liveNeighbourCellCount < 2 || liveNeighbourCellCount > 3)
                    _grid.SetCellAliveAtCoords(currentCellCoords, false);
            }
            else
            {
                if(liveNeighbourCellCount == 3)
                    _grid.SetCellAliveAtCoords(currentCellCoords, true);
            }
        }
    }
}