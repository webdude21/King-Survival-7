namespace KingSurvivalRefactored.GameCore
{
    using KingSurvivalRefactored.UserInteraction;

    public interface IGameEngine
    {
        void RecieveCommand(IUserCommand userCommand);
    }
}
