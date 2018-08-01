using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PioneerCodingProject.Classes;
using PioneerCodingProject.Factories;

namespace PioneerCodingProjectUnitTests
{
    /// <summary>
    /// Summary description for TwoWayReflectionStrategyTests
    /// </summary>
    [TestClass]
    public class TwoWayReflectionStrategyTests
    {
        [TestMethod]
        public void TestTwoWayOrientationRight()
        {
            LaserFactory.LaserDirection dir;

            TwoWayReflection strategyUnderTest = new TwoWayReflection();

            dir = strategyUnderTest.Reflect(MirrorFactory.Direction.Right, LaserFactory.LaserDirection.Up);
            Assert.AreEqual(LaserFactory.LaserDirection.Right, dir);

            dir = strategyUnderTest.Reflect(MirrorFactory.Direction.Right, LaserFactory.LaserDirection.Down);
            Assert.AreEqual(LaserFactory.LaserDirection.Left, dir);

            dir = strategyUnderTest.Reflect(MirrorFactory.Direction.Right, LaserFactory.LaserDirection.Left);
            Assert.AreEqual(LaserFactory.LaserDirection.Down, dir);

            dir = strategyUnderTest.Reflect(MirrorFactory.Direction.Right, LaserFactory.LaserDirection.Right);
            Assert.AreEqual(LaserFactory.LaserDirection.Up, dir);
        }

        [TestMethod]
        public void TestTwoWayOrientationLeft()
        {
            LaserFactory.LaserDirection dir;

            TwoWayReflection strategyUnderTest = new TwoWayReflection();

            dir = strategyUnderTest.Reflect(MirrorFactory.Direction.Left, LaserFactory.LaserDirection.Up);
            Assert.AreEqual(LaserFactory.LaserDirection.Left, dir);

            dir = strategyUnderTest.Reflect(MirrorFactory.Direction.Left, LaserFactory.LaserDirection.Down);
            Assert.AreEqual(LaserFactory.LaserDirection.Right, dir);

            dir = strategyUnderTest.Reflect(MirrorFactory.Direction.Left, LaserFactory.LaserDirection.Left);
            Assert.AreEqual(LaserFactory.LaserDirection.Up, dir);

            dir = strategyUnderTest.Reflect(MirrorFactory.Direction.Left, LaserFactory.LaserDirection.Right);
            Assert.AreEqual(LaserFactory.LaserDirection.Down, dir);
        }
    }
}
