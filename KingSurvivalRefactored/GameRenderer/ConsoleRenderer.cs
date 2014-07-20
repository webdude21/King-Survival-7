namespace KingSurvivalRefactored.GameRenderer
{
    using KingSurvivalRefactored.GameCore;
    using System;

    public class ConsoleRenderer : IRenderer
    {
        public void Board(ChessBoard board)
        {
            Console.Clear();

            for (var j = 0; j < 8; j++)
            {
                for (var i = 0; i < 8; i++)
                {
                    if (board.Cells[i, j] != null)
                    {
                        Console.Write("{0,2}", board.Cells[i, j].ChessFigure.Name);
                    }
                    else if (j % 2 == 0)
                    {
                        Console.Write("{0,2}", i % 2 == 0 ? '+' : '-');
                    }
                    else
                    {
                        Console.Write("{0,2}", i % 2 == 0 ? '-' : '+');
                    }
                }
                Console.WriteLine(string.Empty);

            }
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
