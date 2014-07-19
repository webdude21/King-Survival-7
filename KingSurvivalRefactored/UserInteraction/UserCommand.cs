namespace KingSurvivalRefactored.UserInteraction
{
    using KingSurvivalRefactored.GameCore;

    internal class UserCommand : IUserCommand
    {
        public UserCommand(string comandeeName, Movements moveCommand)
        {
            this.MoveCommand = moveCommand;
            this.ComandeeName = comandeeName;
        }

        public string ComandeeName { get; private set; }

        public Movements MoveCommand { get; private set; }
    }
}