namespace TestKingSurvival
{
    using System;
    using System.IO;
    using KingSurvival;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestKingSurvival
    {
        [TestMethod]
        public void TestDefaultScenario()
        {
            const string KingWinsScreen = 
@"    0 1 2 3 4 5 6 7
   -----------------
0 | + - + - + – K - |
1 | - + – C – + – D |
2 | A – B – + – + - |
3 | - + – + – + – + |
4 | + – + – + – + - |
5 | - + – + – + – + |
6 | + – + – + – + - |
7 | - + – + – + – + |
   -----------------
King wins in 7 turns.";

            var textWriter = new StringWriter();
            Console.SetOut(textWriter);
            KingSurvival.Main();

            const string TestFilePath = @"input.txt";
            if (File.Exists(TestFilePath))
            {
                Console.SetIn(new StreamReader(TestFilePath));
            }

            Assert.AreEqual(textWriter.ToString(), KingWinsScreen);
        }
    }
}
