namespace KingSurvivalRefactored
{
    using KingSurvivalRefactored.GameCore;
    using System;

    internal class KingSurvival
    {
        private static int size = 8;

        private static IChessPiece pawnA = PieceFactory.GetPawn(new ChessCell(0, 0));
        private static IChessPiece pawnB = PieceFactory.GetPawn(new ChessCell(2, 0));
        private static IChessPiece pawnC = PieceFactory.GetPawn(new ChessCell(4, 0));
        private static IChessPiece pawnD = PieceFactory.GetPawn(new ChessCell(6, 0));
        private static IChessPiece kingK = PieceFactory.GetKing(new ChessCell(3, 7));

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
            if (kingK.Position.XCoordinate + dirX < 0 || kingK.Position.XCoordinate + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = true;
                return;
            }

            if (kingK.Position.YCoordinate + dirY < 0 || kingK.Position.YCoordinate + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = true;
                return;
            }

            if (__m[kingK.Position.YCoordinate + dirY, kingK.Position.XCoordinate + dirX] == 'A')
            {
                __m[kingK.Position.YCoordinate + dirY, kingK.Position.XCoordinate + dirX] = 'K';
                __m[pawnA.Position.YCoordinate, pawnA.Position.XCoordinate] = '-';
            }

            if (__m[kingK.Position.YCoordinate + dirY, kingK.Position.XCoordinate + dirX] == 'B')
            {
                __m[kingK.Position.YCoordinate + dirY, kingK.Position.XCoordinate + dirX] = 'K';
                __m[pawnB.Position.YCoordinate, pawnB.Position.XCoordinate] = '-';
            }

            if (__m[kingK.Position.YCoordinate + dirY, kingK.Position.XCoordinate + dirX] == 'C')
            {
                __m[kingK.Position.YCoordinate + dirY, kingK.Position.XCoordinate + dirX] = 'K';
                __m[pawnC.Position.YCoordinate, pawnC.Position.XCoordinate] = '-';
            }

            if (__m[kingK.Position.YCoordinate + dirY, kingK.Position.XCoordinate + dirX] == 'D')
            {
                __m[kingK.Position.YCoordinate + dirY, kingK.Position.XCoordinate + dirX] = 'K';
                __m[pawnD.Position.YCoordinate, pawnD.Position.XCoordinate] = '-';
            }

            __m[kingK.Position.YCoordinate, kingK.Position.XCoordinate] = '+';
            __m[kingK.Position.YCoordinate + dirY, kingK.Position.XCoordinate + dirX] = 'K';

            var kingcurrentPosition = kingK.Position;
            
            kingcurrentPosition.YCoordinate += dirY;
            kingcurrentPosition.XCoordinate += dirX;
            
            kingK.Position = kingcurrentPosition;
        }

