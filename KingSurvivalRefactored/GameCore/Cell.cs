namespace KingSurvivalRefactored.GameCore
{
    public class Cell
    {
        public Cell(Figure figure)
        {
            this.ChessFigure = figure;
        }

        public Figure ChessFigure { get; set; }
    }
}
