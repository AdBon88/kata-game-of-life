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
            for (var y = 1; y <= _grid.Height; y++)
            {
                for (var x = 1; x <= _grid.Length; x++)
                {
                    var currentCellCoords = new[] {x, y};
                    var neighbourCoords = _grid.GetNeighbourCoordsOf(currentCellCoords);
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
    }
}