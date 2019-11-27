using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {

       
        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_TestWithLinq()
        {
            //Arrange
            SampleData sampleData = new SampleData();
            IEnumerable<string> states = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            string actual = "";

            //Act
            foreach (string state in states)
            {
                actual += state + " ";
            }

            //Assert
            Assert.IsTrue(states.SequenceEqual(states.OrderBy(x => x)));
            //Assert.AreEqual("AL AZ CA DC FL GA IN KS LA MD MN MO MT NC NE NH NV NY OR PA SC TN TX UT VA WA WV ", actual);
        }

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_SortedStates()
        {
            // Arrange
            SampleData sampleData = new SampleData();
            IEnumerable<string> states = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            string expected = string.Join(", ", states);

            // Act
            string actual = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();

            // Assert
            Assert.AreEqual(expected, actual);
           // Assert.AreEqual("AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV", actual);
        }

    }
}
