using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Configuration.Tests
{
    [TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public void SetValue_GivenNewReferenceTypeValue_Success()
        {
            MemoryConfig config = new MemoryConfig();
            string expected = "Inigo Montoya";
            config.SetValue("name", expected!);
            Assert.AreEqual<string>(
                expected, config.GetValue<string>("name"));
        }

        [TestMethod]
        public void SetValue_Given2NewValueTypeValue_Success()
        {
            MemoryConfig config = new MemoryConfig();
            (string name, int value) = ("name", 42);
            config.SetValue(name, value);
            Assert.AreEqual<int>(
                value, config.GetValue<int>(name));
            (name, value) = ("forgive", 77);
            config.SetValue(name, value);
            Assert.AreEqual<int>(
                value, config.GetValue<int>(name));
        }

        [TestMethod]
        public void SetValue_GivenReferenceTyeNull_Success()
        {
            MemoryConfig config = new MemoryConfig();
            (string name, string? value) = ("name", null);
            config.SetValue(name, value);
            Assert.AreEqual<string?>(
                value, config.GetValue<string?>(name));
        }

        [TestMethod]
        public void SetValue_GivenValueTypeNull_Success()
        {
            MemoryConfig config = new MemoryConfig();
            (string name, int? value) = ("name", null);
            config.SetValue(name, value);
            // Remind class about AreEqual<T> on Thursday
            Assert.AreEqual<int?>(
                value, config.GetValue<int?>(name));
        }


        [TestMethod]
        public void SetValue_GivenNewValueWithGenerics_Success()
        {
            // Refactor in class on Thursday
        }


        static MemoryConfig DataRowsConfig = new MemoryConfig();
        [TestMethod]
        [DataRow("age", 42)]
        [DataRow("null", null)]
        [DataRow("name", "Inigo Montoya")]
        [DataRow("name", "Princess Buttercup")]
        [DataRow("size", "large")]
        [DataRow("size", 42)]
        [DataRow("BigSize", 85)]
        [DataRow("size", 42)]
        public void SetAndGetValue_DataRows_Success(string name, object? value)
        {
            // Yuck!!  Discuss in class Thursday.
            DataRowsConfig.SetValue(name, value);
            Assert.AreEqual<object?>(
                value, DataRowsConfig.GetValue<object?>(name));
        }
    }
 
}
