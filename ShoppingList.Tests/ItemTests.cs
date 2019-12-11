using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Tests
{
    [TestClass]
    public class ItemTests
    {

        [TestMethod]
        public void TestItem_Pass()
        {
            var testItem = new Item("pancakes");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestItem_null_ThrowEception()
        {
            var testItem = new Item(null!);
        }
    }
}
