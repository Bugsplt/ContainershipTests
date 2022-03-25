using Containership.Classes;
using Containership.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestContainership.ClassesTests
{
    [TestClass]
    public class ContainerTests
    {
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
                Assert.IsTrue(container.Type == ContainerType.Cooled || container.Type == ContainerType.Normal ||
                              container.Type == ContainerType.Valuable ||
                              container.Type == ContainerType.ValuableCooled);
                Assert.IsTrue(container.Weight >= 4000 && container.Weight <= 30000);
            }
        }

        [TestMethod]
        public void TestIsEmptyConstructor()
        {
            //arrange
            //act
            var container = new Container(true);
            //assert
            Assert.AreEqual(0,container.Weight);
        }
    }
}