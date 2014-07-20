namespace KingSurvivalRefactored.UserInteraction
{
    using System;

    using KingSurvivalRefactored.GameCore;

    public class ConsoleCommander : IUserInterface
    {
        private const string ExitCommand = "EXIT";

        private const string UpLeftCommand = "UL";

        private const string UpRightCommand = "UR";

        private const string DownLeftCommand = "DL";

        private const string DownRightCommand = "DR";

        public IUserCommand ReadUserCommand()
        {
            var input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                throw new InvalidCommandException();
            }

            return InterpretUserCommand(input.ToUpper());
        }

        private static IUserCommand InterpretUserCommand(string command)
        {
            var nameOfReciever = command[0];
            var directionCommand = command.Substring(1);
            Movements movement;

            if (command == ExitCommand)
            {
                throw new GameExitException();
            }

            switch (directionCommand)
            {
                case UpLeftCommand:
                    movement = Movements.UpLeft;
                    break;
                case UpRightCommand:
                    movement = Movements.UpRight;
                    break;
                case DownLeftCommand:
                    movement = Movements.DownLeft;
                    break;
                case DownRightCommand:
                    movement = Movements.DownRight;
                    break;
                default:
                    throw new InvalidCommandException();
            }

            return new UserCommand(nameOfReciever, movement);
        }
    }
}