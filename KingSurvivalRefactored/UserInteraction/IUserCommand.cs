namespace KingSurvivalRefactored.UserInteraction
{
    using KingSurvivalRefactored.Enums;

    public interface IUserCommand
    {
        char ComandeeName { get; }

        Movements MoveCommand { get; }
    }
}