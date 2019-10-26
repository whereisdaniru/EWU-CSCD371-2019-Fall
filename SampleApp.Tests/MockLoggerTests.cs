using Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace SampleApp.Tests
{
    [TestClass]
    public class MockLoggerTests
    {
        public void Messages_NoData_DoesNotReturnNull()
        {
            MockLogger mockLogger = new MockLogger(nameof(MockLoggerTests));
            Assert.IsNotNull(mockLogger.Messages);

        }
        [TestMethod]
        public void Log_WithData_WritesFile()
        {
            // Arrange
            var sut = new MockLogger(nameof(MockLoggerTests));

            // Act
            sut.Log(LogLevel.Warning, "Test");

            // Assert
            string[] lines = sut.Messages;

            Assert.AreEqual(1, lines.Length);
            Assert.IsTrue(lines[0].Contains($"{LogLevel.Warning}"));
            Assert.IsTrue(lines[0].Contains(nameof(MockLoggerTests)));
            Assert.IsTrue(lines[0].Contains("Test"));
        }

        [TestMethod]
        public void Log_WithData_AppendsDataToFile()
        {
            // Arrange
            MockLogger mockLogger = new MockLogger(nameof(MockLoggerTests));

            // Act
            mockLogger.Log(LogLevel.Warning, "Test");
            mockLogger.Log(LogLevel.Error, "Test2");

            // Assert
            string[] logRecords = mockLogger.Messages;
            Assert.AreEqual(2, logRecords.Length);
            Assert.IsTrue(logRecords[0].Contains($"{LogLevel.Warning}"));
            Assert.IsTrue(logRecords[0].Contains("Test"));
            Assert.IsTrue(logRecords[0].Contains(nameof(MockLoggerTests)));
            Assert.IsTrue(logRecords[1].Contains($"{LogLevel.Error}"));
            Assert.IsTrue(logRecords[1].Contains(nameof(MockLoggerTests)));
            Assert.IsTrue(logRecords[1].Contains("Test2"));
        }

        [TestMethod]
        [DataRow(LogLevel.Debug, "This is a test of the emergency broadcast system.")]
        [DataRow(LogLevel.Error, "Hello my name is Inigo Montoya.")]
        public void Log_WithLogSampleData_AppendsToMessages(LogLevel level, string message)
        {
            MockLogger mockLogger = new MockLogger(nameof(MockLoggerTests));

            mockLogger.Log(level, message);

            string[] logRecords = mockLogger.Messages;
             
            Assert.IsTrue(logRecords[0].Contains($"{level}"));
            Assert.IsTrue(logRecords[0].Contains(message));
            Assert.IsTrue(logRecords[0].Contains(nameof(MockLoggerTests)));
        }
    }
}
