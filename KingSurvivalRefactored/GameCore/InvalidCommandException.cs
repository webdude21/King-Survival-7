namespace KingSurvivalRefactored.GameCore
{
    using System;

    internal class InvalidCommandException : ApplicationException
    {
        private const string ErrorMessage = "Invalid command!";

        public InvalidCommandException(ApplicationException innerException = null)
            : base(ErrorMessage, innerException)
        {
        }
    }
}