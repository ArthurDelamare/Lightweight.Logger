using System;
using System.IO;
using System.Threading.Tasks;
using Lightweight.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_Lightweight_Logger
{
    [TestClass]
    public class AppendLineToFileTest
    {
        string path = Directory.GetCurrentDirectory() + "\\TestAppenLineToFile.txt";

        [TestMethod]
        public async Task TestAppendLineToFileAsync()
        {
            await Logger.AppendLineToFile(path, "Test");
        }

        [TestCleanup]
        public void Cleanup()
        {
            File.Delete(path);
        }
    }
}
