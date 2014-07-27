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
    using System;
    using System.Text;

    public class ChessBoard
    {
        private static readonly object SyncRoot = new object();

        private static volatile ChessBoard instance;

        private static int boardSize;

        private readonly Figure[,] cells;

        public ChessBoard(int boardSize)
        {
            this.BoardSize = boardSize;
            this.cells = new Figure[this.BoardSize, this.BoardSize];
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
                        instance = new ChessBoard(boardSize);
                    }
                }

                return instance;
            }
        }

        public int BoardSize
        {
            get
            {
                return boardSize;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("boardSize", "The boardSize should be positive number!");
                }

                boardSize = value;
            }
        }

        public Figure this[int x, int y]
        {
            get
            {
                return this.cells[x, y];
            }

            set
            {
                this.cells[x, y] = value;
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine();
            stringBuilder.AppendLine("     0 1 2 3 4 5 6 7");
            stringBuilder.AppendLine("    -----------------");

            for (var j = 0; j < 8; j++)
            {
                stringBuilder.AppendFormat("{0,2} |", j);

                for (var i = 0; i < 8; i++)
                {
                    if (this[i, j] != null)
                    {
                        stringBuilder.AppendFormat("{0,2}", this[i, j].Name);
                    }
                    else if (j % 2 == 0)
                    {
                        stringBuilder.AppendFormat("{0,2}", i % 2 == 0 ? '+' : '-');
                    }
                    else
                    {
                        stringBuilder.AppendFormat("{0,2}", i % 2 == 0 ? '-' : '+');
                    }
                }

                stringBuilder.AppendLine(" |");
            }

            stringBuilder.AppendLine("    -----------------");

            return stringBuilder.ToString();
        }
    }
}