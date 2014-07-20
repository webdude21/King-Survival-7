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
    using KingSurvivalRefactored.GameRenderer;
    using KingSurvivalRefactored.UserInteraction;

    public class GameEngine : IGameEngine
    {

        private const int Size = 8;

        private static readonly ChessBoard ChessBoard = new ChessBoard();

        private IUserInterface Commander;

        private IRenderer Renderer;

        public GameEngine(IUserInterface userCommander, IRenderer renderer)
        {
            this.Commander = userCommander;
            this.Renderer = renderer;
            PieceFactory.PushFigures(ChessBoard);
        }

        public void RunGame()
        {
            int result = Play();

            if (result < 0)
            {
                Renderer.PawnsWin((int)(-result / 2));
            }
            else if (result > 0)
            {
                Renderer.KingWin((int)(result / 2)+1);
            }
        }

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
                Renderer.InvalidFigure();

                // TODO - throw invalid figure exception
                return;
            }

            FindFigure('K', ref kingXCoordinate, ref kingYCoordinate);
            DecodeMovement(move, ref dirX, ref dirY);

            if (kingXCoordinate + dirX < 0 ||
                kingXCoordinate + dirX > Size - 1 ||
                kingYCoordinate + dirY < 0 ||
                kingYCoordinate + dirY > Size - 1)
            {
                Renderer.InvalidMove();

                // throw invalid move execption
                return;
            }

            ChessBoard.Cells[kingXCoordinate + dirX, kingYCoordinate + dirY] =
          new Cell(ChessBoard.Cells[kingXCoordinate, kingYCoordinate].ChessFigure);

            ChessBoard.Cells[kingXCoordinate, kingYCoordinate] = null;
        }

        private bool PawnMove(char name, Movements move)
        {
            int dirX = 0, dirY = 0, pawnXCoordinate = -1, pawnYCoordinate = -1;

            FindFigure(name, ref pawnXCoordinate, ref pawnYCoordinate);

            if (pawnXCoordinate == -1 ||
                (name != 'A' && name != 'B' && name != 'C' && name != 'D'))
            {
                Renderer.InvalidFigure();

                // TODO - throw invalid figure exception
                return false;
            }

            DecodeMovement(move, ref dirX, ref dirY);

            if (pawnXCoordinate + dirX < 0 ||
                pawnXCoordinate + dirX > Size - 1 ||
                pawnYCoordinate + dirY < 0 ||
                pawnYCoordinate + dirY > Size - 1)
            {
                Renderer.InvalidMove();

                // TODO - throw invalid move exception
                return false;
            }

            ChessBoard.Cells[pawnXCoordinate + dirX, pawnYCoordinate + dirY] =
                new Cell(ChessBoard.Cells[pawnXCoordinate, pawnYCoordinate].ChessFigure);

            ChessBoard.Cells[pawnXCoordinate, pawnYCoordinate] = null;
            return false;
        }

        private int Play()
        {
            int moves = 0;

            while (true)
            {
                Renderer.Render(ChessBoard);

                int XCoordinate = -1, YCoordinate = -1;

                FindFigure('K', ref XCoordinate, ref YCoordinate);

                if (XCoordinate == -1) return -moves;
                if (YCoordinate == 0) return moves;


                
                try
                {
                    if (moves % 2 == 0)
                    {
                        Renderer.KingTurn();

                        var command = Commander.ReadUserCommand();

                        if (CheckForExitCommand(command.ComandeeName))
                        {
                            return 0;
                        }

                        KingMove(command.ComandeeName, command.MoveCommand);

                    }

                    if (moves % 2 != 0)
                    {
                        Renderer.PawnsTurn();

                        var command = Commander.ReadUserCommand();

                        if (CheckForExitCommand(command.ComandeeName))
                        {
                            return 0;
                        }

                        PawnMove(command.ComandeeName, command.MoveCommand);
                    }

                    moves++;

                }
                catch (System.Exception)
                {
                    throw;
                }

            }
        }

        private static bool CheckForExitCommand(char command)
        {
            if (command == 'X')
            {
                return true;
            }

            return false;
        }
    }
}