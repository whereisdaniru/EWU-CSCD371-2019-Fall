using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Tests
{
    [TestClass]
   public class MainWindowViewModelTests
    {
        [TestMethod]
        public void AddItem_AddsToList()
        {
            //Arrange
            MainWindowViewModel testVM = new MainWindowViewModel();
            string testItem = "pancakes";
            testVM.Item = testItem;

            //Act
            testVM.AddItemCommand.Execute(testItem);

            //Assert
            Assert.AreEqual(3, testVM.ShoppingList.Count);
        }

        [TestMethod]
        public void AddItem_Empty_DoesNotAddToList()
        {
            //Arrange
            MainWindowViewModel testVM = new MainWindowViewModel();
            string testItem = " ";
            testVM.Item = testItem;

            //Act
            testVM.AddItemCommand.Execute(testItem);

            //Assert
            Assert.AreEqual(2, testVM.ShoppingList.Count);
        }

        [TestMethod]
        public void AddItem_NullItem_DoesNotAddToList()
        {
            //Arrange
            MainWindowViewModel testVM = new MainWindowViewModel();
            string testItem = null!;
            testVM.Item = testItem;

            //Act
            testVM.AddItemCommand.Execute(testItem);

            //Assert
            Assert.AreEqual(2, testVM.ShoppingList.Count);
        }

        [TestMethod]
        public void RemoveItem_RemovesFromList()
        {
            //Arrange
            MainWindowViewModel testVM = new MainWindowViewModel();
            var testItem = new Item("pancakes");
            testVM.ShoppingList.Add(testItem);
            testVM.SelectedItem = testItem;

            //Act
            testVM.RemoveItemCommand.Execute(testItem);

            //Assert
            Assert.AreEqual(2, testVM.ShoppingList.Count);
        }


        [TestMethod]
        public void RemoveItem_SelectedItemIsNull_DoesNotRemoveFromList()
        {
            //Arrange
            MainWindowViewModel testVM = new MainWindowViewModel();
            var addItem = new Item("pancakes");
            testVM.ShoppingList.Add(addItem);
            testVM.SelectedItem = null!;

            //Act
            testVM.RemoveItemCommand.Execute(testVM.SelectedItem);

            //Assert
            Assert.AreEqual(3, testVM.ShoppingList.Count);
        }


    }
}
