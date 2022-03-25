using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Containership;

namespace TestContainership
{
    [TestClass]
    public class ContainerProgrammTests
    {
        [TestMethod]
        public void TestMainStandardData()
        {
            //loop 1000 times to get high probability of all rng cases
            for (var i = 0; i < 1000; i++)
            {
                //arrange
                var sw = new StringWriter();
                Console.SetOut(sw);
                var stringReader = new StringReader("10\n7\n50\n300\n2\nexit\n");
                Console.SetIn(stringReader);
                
                //act
                ContainerProgram.Main(new string[]{});

                //assert
                if (sw.ToString().Contains("Too many cooled valuable containers!"))
                {
                    Assert.IsTrue(!sw.ToString().Contains("CooledValuable containers left: 0"),i.ToString() + "\n" + sw);
                }
                else
                {
                    Assert.IsTrue(sw.ToString().Contains("CooledValuable containers left: 0"),i.ToString() + "\n" + sw);
                }

                if (sw.ToString().Contains("Too many valuable containers!"))
                {
                    Assert.IsTrue(!sw.ToString().Contains("\nValuable containers left: 0"),i.ToString() + "\n" + sw);
                }
                else
                {
                    Assert.IsTrue(sw.ToString().Contains("\nValuable containers left: 0"),i.ToString() + "\n" + sw);
                }

                if (sw.ToString().Contains("Too many cooled containers!"))
                {
                    Assert.IsTrue(!sw.ToString().Contains("Cooled containers left: 0"),i.ToString() + "\n" + sw);
                }
                else
                {
                    Assert.IsTrue(sw.ToString().Contains("Cooled containers left: 0"),i.ToString() + "\n" + sw);
                }

                if (!sw.ToString().Contains("Normal containers left: 0"))
                {
                    Assert.IsTrue(sw.ToString().Contains("Max load reached"),i.ToString() + "\n" + sw);
                }
                else
                {
                    Assert.IsTrue(!sw.ToString().Contains("Max load reached"),i.ToString() + "\n" + sw);
                }
                Assert.IsTrue(sw.ToString().Contains("= == == == == == == == == == == == == == == == == == == == == ="));
            }
        }

        [TestMethod]
        public void TestMainTooHeavy()
        {
            //arrange
            var sw = new StringWriter();
            Console.SetOut(sw);
            var stringReader = new StringReader("10\n7\n1\n300\n2\nexit\n");
            Console.SetIn(stringReader);
            //act
            ContainerProgram.Main(new string[]{});
            //assert
            Assert.IsTrue(sw.ToString().Contains("Max load reached"),sw + "\nDoes not contain Max load reached");
        }

        [TestMethod]
        public void TestMainInvalidWidth()
        {
            //arrange
            var sw = new StringWriter();
            Console.SetOut(sw);
            var stringReader = new StringReader("10\n0\n3\n50\n300\n2\nexit\n");
            Console.SetIn(stringReader);
            //act
            ContainerProgram.Main(new string[] {});
            //assert
            Assert.IsTrue(sw.ToString().Contains("Give a width above 0"),sw.ToString());
        }

        [TestMethod]
        public void TestMainInvalidLength()
        {
            //arrange
            var sw = new StringWriter();
            Console.SetOut(sw);
            var stringReader = new StringReader("0\n10\n3\n50\n300\n2\nexit\n");
            Console.SetIn(stringReader);
            //act
            ContainerProgram.Main(new string[] {});
            //assert
            Assert.IsTrue(sw.ToString().Contains("Give a length above 0"),sw.ToString());
        }

        [TestMethod]
        public void TestMainInvalidMaxLoad()
        {
            //arrange
            var sw = new StringWriter();
            Console.SetOut(sw);
            var stringReader = new StringReader("10\n3\n0\n50\n300\n2\nexit\n");
            Console.SetIn(stringReader);
            //act
            ContainerProgram.Main(new string[] {});
            //assert
            Assert.IsTrue(sw.ToString().Contains("Give a max load above 0"),sw.ToString());
        }

        [TestMethod]
        public void TestMainInvalidContainerAmount()
        {
            //arrange
            var sw = new StringWriter();
            Console.SetOut(sw);
            var stringReader = new StringReader("10\n3\n50\n0\n300\n2\nexit\n");
            Console.SetIn(stringReader);
            //act
            ContainerProgram.Main(new string[] {});
            //assert
            Assert.IsTrue(sw.ToString().Contains("Give a nr of containers above 0"),sw.ToString());
        }
        
        [TestMethod]
        public void TestMainInvalidLayerInput()
        {
            //arrange
            var sw = new StringWriter();
            Console.SetOut(sw);
            var stringReader = new StringReader("10\n3\n50\n300\nqwerty\n2\nexit\n");
            Console.SetIn(stringReader);
            //act
            ContainerProgram.Main(new string[] {});
            //assert
            Assert.IsTrue(sw.ToString().Contains("Command not recognized"),sw.ToString());
        }
    }
}