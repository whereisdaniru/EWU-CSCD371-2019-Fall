using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Inheritance.Tests
{
    [TestClass]
    public class ActorTests
    {
        [TestMethod]
        public void PennySpeaks()
        {
            //Arrange
            Actor penny = new Penny();

            //Act
            string line = penny.Speak();

            //Assert
            Assert.AreEqual("Isn't this when he says 'bazooka' or something?", line);
        }

        [TestMethod]
        public void SheldonSpeaks()
        {
            //Arrange
            Actor sheldon = new Sheldon();

            //Act
            string line = sheldon.Speak();

            //Assert
            Assert.AreEqual("I’m not crazy, my mother had me tested.", line);
        }

        [TestMethod]
        public void RajSpeaks_withWomen()
        {
            //Arrange
            Raj raj = new Raj() 
            { 
                womenArePresent = true 
            };

            //Act
            string line = raj.Speak();

            //Assert
            Assert.AreEqual("*mumble*", line);

        }

        [TestMethod]
        public void RajSpeaks_withoutWomen()
        {
            //Arrange
            Actor raj = new Raj() 
            { 
                womenArePresent = false 
            };

            //Act
            string line = raj.Speak();

            //Assert
            Assert.AreEqual("I haven't cried this hard since Toy Story 3.", line);
        }

    }
}
