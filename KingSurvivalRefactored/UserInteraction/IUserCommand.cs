namespace KingSurvivalRefactored.UserInteraction
{
    using KingSurvivalRefactored.GameCore;

    public interface IUserCommand
    {
        string ComandeeName { get; }
        Movements MoveCommand { get; }
    }
}