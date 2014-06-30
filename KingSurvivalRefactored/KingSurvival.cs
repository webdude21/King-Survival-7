namespace KingSurvivalRefactored
{
    using System;

    using KingSurvivalRefactored.GameCore;

    internal class KingSurvival
    {
        private const int FieldSize = 8;
        private static readonly IChessPiece PawnA = PieceFactory.GetPawn(new ChessCell(0, 0));
        private static readonly IChessPiece PawnB = PieceFactory.GetPawn(new ChessCell(2, 0));
        private static readonly IChessPiece PawnC = PieceFactory.GetPawn(new ChessCell(4, 0));
        private static readonly IChessPiece PawnD = PieceFactory.GetPawn(new ChessCell(6, 0));
        private static readonly IChessPiece KingK = PieceFactory.GetKing(new ChessCell(3, 7));

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
                return FieldSize;
            }
        }

        private void Print(char[,] matrix)
        {
            Console.Clear();

            for (var i = 0; i < FieldSize; i++)
            {
                for (var j = 0; j < FieldSize; j++)
                {
                    Console.Write("{0,2}", matrix[i, j]);
                }

                Console.WriteLine(string.Empty);
            }
        }

        private static void Try(int dirX, int dirY, char[,] gameField)
        {
            if (KingK.Position.XCoordinate + dirX < 0 || KingK.Position.XCoordinate + dirX > FieldSize - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = true;
                return;
            }

            if (KingK.Position.YCoordinate + dirY < 0 || KingK.Position.YCoordinate + dirY > FieldSize - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = true;
                return;
            }

            if (gameField[KingK.Position.YCoordinate + dirY, KingK.Position.XCoordinate + dirX] == 'A')
            {
                gameField[KingK.Position.YCoordinate + dirY, KingK.Position.XCoordinate + dirX] = 'K';
                gameField[PawnA.Position.YCoordinate, PawnA.Position.XCoordinate] = '-';
            }

            if (gameField[KingK.Position.YCoordinate + dirY, KingK.Position.XCoordinate + dirX] == 'B')
            {
                gameField[KingK.Position.YCoordinate + dirY, KingK.Position.XCoordinate + dirX] = 'K';
                gameField[PawnB.Position.YCoordinate, PawnB.Position.XCoordinate] = '-';
            }

            if (gameField[KingK.Position.YCoordinate + dirY, KingK.Position.XCoordinate + dirX] == 'C')
            {
                gameField[KingK.Position.YCoordinate + dirY, KingK.Position.XCoordinate + dirX] = 'K';
                gameField[PawnC.Position.YCoordinate, PawnC.Position.XCoordinate] = '-';
            }

            if (gameField[KingK.Position.YCoordinate + dirY, KingK.Position.XCoordinate + dirX] == 'D')
            {
                gameField[KingK.Position.YCoordinate + dirY, KingK.Position.XCoordinate + dirX] = 'K';
                gameField[PawnD.Position.YCoordinate, PawnD.Position.XCoordinate] = '-';
            }

            gameField[KingK.Position.YCoordinate, KingK.Position.XCoordinate] = '-';
            gameField[KingK.Position.YCoordinate + dirY, KingK.Position.XCoordinate + dirX] = 'K';
            var kingcurrentPosition = KingK.Position;
            kingcurrentPosition.YCoordinate += dirY;
            kingcurrentPosition.XCoordinate += dirX;
            KingK.Position = kingcurrentPosition;
        }

        // abe tuka sym gi napravil edni... ama raboti
        // kvo kat sa 4 metoda
        private static bool PawnAMove(int dirX, int dirY, char[,] matrix)
        {
            // sledvat mnogo proverki
            if (PawnA.Position.XCoordinate + dirX < 0 || PawnA.Position.XCoordinate + dirX > FieldSize - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            if (PawnA.Position.YCoordinate + dirY < 0 || PawnA.Position.YCoordinate + dirY > FieldSize - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            if (matrix[PawnA.Position.YCoordinate + dirY, PawnA.Position.XCoordinate + dirX] == 'K')
            {
                Console.WriteLine("Pawn`s win!");
                return true;
            }

            if (matrix[PawnA.Position.YCoordinate + dirY, PawnA.Position.XCoordinate + dirX] == 'D'
                || matrix[PawnA.Position.YCoordinate + dirY, PawnA.Position.XCoordinate + dirX] == 'B'
                || matrix[PawnA.Position.YCoordinate + dirY, PawnA.Position.XCoordinate + dirX] == 'C')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            // ako ne grymne do momenta znachi e validen hoda
            matrix[PawnA.Position.YCoordinate, PawnA.Position.XCoordinate] = '-';
            matrix[PawnA.Position.YCoordinate + dirY, PawnA.Position.XCoordinate + dirX] = 'A';
            var pawnCurrentPosition = PawnA.Position;
            pawnCurrentPosition.YCoordinate += dirY;
            pawnCurrentPosition.XCoordinate += dirX;
            PawnA.Position = pawnCurrentPosition;
            return false;
        }

        private static bool PawnBMove(int dirX, int dirY, char[,] matrix)
        {
            // za dokumentaciq pregledai PawnAMove
            if (PawnB.Position.XCoordinate + dirX < 0 || PawnB.Position.XCoordinate + dirX > FieldSize - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            if (PawnB.Position.YCoordinate + dirY < 0 || PawnB.Position.YCoordinate + dirY > FieldSize - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            if (matrix[PawnB.Position.YCoordinate + dirY, PawnB.Position.XCoordinate + dirX] == 'K')
            {
                Console.WriteLine("Pawn`s win!");
                return true;
            }

            if (matrix[PawnB.Position.YCoordinate + dirY, PawnB.Position.XCoordinate + dirX] == 'A'
                || matrix[PawnB.Position.YCoordinate + dirY, PawnB.Position.XCoordinate + dirX] == 'C'
                || matrix[PawnB.Position.YCoordinate + dirY, PawnB.Position.XCoordinate + dirX] == 'D')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            matrix[PawnB.Position.YCoordinate, PawnB.Position.XCoordinate] = '-';
            matrix[PawnB.Position.YCoordinate + dirY, PawnB.Position.XCoordinate + dirX] = 'B';
            var pawnCurrentPosition = PawnB.Position;
            pawnCurrentPosition.YCoordinate += dirY;
            pawnCurrentPosition.XCoordinate += dirX;
            PawnB.Position = pawnCurrentPosition;
            return false;
        }

        private static bool PawnCMove(int dirX, int dirY, char[,] matrix)
        {
            // za dokumentaciq pregledai PawnAMove
            if (PawnC.Position.XCoordinate + dirX < 0 || PawnC.Position.XCoordinate + dirX > FieldSize - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            if (PawnC.Position.YCoordinate + dirY < 0 || PawnC.Position.YCoordinate + dirY > FieldSize - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            if (matrix[PawnC.Position.YCoordinate + dirY, PawnC.Position.XCoordinate + dirX] == 'K')
            {
                Console.WriteLine("Pawn`s win!");
                return true;
            }

            if (matrix[PawnC.Position.YCoordinate + dirY, PawnC.Position.XCoordinate + dirX] == 'A'
                || matrix[PawnC.Position.YCoordinate + dirY, PawnC.Position.XCoordinate + dirX] == 'B'
                || matrix[PawnC.Position.YCoordinate + dirY, PawnC.Position.XCoordinate + dirX] == 'D')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            matrix[PawnC.Position.YCoordinate, PawnC.Position.XCoordinate] = '-';
            matrix[PawnC.Position.YCoordinate + dirY, PawnC.Position.XCoordinate + dirX] = 'C';

            var pawnCurrentPosition = PawnC.Position;

            pawnCurrentPosition.YCoordinate += dirY;
            pawnCurrentPosition.XCoordinate += dirX;

            PawnC.Position = pawnCurrentPosition;

            return false;
        }

        private static bool PawnDMove(int dirX, int dirY, char[,] matrix)
        {
            // za dokumentaciq pregledai PawnAMove
            if (PawnD.Position.YCoordinate + dirY < 0 || PawnD.Position.YCoordinate + dirY > FieldSize - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            if (PawnD.Position.XCoordinate + dirX < 0 || PawnD.Position.XCoordinate + dirX > FieldSize - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            if (matrix[PawnD.Position.YCoordinate + dirY, PawnD.Position.XCoordinate + dirX] == 'K')
            {
                Console.WriteLine("Pawn`s win!");
                return true;
            }

            if (matrix[PawnD.Position.YCoordinate + dirY, PawnD.Position.XCoordinate + dirX] == 'A'
                || matrix[PawnD.Position.YCoordinate + dirY, PawnD.Position.XCoordinate + dirX] == 'B'
                || matrix[PawnD.Position.YCoordinate + dirY, PawnD.Position.XCoordinate + dirX] == 'C')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            matrix[PawnD.Position.YCoordinate, PawnD.Position.XCoordinate] = '-';
            matrix[PawnD.Position.YCoordinate + dirY, PawnD.Position.XCoordinate + dirX] = 'D';

            var pawnCurrentPosition = PawnD.Position;

            pawnCurrentPosition.YCoordinate += dirY;
            pawnCurrentPosition.XCoordinate += dirX;

            PawnD.Position = pawnCurrentPosition;

            return false;
        }

        private static void Main()
        {
            char[,] m =
                {
                    { '+', '-', '+', '-', '+', '-', '+', '-' }, { '-', '+', '-', '+', '-', '+', '-', '+' }, 
                    { '+', '-', '+', '-', '+', '-', '+', '-' }, { '-', '+', '-', '+', '-', '+', '-', '+' }, 
                    { '+', '-', '+', '-', '+', '-', '+', '-' }, { '-', '+', '-', '+', '-', '+', '-', '+' }, 
                    { '+', '-', '+', '-', '+', '-', '+', '-' }, { '-', '+', '-', '+', '-', '+', '-', '+' }
                };

            m[PawnA.Position.YCoordinate, PawnA.Position.XCoordinate] = 'A';
            m[PawnD.Position.YCoordinate, PawnD.Position.XCoordinate] = 'D';
            m[PawnB.Position.YCoordinate, PawnB.Position.XCoordinate] = 'B';
            m[PawnC.Position.YCoordinate, PawnC.Position.XCoordinate] = 'C';
            m[KingK.Position.YCoordinate, KingK.Position.XCoordinate] = 'K';
            (new KingSurvival()).Print(m);
            var flag2 = false;

            flag2 = Play(m, flag2);
            if (flag2)
            {
                Console.WriteLine("Pawn`s win!");
            }
            else
            {
                Console.WriteLine("King`s win!");
            }
        }

        private static bool Play(char[,] m, bool flag2)
        {
            while (KingK.Position.YCoordinate > 0 && KingK.Position.YCoordinate < FieldSize && !flag2)
            {
                flag = true;
                while (flag)
                {
                    flag = false;

                    (new KingSurvival()).Print(m);
                    Console.Write("King`s Turn:");
                    var direction = Console.ReadLine();
                    if (direction == string.Empty)
                    {
                        flag = true;
                        continue;
                    }

                    direction = direction.ToUpper();

                    switch (direction)
                    {
                        case "KUL":
                            {
                                Try(-1, -1, m);
                                break;
                            }

                        case "KUR":
                            {
                                Try(1, -1, m);
                                break;
                            }

                        case "KDL":
                            {
                                Try(-1, 1, m);
                                break;
                            }

                        case "KDR":
                            {
                                Try(1, 1, m);
                                break;
                            }

                        default:
                            {
                                flag = true;
                                Console.WriteLine("Invalid input!");
                                Console.WriteLine("**Press a key to continue**");
                                Console.ReadKey();
                                break;
                            }
                    }
                }

                while (!flag)
                {
                    flag = true;
                    (new KingSurvival()).Print(m);
                    Console.Write("Pawn`s Turn:");
                    var dd = Console.ReadLine();
                    if (dd == string.Empty)
                    {
                        flag = false;
                        continue;
                    }

                    dd = dd.ToUpper();

                    switch (dd)
                    {
                        case "ADR":
                            {
                                flag2 = PawnAMove(1, 1, m);
                                break;
                            }

                        case "ADL":
                            {
                                flag2 = PawnAMove(-1, 1, m);
                                break;
                            }

                        case "BDL":
                            {
                                flag2 = PawnBMove(-1, 1, m);
                                break;
                            }

                        case "BDR":
                            {
                                flag2 = PawnBMove(1, 1, m);
                                break;
                            }

                        case "CDL":
                            {
                                flag2 = PawnCMove(-1, 1, m);
                                break;
                            }

                        case "CDR":
                            {
                                flag2 = PawnCMove(1, 1, m);
                                break;
                            }

                        case "DDR":
                            {
                                flag2 = PawnDMove(1, 1, m);
                                break;
                            }

                        case "DDL":
                            {
                                flag2 = PawnDMove(-1, 1, m);
                                break;
                            }

                        default:
                            {
                                flag = false;
                                Console.WriteLine("Invalid input!");
                                Console.WriteLine("**Press a key to continue**");
                                Console.ReadKey();
                                break;
                            }
                    }

                    (new KingSurvival()).Print(m);
                }
            }

            return flag2;
        }
    }
}