namespace KingSurvivalRefactored
{
    using KingSurvivalRefactored.GameCore;
    using System;
    using System.Collections.Generic;

    public class KingSurvival
    {
        private static int size = 8;

        private static List<IChessPiece> pawns;
        private static IChessPiece king;

        private static bool flag = true;

        public static bool IsKingTurn
        {
            get
            {
                return flag;
            }
        }


        public static int Size
        {
            get
            {
                return size;
            }
        }

        private void Print(char[,] matrix)
        {
            Console.Clear();

            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    Console.Write("{0,2}", matrix[i, j]);
                }

                Console.WriteLine(string.Empty);
            }
        }

        private static void Try(int dirX, int dirY, char[,] __m)
        {
            if (king.Position.XCoordinate + dirX < 0 || king.Position.XCoordinate + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press Enter to continue**");
                Console.ReadLine();
                flag = true;
                return;
            }

            if (king.Position.YCoordinate + dirY < 0 || king.Position.YCoordinate + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press Enter to continue**");
                Console.ReadLine();
                flag = true;
                return;
            }

            if (__m[king.Position.YCoordinate + dirY, king.Position.XCoordinate + dirX] == 'A')
            {
                __m[king.Position.YCoordinate + dirY, king.Position.XCoordinate + dirX] = 'K';
                __m[pawns[0].Position.YCoordinate, pawns[0].Position.XCoordinate] = '-';
            }

            if (__m[king.Position.YCoordinate + dirY, king.Position.XCoordinate + dirX] == 'B')
            {
                __m[king.Position.YCoordinate + dirY, king.Position.XCoordinate + dirX] = 'K';
                __m[pawns[1].Position.YCoordinate, pawns[1].Position.XCoordinate] = '-';
            }

            if (__m[king.Position.YCoordinate + dirY, king.Position.XCoordinate + dirX] == 'C')
            {
                __m[king.Position.YCoordinate + dirY, king.Position.XCoordinate + dirX] = 'K';
                __m[pawns[2].Position.YCoordinate, pawns[2].Position.XCoordinate] = '-';
            }

            if (__m[king.Position.YCoordinate + dirY, king.Position.XCoordinate + dirX] == 'D')
            {
                __m[king.Position.YCoordinate + dirY, king.Position.XCoordinate + dirX] = 'K';
                __m[pawns[3].Position.YCoordinate, pawns[3].Position.XCoordinate] = '-';
            }

            __m[king.Position.YCoordinate, king.Position.XCoordinate] = '+';
            __m[king.Position.YCoordinate + dirY, king.Position.XCoordinate + dirX] = 'K';

            var kingcurrentPosition = king.Position;
            
            kingcurrentPosition.YCoordinate += dirY;
            kingcurrentPosition.XCoordinate += dirX;
            
            king.Position = kingcurrentPosition;
        }

        private static bool PawnMove(int dirX, int dirY, char[,] matrix, int pawnNumber, char pawnName)
        {
            // sledvat mnogo proverki
            if (pawns[pawnNumber].Position.XCoordinate + dirX < 0 || pawns[pawnNumber].Position.XCoordinate + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press Enter to continue**");
                Console.ReadLine();
                flag = false;
                return false;
            }

            
            if (pawns[pawnNumber].Position.YCoordinate + dirY < 0 || pawns[pawnNumber].Position.YCoordinate + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press Enter to continue**");
                Console.ReadLine();
                flag = false;
                return false;
            }

            if (matrix[pawns[pawnNumber].Position.YCoordinate + dirY, pawns[pawnNumber].Position.XCoordinate + dirX] == 'K')
            {
                Console.WriteLine("Pawn`s win!");
                return true;
            }
            
            // check cell is empty to move.
            if (matrix[pawns[pawnNumber].Position.YCoordinate + dirY, pawns[pawnNumber].Position.XCoordinate + dirX] != '+')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press Enter to continue**");
                Console.ReadLine();
                flag = false;
                return false;
            }

            // ako ne grymne do momenta znachi e validen hoda
            matrix[pawns[pawnNumber].Position.YCoordinate, pawns[pawnNumber].Position.XCoordinate] = '+';
            matrix[pawns[pawnNumber].Position.YCoordinate + dirY, pawns[pawnNumber].Position.XCoordinate + dirX] = pawnName;

            var pawnCurrentPosition = pawns[pawnNumber].Position;

            pawnCurrentPosition.YCoordinate += dirY;
            pawnCurrentPosition.XCoordinate += dirX;

            pawns[pawnNumber].Position = pawnCurrentPosition;

            return false;
        }

        public static void Main()
        {
            pawns = new List<IChessPiece>();
            pawns.Add(PieceFactory.GetPawn(new ChessCell(0, 0)));
            pawns.Add(PieceFactory.GetPawn(new ChessCell(2, 0)));
            pawns.Add( PieceFactory.GetPawn(new ChessCell(4, 0)));
            pawns.Add(PieceFactory.GetPawn(new ChessCell(6, 0)));
            king = PieceFactory.GetKing(new ChessCell(3, 7));

            char[,] ChessBoard =
                {
                    { '+', '-', '+', '-', '+', '-', '+', '-' }, { '-', '+', '-', '+', '-', '+', '-', '+' }, 
                    { '+', '-', '+', '-', '+', '-', '+', '-' }, { '-', '+', '-', '+', '-', '+', '-', '+' }, 
                    { '+', '-', '+', '-', '+', '-', '+', '-' }, { '-', '+', '-', '+', '-', '+', '-', '+' }, 
                    { '+', '-', '+', '-', '+', '-', '+', '-' }, { '-', '+', '-', '+', '-', '+', '-', '+' }
                };

            ChessBoard[pawns[0].Position.YCoordinate, pawns[0].Position.XCoordinate] = 'A';
            ChessBoard[pawns[1].Position.YCoordinate, pawns[1].Position.XCoordinate] = 'B';
            ChessBoard[pawns[2].Position.YCoordinate, pawns[2].Position.XCoordinate] = 'C';
            ChessBoard[pawns[3].Position.YCoordinate, pawns[3].Position.XCoordinate] = 'D';

            ChessBoard[king.Position.YCoordinate, king.Position.XCoordinate] = 'K';
            (new KingSurvival()).Print(ChessBoard);
            bool? flag2 = false;

            flag2 = Play(ChessBoard, flag2);
            if (flag2==true)
            {
                Console.WriteLine("Pawn`s win!");
            }
            else if (flag2==false)
            {
                Console.WriteLine("King`s win!");
            } 
        }

        private static bool? Play(char[,] chessBoard, bool? flag2)
        {
            while (king.Position.YCoordinate > 0 && king.Position.YCoordinate < size && !flag2==true)
            {
                flag = true;
                while (flag)
                {
                    flag = false;

                    Console.Write("King`s Turn:");
                    var input = Console.ReadLine();
                    if (input == string.Empty)
                    {
                        flag = true;
                        continue;
                    }

                    var commands = input.ToUpper().Split(' ');
                    var direction = commands[0];
                    
                    switch (direction)
                    {
                        case "KUL":
                            {
                                Try(-1, -1, chessBoard);
                                break;
                            }

                        case "KUR":
                            {
                                Try(1, -1, chessBoard);
                                break;
                            }

                        case "KDL":
                            {
                                Try(-1, 1, chessBoard);
                                break;
                            }

                        case "KDR":
                            {
                                Try(1, 1, chessBoard);
                                break;
                            }

                        default:
                            {
                                flag = true;
                                Console.WriteLine("Invalid input!");
                                Console.WriteLine("**Press Enter to continue**");
                                Console.ReadLine();
                                break;
                            }
                    }

                    (new KingSurvival()).Print(chessBoard);

                    if (CheckForExitCommand(commands))
                    {
                        return null;
                    }

                    if (king.Position.YCoordinate == 0)
                    {
                        return false;
                    }

                }

                while (!flag)
                {
                    flag = true;
                    (new KingSurvival()).Print(chessBoard);
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
                                flag2 = PawnMove(1, 1, chessBoard,0,'A');
                                break;
                            }

                        case "ADL":
                            {
                                flag2 = PawnMove(-1, 1, chessBoard, 0, 'A');
                                break;
                            }

                        case "BDL":
                            {
                                flag2 = PawnMove(-1, 1, chessBoard, 1, 'B');
                                break;
                            }

                        case "BDR":
                            {
                                flag2 = PawnMove(1, 1, chessBoard, 1, 'B');
                                break;
                            }

                        case "CDL":
                            {
                                flag2 = PawnMove(-1, 1, chessBoard, 2, 'C');
                                break;
                            }

                        case "CDR":
                            {
                                flag2 = PawnMove(1, 1, chessBoard,2, 'C');
                                break;
                            }

                        case "DDR":
                            {
                                flag2 = PawnMove(1, 1, chessBoard, 3, 'D');
                                break;
                            }

                        case "DDL":
                            {
                                flag2 = PawnMove(-1, 1, chessBoard, 3, 'D');
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

                    (new KingSurvival()).Print(chessBoard);

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