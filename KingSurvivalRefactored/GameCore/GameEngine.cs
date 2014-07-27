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
    using System.Diagnostics.CodeAnalysis;

    using KingSurvivalRefactored.Enums;
    using KingSurvivalRefactored.Exceptions;
    using KingSurvivalRefactored.GameRenderer;
    using KingSurvivalRefactored.UserInteraction;

    public class GameEngine : IGameEngine
    {
        private const int BoardSize = 8;

        private static readonly ChessBoard ChessBoard = new ChessBoard(BoardSize);

        private readonly IUserInterface commander;

        private readonly IRenderer renderer;

        private int moves;

        public GameEngine(IUserInterface userCommander, IRenderer renderer)
        {
            this.commander = userCommander;
            this.renderer = renderer;
            FigureFactory.InitializeFigures(ChessBoard);
        }

        public void RunGame()
        {
            try
            {
                var result = this.Play();

                if (result < 0)
                {
                    this.renderer.PawnsWin(-result / 2);
                }
                else if (result > 0)
                {
                    this.renderer.KingWin((result / 2) + 1);
                }
            }
            catch (GameExitException)
            {
                
            }
        }

        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", 
            Justification = "Reviewed. Suppression is OK here.")]
        private static void FindFigure(FigureType figureType, ref int xCoordinate, ref int yCoordinate)
        {
            for (var y = 0; y < BoardSize; y++)
            {
                for (var x = 0; x < BoardSize; x++)
                {
                    if (ChessBoard[x, y] != null && ChessBoard[x, y].Type == figureType)
                    {
                        xCoordinate = x;
                        yCoordinate = y;
                        return;
                    }
                }
            }
        }

        private static void DecodeMovement(Movements move, ref int directionChangeX, ref int directionChangeY)
        {
            switch (move)
            {
                case Movements.DownLeft:
                    directionChangeX = -1;
                    directionChangeY = 1;
                    break;
                case Movements.DownRight:
                    directionChangeX = 1;
                    directionChangeY = 1;
                    break;
                case Movements.UpLeft:
                    directionChangeX = -1;
                    directionChangeY = -1;
                    break;
                case Movements.UpRight:
                    directionChangeX = 1;
                    directionChangeY = -1;
                    break;
            }
        }

        private static void KingMove(FigureType figure, Movements move)
        {
            int dirX = 0, dirY = 0, kingXCoordinate = 0, kingYCoordinate = 0;

            if (FigureFactory.IsPawn(figure))
            {
                throw new IllegalMoveExeception();
            }

            FindFigure(FigureType.King, ref kingXCoordinate, ref kingYCoordinate);
            DecodeMovement(move, ref dirX, ref dirY);

            if (kingXCoordinate + dirX < 0 || kingXCoordinate + dirX > BoardSize - 1 || kingYCoordinate + dirY < 0
                || kingYCoordinate + dirY > BoardSize - 1)
            {
                throw new IllegalMoveExeception();
            }

            ChessBoard[kingXCoordinate + dirX, kingYCoordinate + dirY] =
                 ChessBoard[kingXCoordinate, kingYCoordinate];

            ChessBoard[kingXCoordinate, kingYCoordinate] = null;
        }

        private static void PawnMove(FigureType figure, Movements movement)
        {
            int dirX = 0, dirY = 0, pawnXCoordinate = -1, pawnYCoordinate = -1;

            FindFigure(figure, ref pawnXCoordinate, ref pawnYCoordinate);

            if (pawnXCoordinate == -1 || (!FigureFactory.IsPawn(figure)))
            {
                throw new IllegalMoveExeception();
            }

            DecodeMovement(movement, ref dirX, ref dirY);

            if (dirY == -1 || pawnXCoordinate + dirX < 0 || pawnXCoordinate + dirX > BoardSize - 1
                || pawnYCoordinate + dirY < 0 || pawnYCoordinate + dirY > BoardSize - 1)
            {
                throw new IllegalMoveExeception();
            }

            var figureToMove = ChessBoard[pawnXCoordinate + dirX, pawnYCoordinate + dirY];

            if (figureToMove == null || FigureFactory.IsKing(figureToMove))
            {
                ChessBoard[pawnXCoordinate + dirX, pawnYCoordinate + dirY] =
                     ChessBoard[pawnXCoordinate, pawnYCoordinate];

                ChessBoard[pawnXCoordinate, pawnYCoordinate] = null;
            }
            else
            {
                throw new IllegalMoveExeception();
            }
        }

        private static bool KingHasSurvived()
        {
            for (var i = 0; i < ChessBoard.BoardSize; i++)
            {
                for (var j = 0; j < ChessBoard.BoardSize; j++)
                {
                    if (ChessBoard[i, j] != null && FigureFactory.IsPawn(ChessBoard[i, j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool IsKingsTurn()
        {
            return this.moves % 2 == 0;
        }

        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", 
            Justification = "Reviewed. Suppression is OK here.")]
        private int Play()
        {
            while (true)
            {
                this.renderer.DrawBoard(ChessBoard);

                int xCoordinate = -1, yCoordinate = -1;

                FindFigure(FigureType.King, ref xCoordinate, ref yCoordinate);

                if (xCoordinate == -1)
                {
                    return -this.moves;
                }

                if (yCoordinate == 0)
                {
                    return this.moves;
                }

                if (KingHasSurvived())
                {
                    return this.moves;
                }

                try
                {
                    if (this.IsKingsTurn())
                    {
                        this.renderer.KingTurn();
                        var command = this.commander.ReadUserCommand();
                        KingMove((FigureType)command.ComandeeName, command.MoveCommand);
                    }
                    else
                    {
                        this.renderer.PawnsTurn();
                        var command = this.commander.ReadUserCommand();
                        PawnMove((FigureType)command.ComandeeName, command.MoveCommand);
                    }

                    this.moves++;
                }
                catch (InvalidCommandException)
                {
                    this.renderer.InvalidCommand();
                }
                catch (IllegalMoveExeception)
                {
                    this.renderer.IllegalMove();
                }
            }
        }
    }
}