using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortUtility_ArrayIsNull_ThrowsArgumentNullException()
        {
            // Arrange

            //Act
            SortUtility.SelectionSort(null, (int first, int second) => (first > second));
            
            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortUtility_DelegatorIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            int[] test = { 5, 4, 3, 2, 1 };

            //Act
            SortUtility.SelectionSort(test, null);

            // Assert
        }

        [TestMethod]
        public void SortUtility_ShouldSortAscending_UsingAnAnonymousMethod()
        {
            // Arrange
            int[] test = { 5, 4, 3, 2, 1 };
            int[] expected = { 1, 2, 3, 4, 5 };

            // Act
            SortUtility.SelectionSort(test, delegate (int first, int second)
            {
                return first < second;
            });

            // Assert
            CollectionAssert.AreEqual(test, expected);
            
        }

        [TestMethod]
        public void SortUtility_ShouldSortAscending_UsingLamdaExpression()
        {
            // Arrange
            int[] test = { 5, 4, 3, 2, 1 };
            int[] expected = { 1, 2, 3, 4, 5 };

            // Act
            SortUtility.SelectionSort(test, (int first, int second) => first < second);
           

            // Assert
            CollectionAssert.AreEqual(test, expected);
            
        }

        [TestMethod]
        public void SortUtility_ShouldSortAscending_UsingLamdaStatement()
        {
            // Arrange
            int[] test = { 5, 4, 3, 2, 1 };
            int[] expected = { 1, 2, 3, 4, 5 };

            // Act
            SortUtility.SelectionSort(test, (int first, int second) =>
            {
                if (first.ToString().Length == second.ToString().Length)
                {
                    return first < second;
                }
                else
                {
                    return first.ToString().Length > second.ToString().Length;
                }
            });
            
            // Assert
            CollectionAssert.AreEqual(test, expected);
           
        }

       
    }
}
