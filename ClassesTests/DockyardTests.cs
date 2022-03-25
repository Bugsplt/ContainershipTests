using System.Linq;
using Containership.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestContainership.ClassesTests
{
    [TestClass]
    public class DockyardTests
    {
        [TestMethod]
        public void TestNewShipment()
        {
            //arrange
            var dockyard = new Dockyard();
            var containerNr = 300;
            //act
            dockyard.NewShipment(containerNr);
            //assert
            Assert.AreEqual(containerNr, dockyard.GetCooledContainers().Count + dockyard.GetCooledValuableContainers().Count + dockyard.GetNormalContainers().Count + dockyard.GetValuableContainers().Count);
            for (var i = 0; i < dockyard.GetCooledContainers().Count - 1; i++)
            {
                Assert.IsTrue(dockyard.GetCooledContainers()[i].Weight >= dockyard.GetCooledContainers()[i+1].Weight);
            }
            for (var i = 0; i < dockyard.GetCooledValuableContainers().Count - 1; i++)
            {
                Assert.IsTrue(dockyard.GetCooledValuableContainers()[i].Weight >= dockyard.GetCooledValuableContainers()[i+1].Weight);
            }
            for (var i = 0; i < dockyard.GetValuableContainers().Count - 1; i++)
            {
                Assert.IsTrue(dockyard.GetValuableContainers()[i].Weight >= dockyard.GetValuableContainers()[i+1].Weight);
            }
            for (var i = 0; i < dockyard.GetNormalContainers().Count - 1; i++)
            {
                Assert.IsTrue(dockyard.GetNormalContainers()[i].Weight >= dockyard.GetNormalContainers()[i+1].Weight);
            }
        }
        
        [TestMethod]
        public void TestRemoveNormalContainer()
        {
            //arrange
            var dockyard = new Dockyard();
            dockyard.NewShipment(100);
            var newCount = dockyard.GetNormalContainers().Count - 1;
            var removeContainer = dockyard.GetNormalContainers()[0];
            //act
            dockyard.RemoveNormalContainer(removeContainer);
            //assert
            Assert.AreEqual(newCount, dockyard.GetNormalContainers().Count);
            Assert.IsFalse(dockyard.GetNormalContainers().Contains(removeContainer));
        }
        
        [TestMethod]
        public void TestRemoveCooledContainer()
        {
            //arrange
            var dockyard = new Dockyard();
            dockyard.NewShipment(100);
            var newCount = dockyard.GetCooledContainers().Count - 1;
            var removeContainer = dockyard.GetCooledContainers()[0];
            //act
            dockyard.RemoveCooledContainer(removeContainer);
            //assert
            Assert.AreEqual(newCount, dockyard.GetCooledContainers().Count);
            Assert.IsFalse(dockyard.GetCooledContainers().Contains(removeContainer));
        }
        
        [TestMethod]
        public void TestRemoveCooledValuableContainer()
        {
            //arrange
            var dockyard = new Dockyard();
            dockyard.NewShipment(100);
            var newCount = dockyard.GetCooledValuableContainers().Count - 1;
            var removeContainer = dockyard.GetCooledValuableContainers()[0];
            //act
            dockyard.RemoveCooledValuableContainer(removeContainer);
            //assert
            Assert.AreEqual(newCount, dockyard.GetCooledValuableContainers().Count);
            Assert.IsFalse(dockyard.GetCooledValuableContainers().Contains(removeContainer));
        }
        
        [TestMethod]
        public void TestRemoveValuableContainer()
        {
            //arrange
            var dockyard = new Dockyard();
            dockyard.NewShipment(100);
            var newCount = dockyard.GetValuableContainers().Count - 1;
            var removeContainer = dockyard.GetValuableContainers()[0];
            //act
            dockyard.RemoveValuableContainer(removeContainer);
            //assert
            Assert.AreEqual(newCount, dockyard.GetValuableContainers().Count);
            Assert.IsFalse(dockyard.GetValuableContainers().Contains(removeContainer));
        }
    }
}