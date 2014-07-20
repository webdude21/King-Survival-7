namespace TestKingSurvival
{
    using KingSurvivalRefactored.Enums;
    using KingSurvivalRefactored.GameCore;
    using KingSurvivalRefactored.UserInteraction;

    public class MockUserInterface : IUserInterface
    {
        internal IUserCommand TestUserCommand { get; private set; }

        public IUserCommand ReadUserCommand()
        {
            return this.TestUserCommand;
        }

        public void SetMoveCommand(char name, Movements moveDirection)
        {
            this.TestUserCommand = new UserCommand(name, moveDirection);
        }
    }
}