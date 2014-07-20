namespace KingSurvivalRefactored.GameCore
{
    using System;

    internal class IllegalMoveExeception : ApplicationException
    {
        private const string ErrorMessage = "Illegal move!";

        public IllegalMoveExeception(ApplicationException innerException = null)
            : base(ErrorMessage, innerException)
        {
        }
    }
}