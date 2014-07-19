namespace KingSurvivalRefactored.GameCore
{
    public class Cell
    {
        public Cell(Figure figure)
        {
            this.ChessFigure = figure;
        }

        //public Cell() 
        //{
        //    this.ChessFigure = new Figure(' ');
        //}

        public Figure ChessFigure { get; set; }
    }
}
