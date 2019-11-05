using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    class PersonTests
    {


        [TestMethod]
        public void ReturnsPerson_ToString()
        {
            //Arrange
            Person person1 = new Person("Testing", "One");
            Person person2 = new Person("Testing", "Two");

            //Act

            //Assert
            Assert.AreEqual(person1.ToString(), "Testing One");
            Assert.AreEqual(person2.ToString(), "Testing Two");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Person_ThrowsException()
        {
            // Arrange
            Person person1 = new Person(null, "One");
            Person person2 = new Person("Testing", null);

            // Act


            // Assert
        }
    


        [TestMethod]
        public void PersonEqualsPerson_True()
        {
            //Arrange
            Person person1 = new Person("Same", "Name");
            Person person2 = new Person("Same", "Name");

            //Act

            //Assert
            Assert.IsTrue(person1.Equals(person2));
            Assert.IsTrue(person2.Equals(person1));
        }

        [TestMethod]
        public void PersonEqualsPerson_False()
        {
            //Arrange
            Person person1 = new Person("Same", "Name");
            Person person2 = new Person("Different", "Name");

            //Act

            //Assert
            Assert.IsFalse(person1.Equals(person2));
            Assert.IsFalse(person2.Equals(person1));
        }

       
    }
}
