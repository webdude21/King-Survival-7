namespace KingSurvivalRefactored
{
    using KingSurvivalRefactored.GameCore;
    using KingSurvivalRefactored.GameRenderer;
    using KingSurvivalRefactored.UserInteraction;

    public class KingSurvival
    {
        public static void Main()
        {
            var ConsoleCommander = new ConsoleCommander();
            var Renderer = new ConsoleRenderer();

            var gameEngine = new GameEngine(ConsoleCommander, Renderer);
            gameEngine.RunGame();
        }
    }
}