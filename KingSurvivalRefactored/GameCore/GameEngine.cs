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

        private bool flag = true;

        private static readonly ChessBoard ChessBoard = new ChessBoard();

        private IUserInterface Commander;

        private IRenderer Renderer;

        public GameEngine(IUserInterface userCommander, IRenderer renderer)
        {
            this.Commander = userCommander;
            this.Renderer = renderer;
        }

        public void RunGame()
        {
            ChessBoard[0, 0] = new Cell(new Figure('A'));
            ChessBoard[2, 0] = new Cell(new Figure('B'));
            ChessBoard[4, 0] = new Cell(new Figure('C'));
            ChessBoard[6, 0] = new Cell(new Figure('D'));
            ChessBoard[3, 7] = new Cell(new Figure('K'));

            Renderer.Render(ChessBoard);

            bool? flag2 = false;

            flag2 = Play(flag2);
            if (flag2 == true)
            {
                // Console.WriteLine("Pawn`s win!");
            }
            else if (flag2 == false)
            {
                // Console.WriteLine("King`s win!");
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

            // throw new invalid move execption
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

        private bool? Play(bool? flag2)
        {

            while (!flag2 == true)
            {
                flag = true;

                while (flag)
                {
                    flag = false;

                    Renderer.KingTurn();

                    var command = Commander.ReadUserCommand();

                    if (CheckForExitCommand(command.ComandeeName))
                    {
                        return null;
                    }

                    KingMove(command.ComandeeName, command.MoveCommand);

                    Renderer.Render(ChessBoard);
                }

                while (!flag)
                {
                    flag = true;

                    Renderer.PawnsTurn();

                    var command = Commander.ReadUserCommand();

                    if (CheckForExitCommand(command.ComandeeName))
                    {
                        return null;
                    }

                    flag2 = PawnMove(command.ComandeeName, command.MoveCommand);

                    Renderer.Render(ChessBoard);


                }
            }

            return flag2;
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