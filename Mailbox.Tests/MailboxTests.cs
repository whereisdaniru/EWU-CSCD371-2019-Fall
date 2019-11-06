using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;


namespace Mailbox.Tests
{
    [TestClass]
    public class MailboxTests
    {
        [TestMethod]
        public void MailboxReturnsMailbox_ToString()
        {
            //Arrange
            Mailbox testBox = new Mailbox(Size.Small, (1, 1), new Person("Testing", "One"));

            //Act

            //Assert
            Assert.AreEqual(testBox.ToString(), $"Owner: Testing One Location: (1, 1) Size: Small");

            
        }
    }
}
