namespace Computers.Tests.CpusTests
{
    using Logic.Cpus;
    using Logic.MotherBoards;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class SquareNumberShould
    {
        [TestMethod]
        public void OutputCorrectValues()
        {
            var cpu = new Cpu32(4);

            var motherBoardMock = new Mock<IMotherBoard>();
            motherBoardMock.Setup(x => x.LoadRamValue()).Returns(123);

            cpu.AttachTo(motherBoardMock.Object);

            cpu.SquareIt();

            motherBoardMock.Verify(x => x.DrawOnVideoCard(It.Is<string>(y => y.Contains("15129"))));
        }

        [TestMethod]
        public void OutputDRawErrorMessage()
        {
            var cpu = new Cpu32(4);

            var motherBoardMock = new Mock<IMotherBoard>();
            motherBoardMock.Setup(x => x.LoadRamValue()).Returns(-1);

            cpu.AttachTo(motherBoardMock.Object);

            cpu.SquareIt();

            motherBoardMock.Verify(x => x.DrawOnVideoCard(It.Is<string>(y => y == "Number too low.")));
        }

        [TestMethod]
        public void OutputDRawErrorMessageWhenMaxValueExcededForCpu32()
        {
            var cpu = new Cpu32(4);

            var motherBoardMock = new Mock<IMotherBoard>();
            motherBoardMock.Setup(x => x.LoadRamValue()).Returns(501);

            cpu.AttachTo(motherBoardMock.Object);

            cpu.SquareIt();

            motherBoardMock.Verify(x => x.DrawOnVideoCard(It.Is<string>(y => y == "Number too high.")));
        }

        [TestMethod]
        public void OutputDRawErrorMessageWhenMaxValueExcededForCpu64()
        {
            var cpu = new Cpu32(4);

            var motherBoardMock = new Mock<IMotherBoard>();
            motherBoardMock.Setup(x => x.LoadRamValue()).Returns(1001);

            cpu.AttachTo(motherBoardMock.Object);

            cpu.SquareIt();

            motherBoardMock.Verify(x => x.DrawOnVideoCard(It.Is<string>(y => y == "Number too high.")));
        }

        [TestMethod]
        public void OutputDRawErrorMessageWhenMaxValueExcededForCpu128()
        {
            var cpu = new Cpu32(4);

            var motherBoardMock = new Mock<IMotherBoard>();
            motherBoardMock.Setup(x => x.LoadRamValue()).Returns(2001);

            cpu.AttachTo(motherBoardMock.Object);

            cpu.SquareIt();

            motherBoardMock.Verify(x => x.DrawOnVideoCard(It.Is<string>(y => y == "Number too high.")));
        }
    }
}
