namespace KingSurvivalRefactored.UserInteraction
{
    using KingSurvivalRefactored.GameCore;

    public interface IControler
    {
        Movements SendCommand(IMovable moveblePiece);
    }
}