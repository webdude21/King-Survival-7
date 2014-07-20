namespace KingSurvivalRefactored.GameCore
{
    using KingSurvivalRefactored.Enums;

    public static class FigureFactory
    {
        public static void InitializeFigures(ChessBoard chessBoard)
        {
            chessBoard[0, 0] = new Cell(GetFigure(FigureType.PawnA));
            chessBoard[2, 0] = new Cell(GetFigure(FigureType.PawnB));
            chessBoard[4, 0] = new Cell(GetFigure(FigureType.PawnC));
            chessBoard[6, 0] = new Cell(GetFigure(FigureType.PawnD));
            chessBoard[3, 7] = new Cell(GetFigure(FigureType.King));
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