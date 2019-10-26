using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleApp;
using System;

namespace SampleApp.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mockLogger = new MockLogger(nameof(ProgramTests));
            Program.Logger = mockLogger;
            Program.Main();
            Assert.AreEqual<int>(2, mockLogger.Messages.Length);
        }
    }
}
