namespace KingSurvivalRefactored.GameCore
{
    using KingSurvivalRefactored.UserInteraction;

    public interface IGameEngine
    {
        IUserCommand RecieveCommand(IUserInterface userInterface);
    }
}
