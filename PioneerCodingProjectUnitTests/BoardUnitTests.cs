using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PioneerCodingProject.Classes;
using PioneerCodingProject.Factories;

namespace PioneerCodingProjectUnitTests
{
    [TestClass]
    public class BoardUnitTests
    {
        private Board boardUnderTest;

        [TestInitialize]
        public void Setup()
        {
            boardUnderTest = new Board(4, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPlaceLaserInvalidLaserStartingPoint()
        {
            Laser laser = new Laser(1, 2, LaserFactory.LaserOrientation.Horizontal);
            boardUnderTest.SetLaserDirection(laser);
        }

        [TestMethod]
        public void TestSetLaserDirectionWithHorizontalLaser()
        {
            Laser laser;
            laser = new Laser(0, 2, LaserFactory.LaserOrientation.Horizontal);
            boardUnderTest.SetLaserDirection(laser);
            Assert.AreEqual(LaserFactory.LaserDirection.Right, laser.Direction);

            laser = new Laser(4, 1, LaserFactory.LaserOrientation.Horizontal);
            boardUnderTest.SetLaserDirection(laser);
            Assert.AreEqual(LaserFactory.LaserDirection.Left, laser.Direction);
        }

        [TestMethod]
        public void TestSetLaserDirectionWithVerticalLaser()
        {
            Laser laser;
            laser = new Laser(2, 0, LaserFactory.LaserOrientation.Vertical);
            boardUnderTest.SetLaserDirection(laser);
            Assert.AreEqual(LaserFactory.LaserDirection.Up, laser.Direction);

            laser = new Laser(2, 3, LaserFactory.LaserOrientation.Vertical);
            boardUnderTest.SetLaserDirection(laser);
            Assert.AreEqual(LaserFactory.LaserDirection.Down, laser.Direction);
        }

        [TestMethod]
        public void TestSetLaserDirection()
        {
            Laser laser;
            laser = new Laser(2, 0, LaserFactory.LaserOrientation.Vertical);
            boardUnderTest.SetLa
        }
    }
}
