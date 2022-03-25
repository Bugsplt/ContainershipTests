using System;
using System.Collections.Generic;
using Containership.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestContainership.ClassesTests
{
    [TestClass]
    public class ShipTests
    {
        [TestMethod]
        public void TestSetSize()
        {
            //arrange
            var ship = new Ship();
            //act
            ship.SetSize(10,20);
            //assert
            Assert.AreEqual(10 , ship.GetStackRows().Count);
            Assert.AreEqual(20 , ship.GetStackRows()[0].GetStacks().Count);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Negative/0 width was allowed.")]
        public void TestSetSizeNegativeWidth()
        {
            //arrange
            var ship = new Ship();
            //act
            ship.SetSize(10,-20);
            //assert
            Assert.Fail();
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Negative/0 length was allowed.")]
        public void TestSetSizeNegativeLength()
        {
            //arrange
            var ship = new Ship();
            //act
            ship.SetSize(-10,20);
            //assert
            Assert.Fail();
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Negative/0 max load was allowed.")]
        public void TestSetNegativeMaxLoad()
        {
            //arrange
            var ship = new Ship();
            //act
            ship.SetMaxLoad(-10);
            //assert
            Assert.Fail();
        }

        [TestMethod]
        public void TestPutLoad()
        {
            //arrange
            var ship = new Ship();
            var dockyard = new Dockyard();
            var nrOfContainers = 20;
            dockyard.NewShipment(nrOfContainers);
            ship.SetSize(20,20);
            ship.SetMaxLoad(10); 
            ship.Dock(dockyard);
            //act
            ship.PutLoad();
            //assert
            var containerCount = 0;
            // get nr of containers on ship
            foreach (var stackRow in ship.GetStackRows())
            {
                foreach (var stack in stackRow.GetStacks())
                {
                    containerCount += stack.GetContainers().Count;
                }
            }
            Assert.AreEqual(nrOfContainers, containerCount);
        }

        [TestMethod]
        public void TestGetStackRows()
        {
            //arrange
            var ship = new Ship();
            var expectedStackRowAmount = 15;
            ship.SetSize(expectedStackRowAmount, 10);
            //act
            var stackRowAmount = ship.GetStackRows().Count;
            //assert
            Assert.AreEqual(expectedStackRowAmount, stackRowAmount);
        }

        [TestMethod]
        public void TestGetLayer()
        { 
            //arrange
            var ship = new Ship();
            var dockyard = new Dockyard();
            var expectedContainers = 10;
            dockyard.NewShipment(expectedContainers);
            ship.Dock(dockyard);
            ship.SetSize(10,10);
            ship.SetMaxLoad(50);
            ship.PutLoad();
            //act
            var layer = ship.GetLayer(0);
            var secondLayer = ship.GetLayer(1);
            //assert
            var matchedContainers = MatchedContainers(layer);
            var secondMatchedContainers = MatchedContainers(secondLayer);
            Assert.AreEqual(expectedContainers, matchedContainers);
            Assert.AreEqual(0, secondMatchedContainers);
        }
        
        private static int MatchedContainers(IReadOnlyList<List<Container>> layer)
        {
            var matchedContainers = 0;
            foreach (var containers in layer)
            {
                foreach (var container in containers)
                {
                    if (container.Weight != 0)
                    {
                        matchedContainers++;
                    }
                }
            }

            return matchedContainers;
        }
    }
}