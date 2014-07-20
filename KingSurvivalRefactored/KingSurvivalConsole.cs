namespace KingSurvivalRefactored
{
    using KingSurvivalRefactored.GameCore;
    using KingSurvivalRefactored.GameRenderer;
    using KingSurvivalRefactored.UserInteraction;

    public class KingSurvivalConsole
    {
        public static void Main()
        {
            var consoleCommander = new ConsoleCommander();
            var renderer = new ConsoleRenderer();
            var gameEngine = new GameEngine(consoleCommander, renderer);
            gameEngine.RunGame();
        }
    }
}