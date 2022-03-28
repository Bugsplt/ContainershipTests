using System;
using System.Collections.Generic;
using Containership.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestContainership.ClassesTests
{
    [TestClass]
    public class ShipTests
    {
        /// <summary>
        /// Tests if the set size function sets the correct ship size
        /// </summary>
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
        
        /// <summary>
        /// Tests if setting a negative width throws an exception
        /// </summary>
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
            Assert.Fail("Function should not finish execution");
        }
        
        /// <summary>
        /// Tests if setting a negative length throws an exception
        /// </summary>
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
            Assert.Fail("Function should not finish execution");
        }
        
        /// <summary>
        /// Tests if setting a negative max load throws an exception
        /// </summary>
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
            Assert.Fail("Function should not finish execution");
        }

        /// <summary>
        /// Tests if, in case of a valid load, all containers are loaded onto the ship
        /// </summary>
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
            Assert.AreEqual(nrOfContainers, containerCount,
                "Not all containers where loaded onto the ship");
        }
        

        /// <summary>
        /// Test if the expected amount of rows is retrieved
        /// </summary>
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
            Assert.AreEqual(expectedStackRowAmount, stackRowAmount,
                "Function did not retrieve all rows");
        }

        /// <summary>
        /// Tests if the GetLayer function retrieves the expected amount of containers
        /// from a layer.
        /// </summary>
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
            Assert.AreEqual(expectedContainers, matchedContainers,
                "All containers should be found on this layer");
            Assert.AreEqual(0, secondMatchedContainers,
                "No containers should be found on this layer");
        }
        
        /// <summary>
        /// Returns the amount of loaded containers in a layer
        /// </summary>
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