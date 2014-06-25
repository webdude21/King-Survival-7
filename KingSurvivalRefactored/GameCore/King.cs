namespace KingSurvivalRefactored.GameCore
{
    public class King : IChessPiece, IMovable
    {
        public ChessCell Position { get; set; }

        public void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}
