using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class MockLoggerTests
    {
        [TestMethod]
        public void Log_WithData_WritesFile()
        {
            // Arrange
            var sut = new MockLogger(nameof(MockLoggerTests));

            // Act
            sut.Log(LogLevel.Warning, "Test");

            // Assert
            string[] lines = sut.Messages();

            foreach(string line in lines )
            {
                ///do something
            }

            //Assert.AreEqual(1, lines.Length);
            //Assert.IsTrue(lines[0].Contains($"{LogLevel.Warning}"));
            //Assert.IsTrue(lines[0].Contains(nameof(FileLoggerTests)));
            //Assert.IsTrue(lines[0].Contains("Test"));
        }

        [TestMethod]
        public void Log_WithData_AppendsDataToFile()
        {
            // Arrange
            string filePath = Path.GetFullPath(Path.GetRandomFileName());
            var sut = new FileLogger(filePath) { ClassName = nameof(FileLoggerTests) };

            // Act
            sut.Log(LogLevel.Warning, "Test");
            sut.Log(LogLevel.Error, "Test2");

            // Assert
            string[] lines = File.ReadAllLines(filePath);
            File.Delete(filePath);
            Assert.AreEqual(2, lines.Length);
            Assert.IsTrue(lines[0].Contains($"{LogLevel.Warning}"));
            Assert.IsTrue(lines[0].Contains("Test"));
            Assert.IsTrue(lines[0].Contains(nameof(FileLoggerTests)));
            Assert.IsTrue(lines[1].Contains($"{LogLevel.Error}"));
            Assert.IsTrue(lines[1].Contains(nameof(FileLoggerTests)));
            Assert.IsTrue(lines[1].Contains("Test2"));
        }

        [TestMethod]
        [DataRow(LogLevel.Debug, "This is a test of the emergency broadcast system.")]
        [DataRow(LogLevel.Error, "Hello my name is Inigo Montoya.")]
        public void Log_WithDataMoreDate_AppendsDataToFile(LogLevel level, string message)
        {


        }
    }
}
