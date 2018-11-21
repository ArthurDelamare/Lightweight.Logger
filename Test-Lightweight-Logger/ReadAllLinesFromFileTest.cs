using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Lightweight.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_Lightweight_Logger
{
    [TestClass]
    public class ReadAllLinesFromFileTest
    {
        string path = Directory.GetCurrentDirectory() + "\\TestReadAllLinesFromFile.txt";

        [TestMethod]
        public async Task TestRealAllLinesFromFile()
        {
            Assert.IsFalse(File.Exists(path));
            await Logger.AppendLineToFile(path, "A try");
            await Logger.AppendLineToFile(path, "Another try");
            await Logger.AppendLineToFile(path, "A try again");
            IList<string> lines = await Logger.ReadAllLinesFromFile(path);
            Assert.AreEqual(lines[0], "A try");
            Assert.AreEqual(lines[1], "Another try");
            Assert.AreEqual(lines[2], "A try again");
        }

        [TestCleanup]
        public void Cleanup()
        {
            File.Delete(path);
        }
    }
}
