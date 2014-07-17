namespace KingSurvivalRefactored.UserInteraction
{
    using System;
    using KingSurvivalRefactored.GameCore;

    public class ConsoleCommander : IUserCommand
    {
        private const string InvalidCommandMessage = "The command is not valid!";
        private const string ArgumantNullOrEmpty = "The command is null or empty";

        public void ExecuteUserCommand(IMovable comandee)
        {
            var direction = ReadUserCommand();
            var userCommand = InterpretUserCommand(direction);
            IssueMoveCommand(comandee, userCommand);
        }

        private static string ReadUserCommand()
        {
            var input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(ArgumantNullOrEmpty);
            }

            var direction = input.ToUpper().Split(' ')[0];
            return direction;
        }

        private static Movements InterpretUserCommand(string direction)
        {
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

        private static void IssueMoveCommand(IMovable comandee, Movements command)
        {
            comandee.Move(command);
        }
    }
}