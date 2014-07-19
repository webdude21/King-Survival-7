namespace KingSurvivalRefactored.GameCore
{
    using System;

    public class Figure
    {
        private string name;

        public Figure(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value.Trim().Length != 1) 
                {
                    throw new ArgumentException("Invalid Figure Name");
                }

                this.name = value.Trim();
            }
        }

    }
}