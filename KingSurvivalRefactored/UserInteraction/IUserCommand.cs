namespace KingSurvivalRefactored.UserInteraction
{
    using KingSurvivalRefactored.GameCore;

    public interface IUserCommand
    {
        void ExecuteUserCommand(IMovable comandee);
    }
}