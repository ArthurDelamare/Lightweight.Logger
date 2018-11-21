using System;
using System.IO;
using System.Threading.Tasks;
using Lightweight.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_Lightweight_Logger
{
    [TestClass]
    public class ReadFirstLineFromFileTest
    {
        string path = Directory.GetCurrentDirectory() + "\\TestReadFirstLine.txt";

        [TestMethod]
        public async Task TestReadLineFromFileTest()
        {
            Assert.IsFalse(File.Exists(path));
            string expected = "Test";
            await Logger.AppendLineToFile(path, "Test");
            string result = await Logger.ReadFirstLineFromFile(path);
            Assert.AreEqual(expected, result);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            File.Delete(path);
        }
    }
}
