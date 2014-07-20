namespace KingSurvivalRefactored.GameCore
{
    using System;

    public class Figure
    {
        private char name;

        public Figure(char name)
            : this(name, null)
        {
        }

        public Figure(char name, FigureSymbol? designation)
        {
            this.Name = name;
            if (designation != null)
            {
                this.Designation = (FigureSymbol)designation;
            }
        }

        public char Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (!char.IsLetter(value) || !char.IsUpper(value))
                {
                    throw new ArgumentException("Invalid Figure Name");
                }

                this.name = value;
            }
        }

        public FigureSymbol Designation { get; set; }
    }
}