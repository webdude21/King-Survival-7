namespace KingSurvivalRefactored.GameRenderer
{
    using KingSurvivalRefactored.GameCore;
    using System;

    public class ConsoleRenderer : IRenderer
    {
        public void Render(ChessBoard board)
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
                        if (i % 2 == 0)
                        {
                            Console.Write("{0,2}", '+');
                        }
                        else
                        {
                            Console.Write("{0,2}", '-');
                        }
                    }
                    else
                    {
                        if (i % 2 == 0)
                        {
                            Console.Write("{0,2}", '-');
                        }
                        else
                        {
                            Console.Write("{0,2}", '+');
                        }
                    }
                }
                Console.WriteLine(string.Empty);

            }
        }

        public void InvalidMove()
        {
            Console.WriteLine("Invalid Move!");
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
