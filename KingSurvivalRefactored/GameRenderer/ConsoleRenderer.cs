namespace KingSurvivalRefactored.GameRenderer
{
    using System;

    using KingSurvivalRefactored.GameCore;

    public class ConsoleRenderer : IRenderer
    {
        public void DrawBoard(ChessBoard board)
        {
            Console.Clear();
            Console.Write(board.ToString());
        }

        public void IllegalMove()
        {
            Console.WriteLine("Illegal Move!");
            Console.WriteLine("**Press Enter to continue**");
            Console.ReadLine();
        }

        public void InvalidFigure()
        {
            Console.WriteLine("Invalid Figure!");
            Console.WriteLine("**Press Enter to continue**");
            Console.ReadLine();
        }

        public void InvalidCommand()
        {
            Console.WriteLine("Invalid Command!");
            Console.WriteLine("**Press Enter to continue**");
            Console.ReadLine();
        }

        public void KingTurn()
        {
            Console.Write("King`s Turn:");
        }

        public void PawnsTurn()
        {
            Console.Write("Pawn`s Turn:");
        }

        public void KingWin(int turns)
        {
            Console.WriteLine("King wins in {0} turns.", turns);
        }

        public void PawnsWin(int turns)
        {
            Console.WriteLine("Pawns wins in {0} turns.", turns);
        }
    }
}