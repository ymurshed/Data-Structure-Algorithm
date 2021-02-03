namespace BfsMatrixTraverse
{
    public class BfsModel
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Distance { get; set; }

        public BfsModel(int row, int col, int distance)
        {
            Row = row;
            Col = col;
            Distance = distance;
        }
    }
}
