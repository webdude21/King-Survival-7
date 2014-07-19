﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameEngine.cs" company="Team "King-Survival-7"">
//   Telerik Academy 2013-2014
// </copyright>
// <summary>
//    Implement Facade design pattern here
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace KingSurvivalRefactored.GameCore
{
    using KingSurvivalRefactored.UserInteraction;

    public class GameEngine : IGameEngine
    {
        public IUserCommand RecieveCommand(IUserInterface userInterface)
        {
            var command = userInterface.SendCommand();
            return command;
        }

        public void RunGame()
        {
            while (true)
            {
            }
        }

        private void PawnMove(Pawn pawn)
        {
            
        }

        private void KingMove(King king)
        {
            
        }
    }
}