namespace Computers.Tests.CpusTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Computers.Logic.Cpus;
    using Moq;
    using Computers.Logic.MotherBoards;

    [TestClass]
    public class RandShouild
    {
        [TestMethod]
        public void NotProduseNumberLessTHanMin()
        {
            var cpu = new Cpu32(4);
            var motherBoardMock = new Mock<IMotherBoard>();
            cpu.AttachTo(motherBoardMock.Object);
            var currentMin = int.MaxValue;
            motherBoardMock.Setup(x => x.SaveRamValue(It.IsAny<int>()))
                .Callback<int>(param => currentMin = Math.Min(currentMin, param));
            for (int i = 0; i < 1000; i++)
            {
                cpu.Rand(1, 10);
            }

            Assert.AreEqual(1, currentMin);
        }

        [TestMethod]
        public void NotProduseNumberMoreThanMax()
        {
            var cpu = new Cpu32(4);
            var motherBoardMock = new Mock<IMotherBoard>();
            cpu.AttachTo(motherBoardMock.Object);
            var currentMax = int.MinValue;
            motherBoardMock.Setup(x => x.SaveRamValue(It.IsAny<int>()))
                .Callback<int>(param => currentMax = Math.Max(currentMax, param));
            for (int i = 0; i < 1000; i++)
            {
                cpu.Rand(1, 10);
            }

            Assert.AreEqual(10, currentMax);
        }

        [TestMethod]
        public void ReturnRandomNumbers()
        {
            var hashSet = new HashSet<int>();
            var cpu = new Cpu32(4);
            var motherBoardMock = new Mock<IMotherBoard>();
            cpu.AttachTo(motherBoardMock.Object);
            motherBoardMock.Setup(x => x.SaveRamValue(It.IsAny<int>()))
                .Callback<int>(param => hashSet.Add(param));

            for (int i = 0; i < 10000; i++)
            {
                cpu.Rand(1, 10);
            }

            Assert.AreEqual(10, hashSet.Count);
        }
    }
}
