namespace TestKingSurvival
{
    using KingSurvivalRefactored.GameCore;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestKingSurvivalGameEngine
    {
        private readonly MockUserInterface userInterface = new MockUserInterface();
        private readonly MockViewEngine rendererEngine = new MockViewEngine();

        private GameEngine gameEngine;

        public void InitGameEngine()
        {
            this.gameEngine = new GameEngine(this.userInterface, this.rendererEngine);   
        }
    }
}