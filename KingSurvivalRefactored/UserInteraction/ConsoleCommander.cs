namespace KingSurvivalRefactored.UserInteraction
{
    using System;

    using KingSurvivalRefactored.GameCore;

    public class ConsoleCommander : IUserInterface
    {
        private const string InvalidCommandMessage = "The command is not valid!";

        private const string ArgumantNullOrEmpty = "The command is null or empty";

        public IUserCommand SendCommand()
        {
            var direction = ReadUserCommand();
            return InterpretUserCommand(direction);
        }

        private static string ReadUserCommand()
        {
            var input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(ArgumantNullOrEmpty);
            }

            var commands = input.ToUpper().Split(' ');

            if (CheckForExitCommand(commands))
            {
                return null;
            }

            var direction = commands[0];
            return direction;
        }

        private static IUserCommand InterpretUserCommand(string command)
        {
            var nameOfReciever = command[0];
            var directionCommand = command.Substring(1);
            Movements movement;

            switch (directionCommand)
            {
                case "UL":
                    movement = Movements.UpLeft;
                    break;
                case "UR":
                    movement = Movements.UpRight;
                    break;
                case "DL":
                    movement = Movements.DownLeft;
                    break;
                case "DR":
                    movement = Movements.DownRight;
                    break;
                default:
                    throw new ArgumentException(InvalidCommandMessage);
            }

            return new UserCommand(nameOfReciever, movement);
        }

        private static bool CheckForExitCommand(string[] commands)
        {
            if (commands.Length > 1)
            {
                if (commands[1] == "EXIT")
                {
                    return true;
                }
            }

            return false;
        }
    }
}