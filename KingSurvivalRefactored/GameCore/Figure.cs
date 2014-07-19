namespace KingSurvivalRefactored.GameCore
{
    using System;

    public class Figure
    {
        private char name;

        public Figure(char name)
        {
            this.Name = name;
        }

        public char Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (!Char.IsLetter(value)) 
                {
                    throw new ArgumentException("Invalid Figure Name");
                }

                this.name = value;
            }
        }

    }
}