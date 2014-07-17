namespace KingSurvivalRefactored.UserInteraction
{
    using System;

    using KingSurvivalRefactored.GameCore;

    public class ConsoleCommander : IUserCommand
    {
        private const string InvalidCommandMessage = "The command is not valid!";

        public Movements ReadCommand()
        {
            var input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                // do something
                // maybe throw exception
            }

            var commands = input.ToUpper().Split(' ');
            var direction = commands[0];

            switch (direction)
            {
                case "KUL":
                    return Movements.UpLeft;
                case "KUR":
                    return Movements.UpRight;
                case "KDL":
                    return Movements.DownLeft;
                case "KDR":
                    return Movements.DownRight;
                default:
                    throw new ArgumentException(InvalidCommandMessage);
            }
        }

        public void IssueMoveCommand(IMovable comandee)
        {
            throw new NotImplementedException();
        }
    }
}