namespace KingSurvivalRefactored.GameCore
{
    using System;

    internal class InvalidCommandException : Exception
    {
        private const string ErrorMessage = "Invalid command!";

        public InvalidCommandException(Exception innerException = null)
            : base(ErrorMessage, innerException)
        {
        }
    }
}