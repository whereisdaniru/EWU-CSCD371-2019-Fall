using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mailbox.Tests
{
    [TestClass]
    class DataLoaderTests
    {
        [TestMethod]
        public void DataLoader_Save_Load_Sucessful()
        {
            //Arrange
            MemoryStream source = new MemoryStream();
            DataLoader dataLoader = new DataLoader(source);
            List<Mailbox> mailboxes = getTestData();

            //Act
            dataLoader.Save(mailboxes);
            List<Mailbox> mailboxesLoad = dataLoader.Load();
            //Assert
            //Assert.AreEqual(mailboxes.Count, mailboxesLoad.Count);
            for(int i = 0; i < mailboxesLoad.Count; i++)
            {
                Assert.AreEqual(mailboxes[i].Owner, mailboxesLoad[i].Owner);
                Assert.AreEqual(mailboxes[i].Location, mailboxesLoad[i].Location);
                Assert.AreEqual(mailboxes[i].Size, mailboxesLoad[i].Size);
            }
            dataLoader.Dispose();

        }

        [TestMethod]
        public void DataLoader_Load_JsonException()
        {
            //Arrange
            MemoryStream source = new MemoryStream();
            DataLoader dataLoader = new DataLoader(source);
            List<Mailbox> mailboxes = getTestData();

            //Act
            using (StreamWriter stream = new StreamWriter(source, leaveOpen: true))
            {
                foreach(Mailbox mailbox in mailboxes)
                {
                    stream.WriteLine(mailbox.ToString());
                }
            }
            //Assert
            Assert.IsNull(dataLoader.Load());
            dataLoader.Dispose();

        }

        private List<Mailbox> getTestData()
        {
            List<Mailbox> testList = new List<Mailbox>();
            testList.Add(new Mailbox(Size.Small, (1, 1), new Person("Testing", "One")));
            testList.Add(new Mailbox(Size.Medium, (2, 3), new Person("Testing", "Two")));
            testList.Add(new Mailbox(Size.Large, (3, 5), new Person("Testing", "Three")));

            return testList;
        }
    }

    
}
