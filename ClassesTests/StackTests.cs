using System.Linq;
using Containership.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestContainership.ClassesTests
{
    [TestClass]
    public class StackTests
    {
        /// <summary>
        /// Tests if the add function adds the given container to the list
        /// </summary>
        [TestMethod]
        public void TestAddContainer()
        {
            //arrange
            var stack = new Stack();
            var container = new Container();
            //act
            stack.Add(container);
            //assert
            Assert.IsTrue(stack.GetContainers().Contains(container),
                "Container was not found within the list");
        }
        
        /// <summary>
        /// Tests if a stack is unavailable after
        /// the set unavailable function is called on the stack
        /// </summary>
        [TestMethod]
        public void TestSetUnavailable()
        {
            //arrange
            var stack = new Stack();
            //act
            stack.SetUnavailable();
            //assert
            Assert.AreEqual(false, stack.IsAvailable(),
                "Stack should be unavailable");
        }

        /// <summary>
        /// Tests if the can carry function returns true when given
        /// a low enough weight
        /// </summary>
        [TestMethod]
        public void TestCanCarry()
        {
           //arrange
           var stack = new Stack();
           stack.Add(new Container());
           var weight = 20;
           //act
           var result = stack.CanCarry(weight);
           //assert
           Assert.AreEqual(true,result,
               "Weight is light enough to be carried");
        }

        /// <summary>
        /// Tests if the can carry function returns false when given
        /// a weight that is too high
        /// </summary>
        [TestMethod]
        public void TestCanCarryTooHeavy()
        {
            //arrange
            var stack = new Stack();
            stack.Add(new Container());
            var weight = 40000000;
            //act
            var result = stack.CanCarry(weight);
            //assert
            Assert.AreEqual(false,result,
                "Weight is too heavy to be carried");
        }
        
        /// <summary>
        /// Tests if the can carry function returns false when called on
        /// a stack that has been set to  unavailable
        /// </summary>
        [TestMethod]
        public void TestCanCarryUnavailable()
        {
            //arrange
            var stack = new Stack();
            stack.Add(new Container());
            stack.SetUnavailable();
            var weight = 20;
            //act
            var result = stack.CanCarry(weight);
            //assert
            Assert.AreEqual(false,result,
                "Stack is unavailable");
        }
        
        /// <summary>
        /// Tests if the rearrange function puts the valuable container on top
        /// and the heaviest non valuable container on the bottom 
        /// </summary>
        [TestMethod]
        public void TestReArrange()
        {
            //arrange
            var stack = new Stack();
            var container1 = new Container();
            var container2 = new Container();
            var container3 = new Container();
            var container4 = new Container();
            stack.Add(container1);
            stack.Add(container2);
            stack.Add(container3);
            stack.Add(container4);
            var containerPos1 = stack.GetContainers()[0];
            var containerPos2 = stack.GetContainers()[1];
            var containerPos3 = stack.GetContainers()[2];
            var containerPos4 = stack.GetContainers()[3];
            //act
            stack.ReArrange();
            //assert
            Assert.AreEqual(containerPos1, stack.GetContainers()[3],
                "Valuable container was not found on top");
            Assert.AreEqual(containerPos2, stack.GetContainers()[1],
                "Container at index 1 did not match the expected container");
            Assert.AreEqual(containerPos3, stack.GetContainers()[2],
                "Container at index 2 did not match the expected container");
            Assert.AreEqual(containerPos4, stack.GetContainers()[0],
                "Heaviest non valuable container was not found on the bottom");
        }
    }
}