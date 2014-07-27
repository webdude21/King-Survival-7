namespace KingSurvivalRefactored.GameCore
{
    using KingSurvivalRefactored.Enums;

    public static class FigureFactory
    {
        public static void InitializeFigures(ChessBoard chessBoard)
        {
            for (var j = 0; j < 8; j++)
            {
                for (var i = 0; i < 8; i++)
                {
                    chessBoard[i, j] = null;
                }
            }
              
            chessBoard[0, 0] = GetFigure(FigureType.PawnA);
            chessBoard[2, 0] = GetFigure(FigureType.PawnB);
            chessBoard[4, 0] = GetFigure(FigureType.PawnC);
            chessBoard[6, 0] = GetFigure(FigureType.PawnD);
            chessBoard[3, 7] = GetFigure(FigureType.King);
        }

        public static Figure GetFigure(FigureType name)
        {
            return new Figure(name);
        }

        public static bool IsKing(FigureType figureType)
        {
            return figureType == FigureType.King;
        }

        public static bool IsPawn(FigureType figureType)
        {
            return !IsKing(figureType);
        }

        public static bool IsKing(Figure figure)
        {
            return IsKing(figure.Type);
        }

        public static bool IsPawn(Figure figure)
        {
            return !IsKing(figure);
        }
    }
}