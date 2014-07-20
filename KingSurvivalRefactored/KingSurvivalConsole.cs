namespace KingSurvivalRefactored
{
    using KingSurvivalRefactored.GameCore;
  
    public class KingSurvivalConsole
    {
        public static void Main()
        {
            var gameEngine = new GameEngine();
            gameEngine.RunGame();
        }
    }
}