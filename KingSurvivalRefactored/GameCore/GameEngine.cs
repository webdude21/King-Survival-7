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

    using KingSurvivalRefactored.GameRenderer;
    using KingSurvivalRefactored.UserInteraction;

    public class GameEngine : IGameEngine
    {
        private const int Size = 8;

        private static readonly ChessBoard ChessBoard = new ChessBoard();

        private readonly IUserInterface commander;

        private readonly IRenderer renderer;

        public GameEngine(IUserInterface userCommander, IRenderer renderer)
        {
            this.commander = userCommander;
            this.renderer = renderer;
            ChessBoard.Cells = new Cell[8, 8];
            PieceFactory.PushFigures(ChessBoard);
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
        private static void FindFigure(char name, ref int xCoordinate, ref int yCoordinate)
        {
            for (var y = 0; y < Size; y++)
            {
                for (var x = 0; x < Size; x++)
                {
                    if (ChessBoard.Cells[x, y] != null && ChessBoard.Cells[x, y].ChessFigure.Name == name)
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
            if (move == Movements.DownLeft)
            {
                dirX = -1;
                dirY = 1;
            }
            else if (move == Movements.DownRight)
            {
                dirX = 1;
                dirY = 1;
            }
            else if (move == Movements.UpLeft)
            {
                dirX = -1;
                dirY = -1;
            }
            else if (move == Movements.UpRight)
            {
                dirX = 1;
                dirY = -1;
            }
        }

        private void KingMove(char name, Movements move)
        {
            int dirX = 0, dirY = 0, kingXCoordinate = 0, kingYCoordinate = 0;

            if (name != 'K')
            {
                this.renderer.InvalidFigure();

                // TODO - throw invalid figure exception
                return;
            }

            FindFigure('K', ref kingXCoordinate, ref kingYCoordinate);
            DecodeMovement(move, ref dirX, ref dirY);

            if (kingXCoordinate + dirX < 0 || kingXCoordinate + dirX > Size - 1 || kingYCoordinate + dirY < 0
                || kingYCoordinate + dirY > Size - 1)
            {
                this.renderer.InvalidMove();

                // throw invalid move execption
                return;
            }

            ChessBoard.Cells[kingXCoordinate + dirX, kingYCoordinate + dirY] =
                new Cell(ChessBoard.Cells[kingXCoordinate, kingYCoordinate].ChessFigure);

            ChessBoard.Cells[kingXCoordinate, kingYCoordinate] = null;
        }

        private void PawnMove(char name, Movements move)
        {
            int dirX = 0, dirY = 0, pawnXCoordinate = -1, pawnYCoordinate = -1;

            FindFigure(name, ref pawnXCoordinate, ref pawnYCoordinate);

            if (pawnXCoordinate == -1 || (name != 'A' && name != 'B' && name != 'C' && name != 'D'))
            {
                this.renderer.InvalidFigure();

                // TODO - throw invalid figure exception
                return;
            }

            DecodeMovement(move, ref dirX, ref dirY);

            if (pawnXCoordinate + dirX < 0 || pawnXCoordinate + dirX > Size - 1 || pawnYCoordinate + dirY < 0
                || pawnYCoordinate + dirY > Size - 1)
            {
                this.renderer.InvalidMove();

                // TODO - throw invalid move exception
                return;
            }

            ChessBoard.Cells[pawnXCoordinate + dirX, pawnYCoordinate + dirY] =
                new Cell(ChessBoard.Cells[pawnXCoordinate, pawnYCoordinate].ChessFigure);

            ChessBoard.Cells[pawnXCoordinate, pawnYCoordinate] = null;
        }

        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", 
            Justification = "Reviewed. Suppression is OK here.")]
        private int Play()
        {
            var moves = 0;

            while (true)
            {
                this.renderer.Render(ChessBoard);

                int xCoordinate = -1, yCoordinate = -1;

                FindFigure('K', ref xCoordinate, ref yCoordinate);

                if (xCoordinate == -1)
                {
                    return -moves;
                }

                if (yCoordinate == 0)
                {
                    return moves;
                }

                try
                {
                    if (moves % 2 == 0)
                    {
                        this.renderer.KingTurn();
                        var command = this.commander.ReadUserCommand();
                        this.KingMove(command.ComandeeName, command.MoveCommand);
                    }

                    if (moves % 2 != 0)
                    {
                        this.renderer.PawnsTurn();
                        var command = this.commander.ReadUserCommand();
                        this.PawnMove(command.ComandeeName, command.MoveCommand);
                    }

                    moves++;
                }
                catch (InvalidCommandException ex)
                {
                    // TODO something about it
                }
            }
        }
    }
}