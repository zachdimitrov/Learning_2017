using Academy.Commands.Adding;
using Academy.Core.Contracts;
using Academy.Models.Contracts;
using Academy.Tests.Models.Commands.Adding.Mocks;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Models.Commands.Adding.AddingToSeasonCommandTests
{
    [TestFixture]
    class Execute_Should
    {
        [Test]
        public void ThrowsArgumentException_WhenTheStudentIsAlreadyInSeason()
        {
            // Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            var studentMock = new Mock<IStudent>();
            studentMock.Setup(s => s.Username).Returns("Pesho");

            engineMock.SetupGet(x => x.Students).Returns(new List<IStudent> { studentMock.Object });

            var seasonMock = new Mock<ISeason>();
            seasonMock.SetupGet(x => x.Students).Returns(new List<IStudent> { studentMock.Object });

            engineMock.Setup(e => e.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

            var command = new AddStudentToSeasonCommand(factoryMock.Object, engineMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => command.Execute(new List<string> { "Pesho", "0" }));
        }

        [Test]
        public void ShouldAddStudent_WhenTheStudentIsNotInSeason()
        {
            // Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();

            // First Student
            var studentMock = new Mock<IStudent>();
            studentMock.Setup(s => s.Username).Returns("Pesho");

            // Second Student
            var otherStudentMock = new Mock<IStudent>();
            otherStudentMock.Setup(s => s.Username).Returns("Other");

            // Collection and add as referenc to StudentsInSeason
            var studentsInSeason = new List<IStudent> { otherStudentMock.Object };
            var seasonMock = new Mock<ISeason>();
            seasonMock.SetupGet(x => x.Students).Returns(studentsInSeason);

            // Fill Engine with mocks
            engineMock.SetupGet(x => x.Students).Returns(new List<IStudent> { studentMock.Object });
            engineMock.SetupGet(e => e.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

            // create command
            var command = new AddStudentToSeasonCommand(factoryMock.Object, engineMock.Object);

            // Act
            var result = command.Execute(new List<string> { "Pesho", "0" });

            // Assert
            Assert.AreEqual(2, seasonMock.Object.Students.Count);
        }

        [Test]
        public void ReturnMessage_WhenTheStudentIsAdded()
        {
            // Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();

            // First Student
            var studentMock = new Mock<IStudent>();
            studentMock.Setup(s => s.Username).Returns("Pesho");

            // Second Student
            var otherStudentMock = new Mock<IStudent>();
            otherStudentMock.Setup(s => s.Username).Returns("Other");

            // Collection and add as referenc to StudentsInSeason
            var studentsInSeason = new List<IStudent> { otherStudentMock.Object };
            var seasonMock = new Mock<ISeason>();
            seasonMock.SetupGet(x => x.Students).Returns(studentsInSeason);

            // Fill Engine with mocks
            engineMock.SetupGet(x => x.Students).Returns(new List<IStudent> { studentMock.Object });
            engineMock.SetupGet(e => e.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

            // create command
            var command = new AddStudentToSeasonCommand(factoryMock.Object, engineMock.Object);

            // Act
            var result = command.Execute(new List<string> { "Pesho", "0" });

            // Assert
            StringAssert.Contains("Pesho", result);
            StringAssert.Contains("Season 0", result);
        }
    }
}
