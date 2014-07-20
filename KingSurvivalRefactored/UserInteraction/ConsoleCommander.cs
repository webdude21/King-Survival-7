namespace KingSurvivalRefactored.UserInteraction
{
    using System;

    using KingSurvivalRefactored.GameCore;

    public class ConsoleCommander : IUserInterface
    {
        private const string InvalidCommandMessage = "The command is not valid!";
        private const string ExitCommand = "EXIT";
        private const string ArgumantNullOrEmpty = "The command is null or empty";

        public IUserCommand ReadUserCommand()
        {
            var input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                // TODO throw invalid command exepction
                throw new NotImplementedException();
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
    }
}