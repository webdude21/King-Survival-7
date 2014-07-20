namespace KingSurvivalRefactored.GameCore
{
    using KingSurvivalRefactored.Enums;

    public class Figure
    {
        public Figure(FigureType type)
        {
            this.Type = type;
            this.Name = (char)type;
        }

        public Figure(char name)
        {
            this.Name = name;
            this.Type = (FigureType)name;
        }

        public char Name { get; private set; }

        public FigureType Type { get; private set; }
    }
}