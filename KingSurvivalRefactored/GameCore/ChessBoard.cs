// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChessBoard.cs" company="Team "King-Survival-7"">
//   Telerik Academy 2013-2014
// </copyright>
// <summary>
//   Implement the Composite pattern for ChessBoard, so it internally contains all of ChessPieces in it
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace KingSurvivalRefactored.GameCore
{
    using System;
    private class ChessBoard
    {
        private static volatile ChessBoard instance;
        private static object syncRoot = new Object();

        private ChessBoard() {}
        public static ChessBoard Instance 
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot) 
                    {
                       if (instance == null) 
                       {
                            instance = new ChessBoard();
                       }
                    }
                }
                return instance;
            }
        }
    }
}
