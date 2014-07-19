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
                }
                Console.WriteLine(string.Empty);

            }
        }
    }
}
