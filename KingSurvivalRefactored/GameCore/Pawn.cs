namespace KingSurvivalRefactored.GameCore
{
    public class Pawn : ChessPiece, IMovable
    {
        public Pawn(ChessCell position)
            : base(position)
        { }

        public void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}