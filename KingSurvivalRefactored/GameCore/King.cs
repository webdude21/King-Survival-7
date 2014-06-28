namespace KingSurvivalRefactored.GameCore
{
    using System;

    public class King : ChessPiece
    {
        public King(ChessCell position)
            : base(position)
        { }

        public override void Move(Movements direction)
        {
            var currentPosition = base.Position;

            switch (direction)
            {
                case Movements.ForwardLeft:
                    currentPosition.XCoordinate--;
                    currentPosition.YCoordinate--;
                    base.Position = currentPosition;
                    break;
                case Movements.ForwardRight:
                    currentPosition.XCoordinate++;
                    currentPosition.YCoordinate--;
                    base.Position = currentPosition;
                    break;
                case Movements.BackwardLeft:
                    currentPosition.XCoordinate--;
                    currentPosition.YCoordinate++;
                    base.Position = currentPosition;
                    break;
                case Movements.BackwardRight:
                    currentPosition.XCoordinate++;
                    currentPosition.YCoordinate++;
                    base.Position = currentPosition;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("direction", direction, "Invalid Movement");
            }
        }
    }
}
