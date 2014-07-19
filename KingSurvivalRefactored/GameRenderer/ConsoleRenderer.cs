namespace KingSurvivalRefactored.GameRenderer
{
    using KingSurvivalRefactored.GameCore;
    using System;

    public class ConsoleRenderer : IRenderer
    {

        public void Render(ChessBoard board)
        {
            Console.Clear();

            for (var i = 0; i < 8; i++)
            {
                for (var j = 0; j < 8; j++)
                {
                    Console.Write("{0,2}", board.Cells[i, j].ChessFigure.Name);
                }

                Console.WriteLine(string.Empty);
            }
        }
    }
}
