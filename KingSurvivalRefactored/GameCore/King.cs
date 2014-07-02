namespace KingSurvivalRefactored.GameCore
{
    using System;

    public class King : ChessPiece
    {
        public King(ChessCell position)
            : base(position)
        {
        }

        public override void Move(Movements direction)
        {
            var currentPosition = this.Position;

            switch (direction)
            {
                case Movements.UpLeft:
                    currentPosition.XCoordinate--;
                    currentPosition.YCoordinate--;
                    this.Position = currentPosition;
                    break;
                case Movements.UpRight:
                    currentPosition.XCoordinate++;
                    currentPosition.YCoordinate--;
                    this.Position = currentPosition;
                    break;
                case Movements.DownLeft:
                    currentPosition.XCoordinate--;
                    currentPosition.YCoordinate++;
                    this.Position = currentPosition;
                    break;
                case Movements.DownRight:
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