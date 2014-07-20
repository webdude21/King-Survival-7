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
    using System.Diagnostics.CodeAnalysis;

    using KingSurvivalRefactored.GameRenderer;
    using KingSurvivalRefactored.UserInteraction;

    public class GameEngine : IGameEngine
    {
        private const int BoardSize = 8;

        private const char King = 'K';

        private static readonly ChessBoard ChessBoard = new ChessBoard(BoardSize);

        private readonly IUserInterface commander;

        private readonly IRenderer renderer;

        public GameEngine(IUserInterface userCommander, IRenderer renderer)
        {
            this.commander = userCommander;
            this.renderer = renderer;
            ChessBoard.Cells = new Cell[BoardSize, BoardSize];
            PieceFactory.InitializeFigures(ChessBoard);
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
                    if (ChessBoard.Cells[x, y] != null && ChessBoard.Cells[x, y].ChessFigure.Type == figureType)
                    {
                        xCoordinate = x;
                        yCoordinate = y;
                        return;
                    }
                }
            }
        }

        private static void DecodeMovement(Movements move, ref int dirX, ref int dirY)
        {
            switch (move)
            {
                case Movements.DownLeft:
                    dirX = -1;
                    dirY = 1;
                    break;
                case Movements.DownRight:
                    dirX = 1;
                    dirY = 1;
                    break;
                case Movements.UpLeft:
                    dirX = -1;
                    dirY = -1;
                    break;
                case Movements.UpRight:
                    dirX = 1;
                    dirY = -1;
                    break;
            }
        }

        private static void KingMove(FigureType figure, Movements move)
        {
            int dirX = 0, dirY = 0, kingXCoordinate = 0, kingYCoordinate = 0;

            if (IsPawn(figure))
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

            ChessBoard.Cells[kingXCoordinate + dirX, kingYCoordinate + dirY] =
                new Cell(ChessBoard.Cells[kingXCoordinate, kingYCoordinate].ChessFigure);

            ChessBoard.Cells[kingXCoordinate, kingYCoordinate] = null;
        }

        private static void PawnMove(FigureType figure, Movements move)
        {
            int dirX = 0, dirY = 0, pawnXCoordinate = -1, pawnYCoordinate = -1;

            FindFigure(figure, ref pawnXCoordinate, ref pawnYCoordinate);

            if (pawnXCoordinate == -1 || (!IsPawn(figure)))
            {
                throw new IllegalMoveExeception();
            }

            DecodeMovement(move, ref dirX, ref dirY);

            if (dirY == -1 || pawnXCoordinate + dirX < 0 || pawnXCoordinate + dirX > BoardSize - 1
                || pawnYCoordinate + dirY < 0 || pawnYCoordinate + dirY > BoardSize - 1)
            {
                throw new IllegalMoveExeception();
            }

            var cellToMove = ChessBoard.Cells[pawnXCoordinate + dirX, pawnYCoordinate + dirY];

            if (cellToMove == null || IsKing(cellToMove.ChessFigure.Type))
            {
                ChessBoard.Cells[pawnXCoordinate + dirX, pawnYCoordinate + dirY] =
                    new Cell(ChessBoard.Cells[pawnXCoordinate, pawnYCoordinate].ChessFigure);

                ChessBoard.Cells[pawnXCoordinate, pawnYCoordinate] = null;
            }
            else
            {
                throw new IllegalMoveExeception();
            }
        }

        private static bool IsPawn(FigureType figureType)
        {
            return !IsKing(figureType);
        }

        private static bool IsKing(FigureType figureType)
        {
            return figureType == FigureType.King;
        }


        private static FigureType ConvertCharToFigureType(char name)
        {
            return (FigureType)name;
        }

        private static bool KingHasSurvived()
        {
            for (var i = 0; i < ChessBoard.BoardSize; i++)
            {
                for (var j = 0; j < ChessBoard.BoardSize; j++)
                {
                    if (ChessBoard[i, j] != null && IsPawn(ChessBoard[i, j].ChessFigure.Type))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation",
            Justification = "Reviewed. Suppression is OK here.")]
        private int Play()
        {
            var moves = 0;

            while (true)
            {
                this.renderer.Board(ChessBoard);

                int xCoordinate = -1, yCoordinate = -1;

                FindFigure(FigureType.King, ref xCoordinate, ref yCoordinate);

                if (xCoordinate == -1)
                {
                    return -moves;
                }

                if (yCoordinate == 0)
                {
                    return moves;
                }

                if (KingHasSurvived())
                {
                    return moves;
                }

                try
                {
                    // king turn
                    if (moves % 2 == 0)
                    {
                        this.renderer.KingTurn();
                        var command = this.commander.ReadUserCommand();
                        KingMove(ConvertCharToFigureType(command.ComandeeName), command.MoveCommand);
                    }
                    else
                    {
                        // pawns turn
                        this.renderer.PawnsTurn();
                        var command = this.commander.ReadUserCommand();
                        PawnMove(ConvertCharToFigureType(command.ComandeeName), command.MoveCommand);
                    }

                    moves++;
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