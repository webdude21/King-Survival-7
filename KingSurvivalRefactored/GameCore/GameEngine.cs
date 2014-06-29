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
        IChessPiece pawnA = PieceFactory.GetPawn(new ChessCell(1, 0));
        IChessPiece pawnB = PieceFactory.GetPawn(new ChessCell(3, 0));
        IChessPiece pawnC = PieceFactory.GetPawn(new ChessCell(5, 0));
        IChessPiece pawnD = PieceFactory.GetPawn(new ChessCell(7, 0));
        IChessPiece king = PieceFactory.GetKing(new ChessCell(4, 7));
    }
}
