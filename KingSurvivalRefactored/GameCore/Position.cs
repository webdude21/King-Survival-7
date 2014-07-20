namespace KingSurvivalRefactored.GameCore
{
    public struct Position
    {
        private Position(int x, int y)
            : this()
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }
    }
}