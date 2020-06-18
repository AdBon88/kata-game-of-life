namespace GameOfLife
{
    public static class GridFormatter
    {
        private const string LiveCell = " # ";
        private const string DeadCell = "   ";
        private const string GridLine = " . ";

        public static string FormatWithoutGridLinesAndNumbers(Grid grid)
        {
            var gridOutput = "";
            for (var rowNo = 1; rowNo <= grid.Height; rowNo++)
            {
                gridOutput += AppendColumns(rowNo, DeadCell, grid);
            }
            return gridOutput;
        }

        public static string FormatWithGridLinesAndNumbers(Grid grid)
        {
            var gridOutput = AppendColumnNumbers(grid.Length);
            gridOutput += AppendRowsWithRowNumbers(grid);

            return gridOutput;
        }

        private static string AppendColumnNumbers(int gridLength)
        {
            var columnHeader = "    ";
            for (var x = 1; x <= gridLength; x++)
            {
                //less white space needed for single digits
                columnHeader += x < 10 ? $" {x} " : $"{x} ";
            }
            return columnHeader + "(x)\n";
        }

        private static string AppendRowsWithRowNumbers(Grid grid)
        {
            var rows = "";

            for (var rowNo = 1; rowNo <= grid.Height; rowNo++)
            {
                rows += AppendRowNumber(rowNo) + AppendColumns(rowNo, GridLine, grid);
            } 
            return rows +"(y)";
        }

        private static string AppendRowNumber(int RowNo)
        {
            //less white space needed for single digits
            return RowNo < 10 ? $"  {RowNo} " : $" {RowNo} ";
        }

        private static string AppendColumns(int rowNo, string deadCell, Grid grid)
        {
            var rowContents = "";
            for (var colNo = 1; colNo <= grid.Length; colNo++)
            {
                rowContents += grid.CellIsAliveAtCoords(new[] {colNo, rowNo}) ? LiveCell : deadCell;
            }

            return rowContents + "\n";
        }
    }
}