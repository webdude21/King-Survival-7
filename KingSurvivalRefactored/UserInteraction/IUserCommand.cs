namespace KingSurvivalRefactored.UserInteraction
{
    using KingSurvivalRefactored.Enums;
    using KingSurvivalRefactored.GameCore;

    public interface IUserCommand
    {
        char ComandeeName { get; }

        Movements MoveCommand { get; }
    }
}