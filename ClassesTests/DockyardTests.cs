using System.Linq;
using Containership.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestContainership.ClassesTests
{
    [TestClass]
    public class DockyardTests
    {
        /// <summary>
        /// Tests if generating a new shipment generates the expected amount of containers
        /// and if the containers are ordered by weight
        /// </summary>
        [TestMethod]
        public void TestNewShipment()
        {
            //arrange
            var dockyard = new Dockyard();
            var containerNr = 300;
            //act
            dockyard.NewShipment(containerNr);
            //assert
            var count = dockyard.GetCooledContainers().Count 
                        + dockyard.GetCooledValuableContainers().Count 
                        + dockyard.GetNormalContainers().Count 
                        + dockyard.GetValuableContainers().Count;
            Assert.AreEqual(containerNr, count,
                $"Container count incorrect, expected : {containerNr} got {count}");
            for (var i = 0; i < dockyard.GetCooledContainers().Count - 1; i++)
            {
                Assert.IsTrue(dockyard.GetCooledContainers()[i].Weight 
                              >= dockyard.GetCooledContainers()[i+1].Weight,
                    "List not ordered by weight.");
            }
            for (var i = 0; i < dockyard.GetCooledValuableContainers().Count - 1; i++)
            {
                Assert.IsTrue(dockyard.GetCooledValuableContainers()[i].Weight 
                              >= dockyard.GetCooledValuableContainers()[i+1].Weight,
                    "List not ordered by weight.");
            }
            for (var i = 0; i < dockyard.GetValuableContainers().Count - 1; i++)
            {
                Assert.IsTrue(dockyard.GetValuableContainers()[i].Weight 
                >= dockyard.GetValuableContainers()[i+1].Weight,
                "List not ordered by weight.");
            }
            for (var i = 0; i < dockyard.GetNormalContainers().Count - 1; i++)
            {
                Assert.IsTrue(dockyard.GetNormalContainers()[i].Weight 
                >= dockyard.GetNormalContainers()[i+1].Weight,
                "List not ordered by weight.");
            }
        }
        
        /// <summary>
        /// Tests if the remove container function removes the correct container
        /// </summary>
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
            Assert.AreEqual(newCount, dockyard.GetNormalContainers().Count, 
                "Expects to have removed 1 of the containers");
            Assert.IsFalse(dockyard.GetNormalContainers().Contains(removeContainer),
                "The removed container was found within the list");
        }
        
        /// <summary>
        /// Tests if the remove container function removes the correct container
        /// </summary>
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
            Assert.AreEqual(newCount, dockyard.GetCooledContainers().Count,
                "Expects to have removed 1 of the containers");
            Assert.IsFalse(dockyard.GetCooledContainers().Contains(removeContainer),
                "The removed container was found within the list");
        }
        
        /// <summary>
        /// Tests if the remove container function removes the correct container
        /// </summary>
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
            Assert.AreEqual(newCount, dockyard.GetCooledValuableContainers().Count,
                "Expects to have removed 1 of the containers");
            Assert.IsFalse(dockyard.GetCooledValuableContainers().Contains(removeContainer),
                "The removed container was found within the list");
        }
        
        /// <summary>
        /// Tests if the remove container function removes the correct container
        /// </summary>
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
            Assert.AreEqual(newCount, dockyard.GetValuableContainers().Count,
                "Expects to have removed 1 of the containers");
            Assert.IsFalse(dockyard.GetValuableContainers().Contains(removeContainer),
                "The removed container was found within the list");
        }
    }
}