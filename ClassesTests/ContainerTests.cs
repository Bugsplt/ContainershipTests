using Containership.Classes;
using Containership.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestContainership.ClassesTests
{
    [TestClass]
    public class ContainerTests
    {
        /// <summary>
        /// Tests if the default constructor creates random values
        /// within expected limits a thousand times
        /// </summary>
        [TestMethod]
        public void TestDefaultConstructor()
        { 
            //Multiple tests to minimize rng
            for (var i = 0; i < 1000; i++)
            {
                //Arrange
                //Act
                var container = new Container();
                //Assert
                Assert.IsTrue(container.Type == ContainerType.Cooled || 
                              container.Type == ContainerType.Normal ||
                              container.Type == ContainerType.Valuable ||
                              container.Type == ContainerType.ValuableCooled,
                    "Invalid container type received: " + container.Type);
                Assert.IsTrue(container.Weight >= 4000 && container.Weight <= 30000,
                    "Container weight incorrect, " +
                    "expected: >= 4000 && <= 30000, got: " + container.Weight);
            }
        }

        /// <summary>
        /// Tests if the constructor creates empty containers
        /// if a bool is given as parameter
        /// </summary>
        [TestMethod]
        public void TestIsEmptyConstructor()
        {
            //arrange
            //act
            var container = new Container(true);
            //assert
            Assert.AreEqual(0,container.Weight,
                "Empty containers should have no weight");
        }
    }
}