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
    internal class GameEngine
    {
        var pawnA = Factory.GetPawn(new ChessCell(1,0));
     /*   var pawnB = Factory.GetPawn(new ChessCell(3,0));
        var pawnC = Factory.GetPawn(new ChessCell(5,0));
        var pawnD = Factory.GetPawn(new ChessCell(7,0));
        var king = Factory.GetKing(new ChessCell(4, 7));*/
    }
}
