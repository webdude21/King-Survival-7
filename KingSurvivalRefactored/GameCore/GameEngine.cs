// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameEngine.cs" company="Team "King-Survival-7"">
//   Telerik Academy 2013-2014
// </copyright>
// <summary>
//    Implement Facade design pattern here
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace KingSurvivalRefactored.GameCore
{
    public class GameEngine
    {
        IChessPiece pawnA = Factory.GetPawn(new ChessCell(1, 0));
        IChessPiece pawnB = Factory.GetPawn(new ChessCell(3, 0));
        IChessPiece pawnC = Factory.GetPawn(new ChessCell(5, 0));
        IChessPiece pawnD = Factory.GetPawn(new ChessCell(7, 0));
        IChessPiece king = Factory.GetKing(new ChessCell(4, 7));
    }
}
