namespace KingSurvivalRefactored.UserInteraction
{
    using KingSurvivalRefactored.GameCore;

    internal class UserCommand : IUserCommand
    {
        public UserCommand(char commandeeName, Movements moveCommand)
        {
            this.MoveCommand = moveCommand;
            this.ComandeeName = commandeeName;
        }

        public char ComandeeName { get; private set; }

        public Movements MoveCommand { get; private set; }
    }
}