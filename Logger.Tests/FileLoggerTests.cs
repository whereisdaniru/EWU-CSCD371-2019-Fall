using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {

        [TestMethod]
        public void FileLogger_LogFileCreated()
        {
            // Arrange
            string path = "testlog.txt";

            // Act
            FileLogger testLogger = new FileLogger(path);

            // Assert
            Assert.IsTrue(File.Exists(path));

            //cleanup
            File.Delete(path);

        }

        [TestMethod]
        public void FileLogger_WriteToLogFile()
        {
            // Arrange
            string path = "testlog2.txt";

            FileLogger testLogger = new FileLogger(path);

            // Act
            testLogger.Log(LogLevel.Error, "Testing Error");

            // Assert
            Assert.IsTrue(File.ReadAllText(path).Contains("Testing Error"));

            //cleanup
            File.Delete(path);

        }

    }
}
