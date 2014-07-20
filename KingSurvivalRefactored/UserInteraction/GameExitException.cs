namespace KingSurvivalRefactored.UserInteraction
{
    using System;

    internal class GameExitException : Exception
    {
        public GameExitException(Exception innerException = null)
            : base("Exit game command issued!", innerException)
        {
        }
    }
}
