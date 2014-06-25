namespace KingSurvival.GameCore
{
    public struct ChessCell
    {

        public ChessCell(int xCoordinate, int yCoordinate)
            : this()
        {
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
        }

        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }
    }
}