﻿namespace TestKingSurvival
{
    using System;
    using System.IO;

    using KingSurvivalRefactored;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestKingSurvivalConsole
    {
        [TestMethod]
        public void TestDefaultScenario()
        {
            const string ResultTestFilePath = @"..\..\TestsData\ResultTest00.txt";
            const string InputTestFilePath = @"..\..\TestsData\InputTest00.txt";

            ConsoleTest(ResultTestFilePath, InputTestFilePath);
        }

        [TestMethod]
        public void OneTurnThenExit()
        {
            const string ResultTestFilePath = @"..\..\TestsData\ResultTest01.txt";
            const string InputTestFilePath = @"..\..\TestsData\InputTest01.txt";

            ConsoleTest(ResultTestFilePath, InputTestFilePath);
        }

        [TestMethod]
        public void PawnTakeKingMove()
        {
            const string ResultTestFilePath = @"..\..\TestsData\ResultTest02.txt";
            const string InputTestFilePath = @"..\..\TestsData\InputTest02.txt";

            ConsoleTest(ResultTestFilePath, InputTestFilePath);
        }

        private static void ConsoleTest(string resultTestFilePath, string inputTestFilePath)
        {
            string expected;

            using (var sr = new StreamReader(resultTestFilePath))
            {
                expected = sr.ReadToEnd();
            }

            var textWriter = new StringWriter();

            Console.SetOut(textWriter);
            Console.SetIn(new StreamReader(inputTestFilePath));

            KingSurvivalConsole.Main();

            var resultScreens = textWriter.ToString().Split(':');
            var result = resultScreens[resultScreens.Length - 1];

            if (string.IsNullOrWhiteSpace(result))
            {
                result = resultScreens[resultScreens.Length - 2];
            }

            Assert.AreEqual(expected, result);
        }
    }
}