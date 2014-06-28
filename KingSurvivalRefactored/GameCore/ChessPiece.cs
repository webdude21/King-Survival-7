namespace KingSurvivalRefactored.GameCore
{
    public class ChessPiece : IChessPiece
    {
        public ChessCell Position { get; set; }

        public ChessPiece(ChessCell position)
        {
            this.Position = position;
        }

    }
}