        // abe tuka sym gi napravil edni... ama raboti
        // kvo kat sa 4 metoda
        private static bool PawnAMove(int dirX, int dirY, char[,] matrix)
        {
            // sledvat mnogo proverki
            if (pawnA.Position.XCoordinate + dirX < 0 || pawnA.Position.XCoordinate + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            
            if (pawnA.Position.YCoordinate + dirY < 0 || pawnA.Position.YCoordinate + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            if (matrix[pawnA.Position.YCoordinate + dirY, pawnA.Position.XCoordinate + dirX] == 'K')
            {
                Console.WriteLine("Pawn`s win!");
                return true;
            }

            if (matrix[pawnA.Position.YCoordinate + dirY, pawnA.Position.XCoordinate + dirX] == 'D' || matrix[pawnA.Position.YCoordinate + dirY, pawnA.Position.XCoordinate + dirX] == 'B'
                || matrix[pawnA.Position.YCoordinate + dirY, pawnA.Position.XCoordinate + dirX] == 'C')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            // ako ne grymne do momenta znachi e validen hoda
            matrix[pawnA.Position.YCoordinate, pawnA.Position.XCoordinate] = '+';
            matrix[pawnA.Position.YCoordinate + dirY, pawnA.Position.XCoordinate + dirX] = 'A';

            var pawnCurrentPosition = pawnA.Position;

            pawnCurrentPosition.YCoordinate += dirY;
            pawnCurrentPosition.XCoordinate += dirX;

            pawnA.Position = pawnCurrentPosition;

            return false;
        }

        private static bool PawnBMove(int dirX, int dirY, char[,] matrix)
        {
            // za dokumentaciq pregledai PawnAMove
            if (pawnB.Position.XCoordinate + dirX < 0 || pawnB.Position.XCoordinate + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            if (pawnB.Position.YCoordinate + dirY < 0 || pawnB.Position.YCoordinate + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            if (matrix[pawnB.Position.YCoordinate + dirY, pawnB.Position.XCoordinate + dirX] == 'K')
            {
                Console.WriteLine("Pawn`s win!");
                return true;
            }

            if (matrix[pawnB.Position.YCoordinate + dirY, pawnB.Position.XCoordinate + dirX] == 'A' || matrix[pawnB.Position.YCoordinate + dirY, pawnB.Position.XCoordinate + dirX] == 'C'
                || matrix[pawnB.Position.YCoordinate + dirY, pawnB.Position.XCoordinate + dirX] == 'D')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            matrix[pawnB.Position.YCoordinate, pawnB.Position.XCoordinate] = '+';
            matrix[pawnB.Position.YCoordinate + dirY, pawnB.Position.XCoordinate + dirX] = 'B';

            var pawnCurrentPosition = pawnB.Position;

            pawnCurrentPosition.YCoordinate += dirY;
            pawnCurrentPosition.XCoordinate += dirX;

            pawnB.Position = pawnCurrentPosition;

            return false;
        }

        private static bool PawnCMove(int dirX, int dirY, char[,] matrix)
        {
            // za dokumentaciq pregledai PawnAMove
            if (pawnC.Position.XCoordinate + dirX < 0 || pawnC.Position.XCoordinate + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            if (pawnC.Position.YCoordinate + dirY < 0 || pawnC.Position.YCoordinate + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            if (matrix[pawnC.Position.YCoordinate + dirY, pawnC.Position.XCoordinate + dirX] == 'K')
            {
                Console.WriteLine("Pawn`s win!");
                return true;
            }

            if (matrix[pawnC.Position.YCoordinate + dirY, pawnC.Position.XCoordinate + dirX] == 'A' || matrix[pawnC.Position.YCoordinate + dirY, pawnC.Position.XCoordinate + dirX] == 'B'
                || matrix[pawnC.Position.YCoordinate + dirY, pawnC.Position.XCoordinate + dirX] == 'D')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            matrix[pawnC.Position.YCoordinate, pawnC.Position.XCoordinate] = '+';
            matrix[pawnC.Position.YCoordinate + dirY, pawnC.Position.XCoordinate + dirX] = 'C';

            var pawnCurrentPosition = pawnC.Position;
           
            pawnCurrentPosition.YCoordinate += dirY;
            pawnCurrentPosition.XCoordinate += dirX;
           
            pawnC.Position = pawnCurrentPosition;
      
            return false;
        }

        private static bool PawnDMove(int dirX, int dirY, char[,] matrix)
        {
            // za dokumentaciq pregledai PawnAMove
            if (pawnD.Position.YCoordinate + dirY < 0 || pawnD.Position.YCoordinate + dirY > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            if (pawnD.Position.XCoordinate + dirX < 0 || pawnD.Position.XCoordinate + dirX > size - 1)
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            if (matrix[pawnD.Position.YCoordinate + dirY, pawnD.Position.XCoordinate + dirX] == 'K')
            {
                Console.WriteLine("Pawn`s win!");
                return true;
            }

            if (matrix[pawnD.Position.YCoordinate + dirY, pawnD.Position.XCoordinate + dirX] == 'A' || matrix[pawnD.Position.YCoordinate + dirY, pawnD.Position.XCoordinate + dirX] == 'B'
                || matrix[pawnD.Position.YCoordinate + dirY, pawnD.Position.XCoordinate + dirX] == 'C')
            {
                Console.WriteLine("Invalid Move!");
                Console.WriteLine("**Press a key to continue**");
                Console.ReadKey();
                flag = false;
                return false;
            }

            matrix[pawnD.Position.YCoordinate, pawnD.Position.XCoordinate] = '+';
            matrix[pawnD.Position.YCoordinate + dirY, pawnD.Position.XCoordinate + dirX] = 'D';
        
            var pawnCurrentPosition = pawnD.Position;

            pawnCurrentPosition.YCoordinate += dirY;
            pawnCurrentPosition.XCoordinate += dirX;

            pawnD.Position = pawnCurrentPosition;

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

            m[pawnA.Position.YCoordinate, pawnA.Position.XCoordinate] = 'A';
            m[pawnD.Position.YCoordinate, pawnD.Position.XCoordinate] = 'D';
            m[pawnB.Position.YCoordinate, pawnB.Position.XCoordinate] = 'B';
            m[pawnC.Position.YCoordinate, pawnC.Position.XCoordinate] = 'C';
            m[kingK.Position.YCoordinate, kingK.Position.XCoordinate] = 'K';
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
            while (kingK.Position.YCoordinate > 0 && kingK.Position.YCoordinate < size && !flag2)
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

                    var commands = direction.ToUpper().Split(' ');
                    direction = commands[0];
                    
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

                    CheckForExitCommand(commands);
                }

                while (!flag)
                {
                    flag = true;
                    (new KingSurvival()).Print(m);
                    Console.Write("Pawn`s Turn:");
                    var direction = Console.ReadLine();
                    if (direction == string.Empty)
                    {
                        flag = false;
                        continue;
                    }

                    var commands = direction.ToUpper().Split(' ');
                    direction = commands[0];

                    switch (direction)
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

                    CheckForExitCommand(commands);

                    (new KingSurvival()).Print(m);
                }
            }

            return flag2;
        }

        private static void CheckForExitCommand(string[] commands)
        {
            if (commands.Length > 1)
            {
                if (commands[1] == "EXIT")
                {
                    Environment.Exit(10);
                }
            }
        }
    }
}