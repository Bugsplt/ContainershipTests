using Containership.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestContainership.ClassesTests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void TestAddContainer()
        {
            //arrange
            var stack = new Stack();
            var container = new Container();
            //act
            stack.Add(container);
            //assert
            Assert.AreEqual(container, stack.GetContainers()[0]);
        }
        
        [TestMethod]
        public void TestSetUnavailable()
        {
            //arrange
            var stack = new Stack();
            //act
            stack.SetUnavailable();
            //assert
            Assert.AreEqual(false, stack.IsAvailable());
        }

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
           Assert.AreEqual(true,result);
        }

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
            Assert.AreEqual(false,result);
        }
        
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
            Assert.AreEqual(false,result);
        }
        
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
            Assert.AreEqual(containerPos1, stack.GetContainers()[3]);
            Assert.AreEqual(containerPos2, stack.GetContainers()[1]);
            Assert.AreEqual(containerPos3, stack.GetContainers()[2]);
            Assert.AreEqual(containerPos4, stack.GetContainers()[0]);
        }
    }
}