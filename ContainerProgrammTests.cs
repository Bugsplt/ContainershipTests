using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Containership;

namespace TestContainership
{
    [TestClass]
    public class ContainerProgrammTests
    {
        /// <summary>
        /// Tests if the chat output matches the ship state when the Main function
        /// has been executed with standard data. Does this a thousand times to
        /// diminish faulty passes due to rng
        /// </summary>
        [TestMethod]
        public void TestMainStandardData()
        {
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
                    Assert.IsTrue(!sw.ToString().Contains("CooledValuable containers left: 0"),"Loop: " + i.ToString() + " failed\n" + sw);
                }
                else
                {
                    Assert.IsTrue(sw.ToString().Contains("CooledValuable containers left: 0"),"Loop: " + i.ToString() + " failed\n" + sw);
                }

                if (sw.ToString().Contains("Too many valuable containers!"))
                {
                    Assert.IsTrue(!sw.ToString().Contains("\nValuable containers left: 0"),"Loop: " + i.ToString() + " failed\n" + sw);
                }
                else
                {
                    Assert.IsTrue(sw.ToString().Contains("\nValuable containers left: 0"),"Loop: " + i.ToString() + " failed\n" + sw);
                }

                if (sw.ToString().Contains("Too many cooled containers!"))
                {
                    Assert.IsTrue(!sw.ToString().Contains("Cooled containers left: 0"),"Loop: " + i.ToString() + " failed\n" + sw);
                }
                else
                {
                    Assert.IsTrue(sw.ToString().Contains("Cooled containers left: 0"),"Loop: " + i.ToString() + " failed\n" + sw);
                }

                if (!sw.ToString().Contains("Normal containers left: 0"))
                {
                    Assert.IsTrue(sw.ToString().Contains("Max load reached"),"Loop: " + i.ToString() + " failed\n" + sw);
                }
                else
                {
                    Assert.IsTrue(!sw.ToString().Contains("Max load reached"),"Loop: " + i.ToString() + " failed\n" + sw);
                }
                Assert.IsTrue(sw.ToString().Contains("= == == == == == == == == == == == == == == == == == == == == ="),"Ship output was not wide enough");
            }
        }
        
        /// <summary>
        /// Tests if the chat outputs match the ship state when loading
        /// too many containers through the Main function 
        /// </summary>
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

        /// <summary>
        /// Tests if the chat outputs match the ship state when entering an invalid width
        /// </summary>
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

        /// <summary>
        /// Tests if the chat outputs match the ship state when entering an invalid length
        /// </summary>
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

        /// <summary>
        /// Tests if the chat outputs match the ship state when entering an invalid max load
        /// </summary>
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

        /// <summary>
        /// Tests if the chat outputs match the ship state when entering an invalid container amount
        /// </summary>
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
        
        /// <summary>
        /// Tests if the chat outputs match the ship state when entering an invalid layer input
        /// </summary>
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