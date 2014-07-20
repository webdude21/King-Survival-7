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

        public Figure(char name, FigureType? designation)
        {
            this.Name = name;
            if (designation != null)
            {
                this.Designation = (FigureType)designation;
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

        public FigureType Designation { get; private set; }
    }
}