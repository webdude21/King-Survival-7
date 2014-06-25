namespace KingSurvivalRefactored.GameCore
{
    public class Pawn : IChessPiece, IMovable
    {
        public ChessCell Position { get; set; }

        public void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}