namespace KingSurvivalRefactored.Exceptions
{
    using System;

    internal class InvalidCommandException : ApplicationException
    {
        private const string ErrorMessage = "Invalid command!";

        public InvalidCommandException(Exception innerException = null)
            : base(ErrorMessage, innerException)
        {
        }
    }
}