namespace KingSurvivalRefactored.GameCore
{
    using System;

    internal class GameExitException : Exception
    {
        private const string ErrorMessage = "Exit game command issued!";

        public GameExitException(Exception innerException = null)
            : base(ErrorMessage, innerException)
        {
        }
    }
}