namespace KingSurvivalRefactored.GameCore
{
    using System;

    public class ChessPiece : IChessPiece
    {
        public ChessPiece(ChessCell position)
        {
            this.Position = position;
        }

        public ChessCell Position { get; set; }

        public virtual void Move(Movements direction)
        {
            throw new NotImplementedException();
        }
    }
}