namespace KingSurvivalRefactored.GameCore
{

    public static class PieceFactory
    {

        public static void PushFigures(ChessBoard ChessBoard)
        {
            ChessBoard[0, 0] = new Cell(new Figure('A'));
            ChessBoard[2, 0] = new Cell(new Figure('B'));
            ChessBoard[4, 0] = new Cell(new Figure('C'));
            ChessBoard[6, 0] = new Cell(new Figure('D'));
            ChessBoard[3, 7] = new Cell(new Figure('K'));
        }
    }
}
