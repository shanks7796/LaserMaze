using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PioneerCodingProject.Factories;
using PioneerCodingProject.Classes;

namespace PioneerCodingProjectUnitTests
{
    [TestClass]
    public class MirrorFactoryUnitTests
    {
        private MirrorFactory FactoryUnderTest;

        [TestInitialize]
        public void Setup()
        {
            FactoryUnderTest = new MirrorFactory();
        }

        [TestMethod]
        public void TestOneWayMirrorCreation()
        {
            string mirrorDefUnderTest = "1,2RR";
            Mirror m = FactoryUnderTest.BuildMirror(mirrorDefUnderTest);
            Assert.AreEqual(MirrorFactory.Direction.Right, m.Direction);
            Assert.AreEqual(MirrorFactory.MirrorType.ReflectiveRight, m.Type);
        }

        [TestMethod]
        public void TestTwoWayMirrorCreation()
        {
            string mirrorDefUnderTest = "1,2R";
            Mirror m = FactoryUnderTest.BuildMirror(mirrorDefUnderTest);
            Assert.AreEqual(MirrorFactory.Direction.Right, m.Direction);
            Assert.AreEqual(MirrorFactory.MirrorType.TwoWay, m.Type);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestUnknownMirrorType()
        {
            string mirrorDefUnderTest = "1,2RSSS";
            Mirror m = FactoryUnderTest.BuildMirror(mirrorDefUnderTest);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestUnknownDirection()
        {
            string mirrorDefUnderTest = "1,2QL";
            Mirror m = FactoryUnderTest.BuildMirror(mirrorDefUnderTest);
        }
    }
}
