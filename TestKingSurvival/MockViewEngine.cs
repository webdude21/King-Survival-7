namespace TestKingSurvival
{
    using KingSurvivalRefactored.GameCore;
    using KingSurvivalRefactored.GameRenderer;

    public class MockViewEngine : IRenderer
    {
        public void Board(ChessBoard chessRoot)
        {
        }

        public void IllegalMove()
        {
            throw new System.NotImplementedException();
        }

        public void KingTurn()
        {
            throw new System.NotImplementedException();
        }

        public void PawnsTurn()
        {
            throw new System.NotImplementedException();
        }

        public void InvalidFigure()
        {
            throw new System.NotImplementedException();
        }

        public void KingWin(int turns)
        {
            throw new System.NotImplementedException();
        }

        public void PawnsWin(int turns)
        {
            throw new System.NotImplementedException();
        }

        public void InvalidCommand()
        {
            throw new System.NotImplementedException();
        }
    }
}
