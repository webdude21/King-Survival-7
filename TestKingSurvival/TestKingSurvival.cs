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
        public void TestDefaultScenario()
        {
            string screen;
            string ResultTestFilePath = @"..\..\TestsData\ResultTest00.txt";
            string InputTestFilePath = @"..\..\TestsData\InputTest00.txt";

            using (StreamReader sr = new StreamReader(ResultTestFilePath))
            {
                screen = sr.ReadToEnd();
            }

            var textWriter = new StringWriter();

            Console.SetOut(textWriter);

            Console.SetIn(new StreamReader(InputTestFilePath));


            KingSurvivalRefactored.KingSurvival.Main();


            var resultScreens = textWriter.ToString().Split(':');
            var result = resultScreens[resultScreens.Length - 1];

            Assert.AreEqual(result, screen);
        }

        [TestMethod]
        public void Test1()
        {
            string screen;
            string ResultTestFilePath = @"..\..\TestsData\ResultTest01.txt";
            string InputTestFilePath = @"..\..\TestsData\InputTest01.txt";

            using (StreamReader sr = new StreamReader(ResultTestFilePath))
            {
                screen = sr.ReadToEnd();
            }

            var textWriter = new StringWriter();

            Console.SetOut(textWriter);

            Console.SetIn(new StreamReader(InputTestFilePath));


            KingSurvivalRefactored.KingSurvival.Main();


            var resultScreens = textWriter.ToString().Split(':');
            var result = resultScreens[resultScreens.Length - 1];

            Assert.AreEqual(result, screen);
        }
    }
}
