using System;
using System.IO;
using System.Threading.Tasks;
using Lightweight.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_Lightweight_Logger
{
    [TestClass]
    public class CopyLogFileTest
    {
        string logPath = Directory.GetCurrentDirectory() + "\\TestCopyLogFile.txt";
        string copiedLogPath = Directory.GetCurrentDirectory() +" \\TestCopiedLogFile.txt";

        [TestMethod]
        public async Task TestCopyLogFile()
        {
            await Logger.AppendLineToFile(logPath, "Test");
            Assert.IsTrue(File.Exists(logPath));
            Logger.CopyLogFile(logPath, copiedLogPath);
            Assert.IsTrue(File.Exists(copiedLogPath));
        }

        [TestCleanup]
        public void Cleanup()
        {
            File.Delete(logPath);
            File.Delete(copiedLogPath);
        }
    }
}
