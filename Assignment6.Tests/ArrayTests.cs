using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment6.Tests
{
    [TestClass]
    public class ArrayTests
    {
        [TestMethod]
        public void Constructor_Successful()
        {
            //Arrange
            Array<string> a = new Array<string>(10);
            //Act

            //Assert
            Assert.AreEqual(10, a.Capacity);
           

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_ThrowsException()
        {
            // Arrange
            Array<string> a = new Array<string>(-10);

            // Act

            // Assert
        }

        [TestMethod]
        public void Add_Successful()
        {
            //Arrange
            Array<string> a = new Array<string>(2);
            a.Add("foo");
            a.Add("bar");
            //Act

            //Assert
            Assert.IsTrue(a.Contains("foo"));
            Assert.IsTrue(a.Contains("bar"));


        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_OverCapacity_ThrowsException()
        {
            // Arrange
            Array<string> a = new Array<string>(2);
            a.Add("foo");
            a.Add("bar");
            a.Add("nope");

            // Act

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_Null_ThrowsException()
        {
            // Arrange
            Array<string> a = new Array<string>(2);
            a.Add(null);
            
            // Act

            // Assert
        }

        [TestMethod]
        public void Contains_Successful()
        {
            //Arrange
            Array<string> a = new Array<string>(2);
            a.Add("foo");
            a.Add("bar");
            //Act

            //Assert
            Assert.IsTrue(a.Contains("foo"));
            Assert.IsTrue(a.Contains("bar"));


        }

        [TestMethod]
        public void Does_Not_Contain()
        {
            //Arrange
            Array<string> a = new Array<string>(2);
            a.Add("foo");
            a.Add("bar");
            //Act
            
            //Assert
            Assert.IsFalse(a.Contains("nope"));
  
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Contains_itemIsNull_ThrowsException()
        {
            // Arrange
            Array<string> a = new Array<string>(2);
            a.Add("foo");
            a.Add("bar");

            // Act
            a.Contains(null);
            // Assert
        }

        [TestMethod]
        public void Remove_Successful()
        {
            //Arrange
            Array<string> a = new Array<string>(2);
            a.Add("foo");
            a.Add("bar");
            //Act
            

            //Assert
            Assert.IsTrue(a.Remove("bar"));

        }

        [TestMethod]
        
        public void Remove_Fail()
        {
            // Arrange
            Array<string> a = new Array<string>(2);
            a.Add("foo");
            a.Add("bar");

            // Act

            // Assert
            Assert.IsFalse(a.Remove("nope"));
        }

        [TestMethod]
        public void Clear_Successful()
        {
            //Arrange
            Array<string> a = new Array<string>(2);
            a.Add("foo");
            a.Add("bar");
            //Act
            a.Clear();

            //Assert
            Assert.IsFalse(a.Contains("foo"));
            Assert.IsFalse(a.Contains("bar"));

        }


        }
    }