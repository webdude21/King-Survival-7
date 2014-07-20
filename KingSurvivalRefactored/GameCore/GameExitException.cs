namespace KingSurvivalRefactored.GameCore
{
    using System;

    internal class GameExitException : ApplicationException
    {
        private const string ErrorMessage = "Exit game command issued!";

        public GameExitException(ApplicationException innerException = null)
            : base(ErrorMessage, innerException)
        {
        }
    }
}