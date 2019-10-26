using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WithNullFilePath_ThrowsException()
        {
            // Arrange

            // Act
            new FileLogger(null!);

            // Assert
        }

        [TestMethod]
        public void Log_WithData_WritesFile()
        {
            // Arrange
            string filePath = Path.GetFullPath(Path.GetRandomFileName());
            var sut = new FileLogger(filePath) { ClassName = nameof(FileLoggerTests) };

            // Act
            sut.Log(LogLevel.Warning, "Test");

            // Assert
            string[] lines = File.ReadAllLines(filePath);
            File.Delete(filePath);
            Assert.AreEqual(1, lines.Length);
            Assert.IsTrue(lines[0].Contains($"{LogLevel.Warning}"));
            Assert.IsTrue(lines[0].Contains(nameof(FileLoggerTests)));
            Assert.IsTrue(lines[0].Contains("Test"));
        }

        [TestMethod]
        public void Log_WithData_AppendsDataToFile()
        {
            // Arrange
            string filePath = Path.GetFullPath(Path.GetRandomFileName());
            var sut = new FileLogger(filePath) { ClassName = nameof(FileLoggerTests) };

            // Act
            (LogLevel Level, string Message)[] messages = new[] { 
                (LogLevel.Error, "Tests"),
                (LogLevel.Warning, "Test2")
            };
            
            foreach((LogLevel level, string message) in messages)
            {
                sut.Log(level, message);
            }

            // Assert
            string[] lines = File.ReadAllLines(filePath);
            File.Delete(filePath);
            Assert.AreEqual(messages.Length, lines.Length);

            foreach ((LogLevel level, string message, string line) in
                messages.Zip(lines, (message, line) => (message.Level, message.Message, line) ))
            {
                ValidateLogWasWrittenCorrectly(level, message, line);
            }
        }

        private static void ValidateLogWasWrittenCorrectly(
            LogLevel severity, string message, string line)
        {
            Assert.IsTrue(line.Contains($"{severity}"));
            Assert.IsTrue(line.Contains(message));
            Assert.IsTrue(line.Contains(nameof(FileLoggerTests)));
        }

        [TestMethod]
        [DataRow(LogLevel.Debug, "This is a test of the emergency broadcast system.")]
        [DataRow(LogLevel.Error, "Hello my name is Inigo Montoya.")]
        public void Log_WithDataMoreDate_AppendsDataToFile(LogLevel level, string message)
        {
            // Arrange
            string filePath = Path.GetFullPath(Path.GetRandomFileName());
            var sut = new FileLogger(filePath) { ClassName = nameof(FileLoggerTests) };

            // Act
            sut.Log(level, message);

            // Assert
            string[] lines = File.ReadAllLines(filePath);
            File.Delete(filePath);
            Assert.AreEqual(1, lines.Length);
            Assert.IsTrue(lines[0].Contains(level.ToString()));
            Assert.IsTrue(lines[0].Contains(nameof(FileLoggerTests)));
            Assert.IsTrue(lines[0].Contains(message));
        }
    }
}
