namespace KingSurvivalRefactored.GameCore
{
    public class King : ChessPiece, IMovable
    {
        public King(ChessCell position) 
            : base(position) 
        { }


        public void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}
