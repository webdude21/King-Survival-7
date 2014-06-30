namespace KingSurvivalRefactored.GameCore
{
    using System;

    public class Pawn : ChessPiece
    {
        public Pawn(ChessCell position)
            : base(position)
        {
        }

        public override void Move(Movements direction)
        {
            var currentPosition = this.Position;

            switch (direction)
            {
                case Movements.ForwardLeft:
                    currentPosition.XCoordinate--;
                    currentPosition.YCoordinate++;
                    this.Position = currentPosition;
                    break;
                case Movements.ForwardRight:
                    currentPosition.XCoordinate++;
                    currentPosition.YCoordinate++;
                    this.Position = currentPosition;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("direction", direction, "Invalid Movement");
            }
        }
    }
}