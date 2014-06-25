// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChessCell.cs" company="Team "King-Survival-7"">
//   Telerik Academy 2013-2014
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace KingSurvival.GameCore
{
    public struct ChessCell
    {
        public ChessCell(int xCoordinate, int yCoordinate)
            : this()
        {
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
        }

        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }
    }
}