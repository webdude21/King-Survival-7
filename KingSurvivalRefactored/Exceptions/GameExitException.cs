namespace KingSurvivalRefactored.Exceptions
{
    using System;

    internal class GameExitException : ApplicationException
    {
        private const string ErrorMessage = "Exit game command issued!";

        public GameExitException(Exception innerException = null)
            : base(ErrorMessage, innerException)
        {
        }
    }
}