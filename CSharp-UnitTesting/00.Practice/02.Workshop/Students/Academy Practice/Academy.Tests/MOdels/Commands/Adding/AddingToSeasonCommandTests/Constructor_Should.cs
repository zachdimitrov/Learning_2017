using Academy.Commands.Adding;
using Academy.Core.Contracts;
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
    class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedEngineIsNull()
        {
            // Arrange
            var engineMock = new Mock<IEngine>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(null, engineMock.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedFactoryIsNull()
        {
            // Arrange
            var factoryMock = new Mock<IAcademyFactory>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(factoryMock.Object, null));
        }

        [Test]
        public void SetFactory_WhenPassedFactoryIsNotNull()
        {
            // Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();

            // Act
            var command = new AddStudentToSeasonCommandMosk(factoryMock.Object, engineMock.Object);

            // Assert
            Assert.AreSame(factoryMock.Object, command.AcademyFactory);
        }
    }
}
