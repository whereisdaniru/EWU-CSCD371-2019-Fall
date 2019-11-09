using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Configuration.Tests
{
    [TestClass]
    public class MemoryConfigTests
    {
        [TestMethod]
        public void CheckForNull_LeverageNullforgivenessOperator()
        {
            static bool IsNull(string? value) => value is null;

            string? text = null;
            if(IsNull(text))
            {
                text = "";
            }
            ThowIfNull(text!);
        }

        void ThowIfNull(string value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            // Do Something
        }


        [TestMethod]
        public void SetValue_GivenNewReferenceTypeValue_Success()
        {
            MemoryConfig config = new MemoryConfig();
            string expected = "Inigo Montoya";
            config.SetValue("name", expected);
            Assert.AreEqual<string>(
                expected, config.GetValue<string>("name"));
        }

        internal class TypeThatDoesNotImplementComparable { }
#pragma warning disable IDE0059 // Unnecessary assignment of a value
        [TestMethod]
        public void SetValue_GivenTypeThatDoesNotImplmentEquitable_Fail()
        {
            MemoryConfig config = new MemoryConfig();
            (string name, TypeThatDoesNotImplementComparable value) = ("name", new TypeThatDoesNotImplementComparable());
            // config.SetValue(name, value);
        }
#pragma warning restore IDE0059 // Unnecessary assignment of a value

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

        [TestMethod]
        [Ignore("A known issue is that we can't convet between nullable and not-nullable value types.")]
        public void SetValue_GivenNullableValueTypeChangedToNonNullable_Success()
        {
            MemoryConfig config = new MemoryConfig();
            config.SetValue("value", 42);
            config.SetValue<int?>("value", null);
            Assert.IsNull(config.GetValue<int?>("value"));
            Assert.IsNull(config.GetValue<int>("value"));
        }


        static MemoryConfig DataRowsConfig { get; } = new MemoryConfig();
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
