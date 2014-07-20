namespace KingSurvivalRefactored.GameCore
{

    public static class PieceFactory
    {

        public static void InitializeFigures(ChessBoard chessBoard)
        {
            chessBoard[0, 0] = new Cell(GetFigure(FigureSymbol.PawnA));
            chessBoard[2, 0] = new Cell(GetFigure(FigureSymbol.PawnB));
            chessBoard[4, 0] = new Cell(GetFigure(FigureSymbol.PawnC));
            chessBoard[6, 0] = new Cell(GetFigure(FigureSymbol.PawnD));
            chessBoard[3, 7] = new Cell(GetFigure(FigureSymbol.King));
        }

        public static Figure GetFigure(FigureSymbol name)
        {
            return new Figure((char)name, name);
        }
    }
}