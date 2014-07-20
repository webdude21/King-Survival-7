namespace KingSurvivalRefactored.Exceptions
{
    using System;

    internal class IllegalMoveExeception : ApplicationException
    {
        private const string ErrorMessage = "Illegal move!";

        public IllegalMoveExeception(Exception innerException = null)
            : base(ErrorMessage, innerException)
        {
        }
    }
}