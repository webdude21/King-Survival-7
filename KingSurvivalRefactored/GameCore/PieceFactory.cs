namespace KingSurvivalRefactored.GameCore
{

    public static class PieceFactory
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
            return new Figure((char)name, name);
        }
    }
}