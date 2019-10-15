using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {

        [TestMethod]
        public void CreateLogger_PathIsNull()
        {
            // Arrange
            LogFactory testFactory = new LogFactory();

            // Act
            BaseLogger testLogger = testFactory.CreateLogger("Test");

            // Assert
            Assert.IsNull(testLogger);

        }

        [TestMethod]
        public void CreateLogger_LoggerCreated()
        {
            // Arrange
            LogFactory testFactory = new LogFactory();
            testFactory.ConfigureFileLogger("log.txt");

            // Act
            BaseLogger testLogger = testFactory.CreateLogger("Test");

            // Assert
            Assert.IsNotNull(testLogger);

        }


    }
}
