using System;
using Containership.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestContainership.ClassesTests
{
    [TestClass]
    public class StackRowTests
    {
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
            var containerPos1 = stackRow.GetStacks()[0].GetContainers()[0];
            var containerPos2 = stackRow.GetStacks()[0].GetContainers()[1];
            var containerPos3 = stackRow.GetStacks()[0].GetContainers()[2];
            var containerPos4 = stackRow.GetStacks()[0].GetContainers()[3];
            //act
            stackRow.ReArrange();
            //assert
            Assert.AreEqual(containerPos1, stackRow.GetStacks()[0].GetContainers()[3]);
            Assert.AreEqual(containerPos2, stackRow.GetStacks()[0].GetContainers()[1]);
            Assert.AreEqual(containerPos3, stackRow.GetStacks()[0].GetContainers()[2]);
            Assert.AreEqual(containerPos4, stackRow.GetStacks()[0].GetContainers()[0]);
        }
        
        [TestMethod]
        public void TestGetStackIndex()
        {
            //arrange
            var stackRow = new StackRow(2);
            var stack1 = stackRow.GetStacks()[0];
            //act
            var index = stackRow.GetStackIndex(stack1);
            //assert
            Assert.AreEqual(0, index);
        }
        
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
            Assert.AreEqual(null, index);
        }
    }
}