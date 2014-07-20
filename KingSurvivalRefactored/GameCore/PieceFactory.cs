namespace KingSurvivalRefactored.GameCore
{

    public static class PieceFactory
    {

        public static void PushFigures(ChessBoard chessBoard)
        {
            chessBoard[0, 0] = new Cell(new Figure('A'));
            chessBoard[2, 0] = new Cell(new Figure('B'));
            chessBoard[4, 0] = new Cell(new Figure('C'));
            chessBoard[6, 0] = new Cell(new Figure('D'));
            chessBoard[3, 7] = new Cell(new Figure('K'));
        }
    }
}
