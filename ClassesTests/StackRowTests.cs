using System;
using Containership.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestContainership.ClassesTests
{
    [TestClass]
    public class StackRowTests
    {
        /// <summary>
        /// Tests if the rearrange function puts the valuable container on top
        /// and the heaviest non valuable container on the bottom 
        /// </summary>
        [TestMethod]
        public void TestReArrange()
        {
            //arrange
            var container1 = new Container();
            var container2 = new Container();
            var container3 = new Container();
            var container4 = new Container();
            var stackRow = new StackRow(2);
            var stack1 = stackRow.GetStacks()[0];
            var stack2 = stackRow.GetStacks()[1];
            stack1.Add(container1);
            stack1.Add(container2);
            stack1.Add(container3);
            stack1.Add(container4);
            stack2.Add(container1);
            stack2.Add(container2);
            stack2.Add(container3);
            stack2.Add(container4);
            var containerPos1 = stack1.GetContainers()[0];
            var containerPos2 = stack1.GetContainers()[1];
            var containerPos3 = stack1.GetContainers()[2];
            var containerPos4 = stack1.GetContainers()[3];
            //act
            stackRow.ReArrange();
            //assert
            Assert.AreEqual(containerPos1, 
            stack1.GetContainers()[3],
            "Valuable container was not found on top");
            Assert.AreEqual(containerPos2, 
            stack1.GetContainers()[1],
            "Container at index 1 did not match the expected container");
            Assert.AreEqual(containerPos3, 
            stack1.GetContainers()[2],
            "Container at index 2 did not match the expected container");
            Assert.AreEqual(containerPos4, 
            stack1.GetContainers()[0],
            "Heaviest non valuable container was not found on the bottom");
        }
        
        /// <summary>
        /// Tests if the get stack index function returns the correct index
        /// </summary>
        [TestMethod]
        public void TestGetStackIndex()
        {
            //arrange
            var stackRow = new StackRow(2);
            var stack1 = stackRow.GetStacks()[0];
            var stack2 = stackRow.GetStacks()[1];
            //act
            var index = stackRow.GetStackIndex(stack1);
            var index1 = stackRow.GetStackIndex(stack2);
            //assert
            Assert.AreEqual(0, index,
                "Index of stack1 was incorrect");
            Assert.AreEqual(1, index1,
                "Index of stack2 was incorrect");
        }
        
        /// <summary>
        /// Tests if the get stack index function throws an exception if the
        /// given container was not found
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Did not throw non contained exception")]
        public void TestGetNonContainedStackIndex()
        {
            //arrange
            var stackRow = new StackRow(2);
            var nonContainedStack = new Stack();
            //act
            var index = stackRow.GetStackIndex(nonContainedStack);
            //assert
            Assert.AreEqual(null, index,
                "No index should be given");
        }
    }
}