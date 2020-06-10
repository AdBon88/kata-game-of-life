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
                    var neighbourCoords = GetNeighbourCoords(currentCellCoords);
                    ApplyRules(currentCellCoords, neighbourCoords);
                }
            }
        }

        private void ApplyRules(int[] currentCellCoords, List<int[]> neighbourCoords)
        {
            var liveNeighbourCellCount = neighbourCoords.Count(coord => _grid.CellIsAliveAtCoords(coord));
            if (liveNeighbourCellCount < 2)
            {
                _grid.SetCellAliveAtCoords(currentCellCoords, false);
            }
        }

        private List<int[]> GetNeighbourCoords(int[] cellCoords)
        {
            var adjacentCoords = new List<int[]>();

            for (var y = -1; y <= 1; y++)
            {
                for (var x = -1; x <= 1; x++)
                {
                    if (x == 0 && y == 0) continue;
                    adjacentCoords.Add(new[]{cellCoords[0] + x, cellCoords[1] + y});
                }
            }

            return adjacentCoords.Where(coord => coord[0] > 0 && coord[0] <= _grid.Length && coord[1] > 0 && coord[1] <= _grid.Height).ToList();
            

        }
    }
}