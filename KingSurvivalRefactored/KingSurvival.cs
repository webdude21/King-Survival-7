namespace KingSurvivalRefactored
{
    using System;
    using System.Collections.Generic;

    using KingSurvivalRefactored.GameCore;
    using KingSurvivalRefactored.GameRenderer;
    using KingSurvivalRefactored.UserInteraction;

    public class KingSurvival
    {
        private const int Size = 8;

        private static List<IChessPiece> pawns;

        private static IChessPiece king;

        private static bool flag = true;

        private static readonly IRenderer Renderer = new ConsoleRenderer();

        private static ChessBoard chessBoard = new ChessBoard();

        private static readonly IUserInterface ConsoleCommander = new ConsoleCommander();


        //var name = command.ComandeeName;
        //            var move = command.MoveCommand;

        //            KingMove(name, move);

        private static void FindFigure(char name, ref int xCoordinate, ref int yCoordinate)
        {
            int[] result = { 10, 10 };

            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (chessBoard.Cells[x, y].ChessFigure.Name == name)
                    {
                        xCoordinate = x;
                        yCoordinate = y;
                        return;
                    }
                }
            }
            // throw new invalid move execption

            return;
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


        private static void KingMove(char name, Movements move)
        {
            int dirX=0, dirY=0, kingXCoordinate=0, kingYCoordinate=0;

            FindFigure('K', ref kingXCoordinate, ref kingYCoordinate);
            DecodeMovement(move, ref dirX, ref dirY);

            if (kingXCoordinate + dirX < 0 || kingXCoordinate + dirX > Size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press Enter to continue**");
                Console.ReadLine();
                flag = true;
                // throw new invalid move execption
                return;
            }

            if (kingYCoordinate + dirY < 0 || kingYCoordinate + dirY > Size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press Enter to continue**");
                Console.ReadLine();
                flag = true;
                // throw new invalid move execption
                return;
            }

            //if (__m[king.Position.YCoordinate + dirY, king.Position.XCoordinate + dirX] == 'A')
            //{
            //    __m[king.Position.YCoordinate + dirY, king.Position.XCoordinate + dirX] = 'K';
            //    __m[pawns[0].Position.YCoordinate, pawns[0].Position.XCoordinate] = '-';
            //}

            //if (__m[king.Position.YCoordinate + dirY, king.Position.XCoordinate + dirX] == 'B')
            //{
            //    __m[king.Position.YCoordinate + dirY, king.Position.XCoordinate + dirX] = 'K';
            //    __m[pawns[1].Position.YCoordinate, pawns[1].Position.XCoordinate] = '-';
            //}

            //if (__m[king.Position.YCoordinate + dirY, king.Position.XCoordinate + dirX] == 'C')
            //{
            //    __m[king.Position.YCoordinate + dirY, king.Position.XCoordinate + dirX] = 'K';
            //    __m[pawns[2].Position.YCoordinate, pawns[2].Position.XCoordinate] = '-';
            //}

            //if (__m[king.Position.YCoordinate + dirY, king.Position.XCoordinate + dirX] == 'D')
            //{
            //    __m[king.Position.YCoordinate + dirY, king.Position.XCoordinate + dirX] = 'K';
            //    __m[pawns[3].Position.YCoordinate, pawns[3].Position.XCoordinate] = '-';
            //}

            //__m[king.Position.YCoordinate, king.Position.XCoordinate] = '+';
            //__m[king.Position.YCoordinate + dirY, king.Position.XCoordinate + dirX] = 'K';

            var kingcurrentPosition = king.Position;

            kingcurrentPosition.YCoordinate += dirY;
            kingcurrentPosition.XCoordinate += dirX;

            king.Position = kingcurrentPosition;

            chessBoard.Cells[kingXCoordinate + dirX, kingYCoordinate + dirY].ChessFigure = chessBoard.Cells[kingXCoordinate, kingYCoordinate].ChessFigure;
            chessBoard.Cells[kingXCoordinate, kingYCoordinate].ChessFigure = null;
        }

        private static bool PawnMove(int dirX, int dirY, int pawnNumber, char pawnName)
        {
            //// sledvat mnogo proverki
            //if (pawns[pawnNumber].Position.XCoordinate + dirX < 0
            //    || pawns[pawnNumber].Position.XCoordinate + dirX > Size - 1)
            //{
            //    Console.WriteLine("Invalid Move!");
            //    Console.WriteLine("**Press Enter to continue**");
            //    Console.ReadLine();
            //    flag = false;
            //    return false;
            //}

            //if (pawns[pawnNumber].Position.YCoordinate + dirY < 0
            //    || pawns[pawnNumber].Position.YCoordinate + dirY > Size - 1)
            //{
            //    Console.WriteLine("Invalid Move!");
            //    Console.WriteLine("**Press Enter to continue**");
            //    Console.ReadLine();
            //    flag = false;
            //    return false;
            //}

            //if (matrix[pawns[pawnNumber].Position.YCoordinate + dirY, pawns[pawnNumber].Position.XCoordinate + dirX]
            //    == 'K')
            //{
            //    Console.WriteLine("Pawn`s win!");
            //    return true;
            //}

            //// check cell is empty to move.
            //if (matrix[pawns[pawnNumber].Position.YCoordinate + dirY, pawns[pawnNumber].Position.XCoordinate + dirX]
            //    != '+')
            //{
            //    Console.WriteLine("Invalid Move!");
            //    Console.WriteLine("**Press Enter to continue**");
            //    Console.ReadLine();
            //    flag = false;
            //    return false;
            //}

            //// ako ne grymne do momenta znachi e validen hoda
            //matrix[pawns[pawnNumber].Position.YCoordinate, pawns[pawnNumber].Position.XCoordinate] = '+';
            //matrix[pawns[pawnNumber].Position.YCoordinate + dirY, pawns[pawnNumber].Position.XCoordinate + dirX] =
            //    pawnName;

            //var pawnCurrentPosition = pawns[pawnNumber].Position;

            //pawnCurrentPosition.YCoordinate += dirY;
            //pawnCurrentPosition.XCoordinate += dirX;

            //pawns[pawnNumber].Position = pawnCurrentPosition;

            return false;
        }

        public static void Main()
        {
            chessBoard[0, 0] = new Cell(new Figure('A'));
            chessBoard.Cells[2, 0]= new Cell( new Figure('B'));
            chessBoard.Cells[4, 0]= new Cell( new Figure('C'));
            chessBoard.Cells[6, 0]= new Cell( new Figure('D'));
            chessBoard.Cells[2, 0]= new Cell( new Figure('K'));

            Renderer.Render(chessBoard);

            bool? flag2 = false;

            flag2 = Play(flag2, ConsoleCommander);
            if (flag2 == true)
            {
                Console.WriteLine("Pawn`s win!");
            }
            else if (flag2 == false)
            {
                Console.WriteLine("King`s win!");
            }
        }

        private static bool? Play(bool? flag2, IUserInterface userCommander)
        {
            while (king.Position.YCoordinate > 0 && king.Position.YCoordinate < Size && !flag2 == true)
            {
                flag = true;
                while (flag)
                {
                    flag = false;

                    Console.Write("King`s Turn:");
                    var command = userCommander.SendCommand();
                    var name = command.ComandeeName;
                    var move = command.MoveCommand;

                    KingMove(name, move);

                    Renderer.Render(chessBoard);
                }

                while (!flag)
                {
                    flag = true;
                    Renderer.Render(chessBoard);
                    Console.Write("Pawn`s Turn:");
                    var input = Console.ReadLine();
                    if (input == string.Empty)
                    {
                        flag = false;
                        continue;
                    }

                    var commands = input.ToUpper().Split(' ');
                    var direction = commands[0];

                    switch (direction)
                    {
                        case "ADR":
                            {
                                flag2 = PawnMove(1, 1, 0, 'A');
                                break;
                            }

                        case "ADL":
                            {
                                flag2 = PawnMove(-1, 1, 0, 'A');
                                break;
                            }

                        case "BDL":
                            {
                                flag2 = PawnMove(-1, 1, 1, 'B');
                                break;
                            }

                        case "BDR":
                            {
                                flag2 = PawnMove(1, 1, 1, 'B');
                                break;
                            }

                        case "CDL":
                            {
                                flag2 = PawnMove(-1, 1, 2, 'C');
                                break;
                            }

                        case "CDR":
                            {
                                flag2 = PawnMove(1, 1, 2, 'C');
                                break;
                            }

                        case "DDR":
                            {
                                flag2 = PawnMove(1, 1, 3, 'D');
                                break;
                            }

                        case "DDL":
                            {
                                flag2 = PawnMove(-1, 1, 3, 'D');
                                break;
                            }

                        default:
                            {
                                flag = false;
                                Console.WriteLine("Invalid input!");
                                Console.WriteLine("**Press Enter to continue**");
                                Console.ReadLine();
                                break;
                            }
                    }

                    Renderer.Render(chessBoard);

                    if (CheckForExitCommand(commands))
                    {
                        return null;
                    }
                }
            }

            return flag2;
        }

        private static bool CheckForExitCommand(string[] commands)
        {
            if (commands.Length > 1)
            {
                if (commands[1] == "EXIT")
                {
                    return true;
                }
            }

            return false;
        }
    }
}