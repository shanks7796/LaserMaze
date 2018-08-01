using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PioneerCodingProject.Classes;
using PioneerCodingProject.Factories;

namespace PioneerCodingProjectUnitTests
{
    [TestClass]
    public class OneWayReflectionStrategiesTests
    {
        [TestMethod]
        public void TestOneWayRefelctiveLeftWithLaserFiringUp()
        {
            LaserFactory.LaserDirection dir;

            OneWayReflectiveLeft strategyUnderTest = new OneWayReflectiveLeft();
            dir = strategyUnderTest.Reflect(MirrorFactory.Direction.Left, LaserFactory.LaserDirection.Up);
            Assert.AreEqual(LaserFactory.LaserDirection.Left, dir);

            dir = strategyUnderTest.Reflect(MirrorFactory.Direction.Right, LaserFactory.LaserDirection.Up);
            Assert.AreEqual(LaserFactory.LaserDirection.Up, dir);
        }

        [TestMethod]
        public void TestOneWayRefelctiveLeftWithLaserFiringDown()
        {
            LaserFactory.LaserDirection dir;

            OneWayReflectiveLeft strategyUnderTest = new OneWayReflectiveLeft();
            dir = strategyUnderTest.Reflect(MirrorFactory.Direction.Left, LaserFactory.LaserDirection.Down);
            Assert.AreEqual(LaserFactory.LaserDirection.Down, dir);

            dir = strategyUnderTest.Reflect(MirrorFactory.Direction.Right, LaserFactory.LaserDirection.Down);
            Assert.AreEqual(LaserFactory.LaserDirection.Left, dir);
        }

        [TestMethod]
        public void TestOneWayRefelctiveLeftWithLaserFiringRight()
        {
            LaserFactory.LaserDirection dir;

            OneWayReflectiveLeft strategyUnderTest = new OneWayReflectiveLeft();
            dir = strategyUnderTest.Reflect(MirrorFactory.Direction.Left, LaserFactory.LaserDirection.Right);
            Assert.AreEqual(LaserFactory.LaserDirection.Down, dir);

            dir = strategyUnderTest.Reflect(MirrorFactory.Direction.Right, LaserFactory.LaserDirection.Right);
            Assert.AreEqual(LaserFactory.LaserDirection.Up, dir);
        }

        [TestMethod]
        public void TestOneWayRefelctiveLeftWithLaserFiringLeft()
        {
            LaserFactory.LaserDirection dir;

            OneWayReflectiveLeft strategyUnderTest = new OneWayReflectiveLeft();
            dir = strategyUnderTest.Reflect(MirrorFactory.Direction.Left, LaserFactory.LaserDirection.Left);
            Assert.AreEqual(LaserFactory.LaserDirection.Left, dir);

            dir = strategyUnderTest.Reflect(MirrorFactory.Direction.Right, LaserFactory.LaserDirection.Left);
            Assert.AreEqual(LaserFactory.LaserDirection.Left, dir);
        }

        [TestMethod]
        public void TestOneWayRefelctiveRightWithLaserFiringUp()
        {
            LaserFactory.LaserDirection dir;

            OneWayReflectiveRight strategyUnderTest = new OneWayReflectiveRight();
            dir = strategyUnderTest.Reflect(MirrorFactory.Direction.Left, LaserFactory.LaserDirection.Up);
            Assert.AreEqual(LaserFactory.LaserDirection.Up, dir);

            dir = strategyUnderTest.Reflect(MirrorFactory.Direction.Right, LaserFactory.LaserDirection.Up);
            Assert.AreEqual(LaserFactory.LaserDirection.Right, dir);
        }

        [TestMethod]
        public void TestOneWayRefelctiveRightWithLaserFiringDown()
        {
            LaserFactory.LaserDirection dir;

            OneWayReflectiveRight strategyUnderTest = new OneWayReflectiveRight();
            dir = strategyUnderTest.Reflect(MirrorFactory.Direction.Left, LaserFactory.LaserDirection.Down);
            Assert.AreEqual(LaserFactory.LaserDirection.Right, dir);

            dir = strategyUnderTest.Reflect(MirrorFactory.Direction.Right, LaserFactory.LaserDirection.Down);
            Assert.AreEqual(LaserFactory.LaserDirection.Down, dir);
        }

        [TestMethod]
        public void TestOneWayRefelctiveRightWithLaserFiringRight()
        {
            LaserFactory.LaserDirection dir;

            OneWayReflectiveRight strategyUnderTest = new OneWayReflectiveRight();
            dir = strategyUnderTest.Reflect(MirrorFactory.Direction.Left, LaserFactory.LaserDirection.Right);
            Assert.AreEqual(LaserFactory.LaserDirection.Right, dir);

            dir = strategyUnderTest.Reflect(MirrorFactory.Direction.Right, LaserFactory.LaserDirection.Right);
            Assert.AreEqual(LaserFactory.LaserDirection.Right, dir);
        }

        [TestMethod]
        public void TestOneWayRefelctiveRightWithLaserFiringLeft()
        {
            LaserFactory.LaserDirection dir;

            OneWayReflectiveRight strategyUnderTest = new OneWayReflectiveRight();
            dir = strategyUnderTest.Reflect(MirrorFactory.Direction.Left, LaserFactory.LaserDirection.Left);
            Assert.AreEqual(LaserFactory.LaserDirection.Up, dir);

            dir = strategyUnderTest.Reflect(MirrorFactory.Direction.Right, LaserFactory.LaserDirection.Left);
            Assert.AreEqual(LaserFactory.LaserDirection.Down, dir);
        }
    }
}
