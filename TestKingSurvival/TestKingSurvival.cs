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
        public void InitialScreenTest()
        {
  var testScenario = 
@"  0 1 2 3 4 5 6 7
   -----------------
0 | A - B - C – D - |
1 | - + – + – + – + |
2 | + – + – + – + - |
3 | - + – + – + – + |
4 | + – + – + – + - |
5 | - + – + – + – + |
6 | + – + – + – + - |
7 | - + – K – + – + |
   -----------------
King’s turn:";
            
            Assert.AreEqual(testScenario, this.ReadTheConsole());
        }

        public string ReadTheConsole()
        {
            var textWriter  = new StringWriter();
            Console.SetOut(textWriter);
            KingSurvival.Main();
            return textWriter.ToString();
        }
    }
}
