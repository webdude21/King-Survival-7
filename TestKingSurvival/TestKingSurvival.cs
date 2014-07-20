namespace TestKingSurvival
{
    using System;
    using System.IO;
    using KingSurvivalRefactored;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestKingSurvival
    {
        [TestMethod]
        public void OneTurnThenExit()
        {
            const string ResultTestFilePath = @"..\..\TestsData\ResultTest01.txt";
            const string InputTestFilePath = @"..\..\TestsData\InputTest01.txt";

            ConsoleTest(ResultTestFilePath, InputTestFilePath);
        }

        [TestMethod]
        public void PawnsOverlapTest()
        {
            const string ResultTestFilePath = @"..\..\TestsData\ResultTest02.txt";
            const string InputTestFilePath = @"..\..\TestsData\InputTest02.txt";

            ConsoleTest(ResultTestFilePath, InputTestFilePath);
        }

        [TestMethod]
        public void TestDefaultScenario()
        {
            const string ResultTestFilePath = @"..\..\TestsData\ResultTest00.txt";
            const string InputTestFilePath = @"..\..\TestsData\InputTest00.txt";

            ConsoleTest(ResultTestFilePath, InputTestFilePath);
        }

        private static void ConsoleTest(string resultTestFilePath, string inputTestFilePath)
        {
            string screen;

            using (var sr = new StreamReader(resultTestFilePath))
            {
                screen = sr.ReadToEnd();
            }

            var textWriter = new StringWriter();

            Console.SetOut(textWriter);
            Console.SetIn(new StreamReader(inputTestFilePath));

            KingSurvival.Main();

            var resultScreens = textWriter.ToString().Split(':');
            var result = resultScreens[resultScreens.Length - 2];

            Assert.AreEqual(result, screen);
        }
    }
}
