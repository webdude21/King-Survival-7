namespace TestKingSurvival
{
    using System;
    using System.IO;
    using KingSurvivalRefactored;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestKingSurvival
    {
        /* [TestMethod]
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

             const string TestFilePath = @"input.txt";
             if (File.Exists(TestFilePath))
             {
                 Console.SetIn(new StreamReader(TestFilePath));
             }

             KingSurvival.Main();

             Assert.AreEqual(textWriter.ToString(), KingWinsScreen);
         }*/

        [TestMethod]
        public void Test1()
        {
            string screen;
            const string ResultTestFilePath = @"..\..\ResultTest01.txt";
            const string InputTestFilePath = @"..\..\InputTest01.txt";

            using (StreamReader sr = new StreamReader(ResultTestFilePath))
            {
                screen = sr.ReadToEnd();
            }

            var textWriter = new StringWriter();

            Console.SetOut(textWriter);

            Console.SetIn(new StreamReader(InputTestFilePath));


            KingSurvivalRefactored.KingSurvival.Main();

            Assert.AreEqual(textWriter.ToString(), screen);
        }
    }
}
