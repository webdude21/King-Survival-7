namespace KingSurvivalRefactored.GameCore
{
    public interface IChessPiece : IMovable
    {
        ChessCell Position { get; set; }
    }
}
