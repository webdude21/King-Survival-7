namespace KingSurvivalRefactored.GameCore
{
    public class Figure
    {
        public Figure(FigureType type)
        {
            this.Type = type;
            this.Name = (char)type;
        }

        public char Name { get; private set; }

        public FigureType Type { get; private set; }
    }
}