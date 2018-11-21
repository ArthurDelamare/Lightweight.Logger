using System;
using System.IO;
using System.Threading.Tasks;
using Lightweight.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_Lightweight_Logger
{

    [TestClass]
    public class ReadLastLineFromFileTest 
    {
        string path = Directory.GetCurrentDirectory() + "\\TestReadLastLineFromFile.txt";

        [TestMethod]
        public async Task TestReadLastLineFromFileTest()
        {
            await Logger.AppendLineToFile(path, "Test");
            await Logger.AppendLineToFile(path, "Test2");
            await Logger.AppendLineToFile(path, "Test3");
            string expected = "Test3";
            string result = await Logger.ReadLastLineFromFile(path);
            Assert.AreEqual(expected, result);
        }

        [TestCleanup]
        public void Cleanup()
        {
            File.Delete(path);
        }
    }
}
