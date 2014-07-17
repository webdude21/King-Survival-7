namespace KingSurvivalRefactored.UserInteraction
{
    using KingSurvivalRefactored.GameCore;

    public interface IUserCommand
    {
        Movements ReadCommand(string command);

        void IssueMoveCommand(IMovable comandee);
    }
}