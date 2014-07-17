namespace KingSurvivalRefactored.UserInteraction
{
    using KingSurvivalRefactored.GameCore;

    public interface IUserCommand
    {
        Movements ReadCommand();

        void IssueMoveCommand(IMovable comandee);
    }
}