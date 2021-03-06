﻿namespace KingSurvivalRefactored.GameRenderer
{
    using KingSurvivalRefactored.GameCore;

    public interface IRenderer
    {
        void DrawBoard(ChessBoard chessRoot);

        void IllegalMove();

        void KingTurn();

        void PawnsTurn();

        void InvalidFigure();

        void KingWin(int turns);

        void PawnsWin(int turns);

        void InvalidCommand();
    }
}
