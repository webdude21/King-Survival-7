// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChessBoard.cs" company="Team "King-Survival-7"">
//   Telerik Academy 2013-2014
// </copyright>
// <summary>
//   Implement the Singleton pattern for ChessBoard.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace KingSurvivalRefactored.GameCore
{
    public class ChessBoard
    {
        private static readonly object SyncRoot = new object();

        private static volatile ChessBoard instance;

        public ChessBoard()
        {
            this.Cells = new Cell[8, 8];
        }

        public Cell[,] Cells { get; set; }

        public Cell this[int x, int y] 
        {
            get
            {
                return this.Cells[x, y];
            }

            set
            {
                this.Cells[x, y] = value;
            }
        }

        public static ChessBoard Instance
        {
            get
            {
                if (instance != null)
                {
                    return instance;
                }

                lock (SyncRoot)
                {
                    if (instance == null)
                    {
                        instance = new ChessBoard();
                    }
                }

                return instance;
            }
        }

    }
}