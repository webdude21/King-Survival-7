namespace KingSurvivalRefactored.GameCore
{

    public static class Factory
    {
        public static IChessPiece GetPawn(ChessCell position)
        {
            return new Pawn(position);
        }

        public static IChessPiece GetKing(ChessCell position)
        {
            return new King(position);
        }
    }
}
