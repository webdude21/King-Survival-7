namespace TestKingSurvival
{
    using KingSurvivalRefactored.GameCore;
    using KingSurvivalRefactored.GameRenderer;

    public class MockViewEngine : IRenderer
    {

        public bool IllegalMoveReceived { get; private set; }
        public bool BoardCommandReceived { get; private set; }

        public void DrawBoard(ChessBoard chessRoot)
        {
            this.BoardCommandReceived = true;
        }

        public void IllegalMove()
        {
            this.IllegalMoveReceived = true;
        }

        public void KingTurn()
        {

        }

        public void PawnsTurn()
        {
     
        }

        public void InvalidFigure()
        {
       
        }

        public void KingWin(int turns)
        {
            
        }

        public void PawnsWin(int turns)
        {
     
        }

        public void InvalidCommand()
        {

        }
    }
}
