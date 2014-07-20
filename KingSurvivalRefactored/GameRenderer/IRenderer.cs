namespace KingSurvivalRefactored.GameRenderer
{
    using KingSurvivalRefactored.GameCore;

    public interface IRenderer
    {
        void Render(ChessBoard chessRoot);

        void InvalidMove();

        void KingTurn();

        void PawnsTurn();

        void InvalidFigure();
    }
}
