using System;
using Moq;
using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models.PackageTests
{
    [TestFixture]
    class Equals_Should
    {
        [Test]
        public void ThrowArgumentNullException_IfInvalidOtherPassed()
        {
            // Arrange
            string name = "GreatPackage";
            var versionMock = new Mock<IVersion>();
            var dependenciesMock = new Mock<ICollection<IPackage>>();
            var package = new Package(name, versionMock.Object, dependenciesMock.Object);
            IPackage invalidOther = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => package.Equals(invalidOther));
        }

        [Test]
        public void ThrowArgumentException_WithCorrectMessage_IfOtherIsNotAPackage()
        {
            // Arrange
            string name = "GreatPackage";
            var versionMock = new Mock<IVersion>();
            var dependenciesMock = new Mock<ICollection<IPackage>>();
            var package = new Package(name, versionMock.Object, dependenciesMock.Object);
            var invalidOther = "BadPackage";

            // Act & Assert
            var expectedExceptionMessage = "must be IPackage";
            var exc = Assert.Throws<ArgumentException>(
                () => package.Equals(invalidOther));
            var actualExceptionMessage = exc.Message;

            // Assert
            StringAssert.Contains(expectedExceptionMessage, actualExceptionMessage);
        }

        [Test]
        public void ReturnFalse_IfPassedObjectIs_DifferentPackage()
        {
            // Arrange
            string name = "CoolPackage";

            // Configure This Package
            int majorOne = 5;
            int minorOne = 4;
            int patchOne = 6;
            VersionType typeOne = VersionType.beta;
            var thisVersionMock = new Mock<IVersion>();
            thisVersionMock.Setup(x => x.Major).Returns(majorOne);
            thisVersionMock.Setup(x => x.Minor).Returns(minorOne);
            thisVersionMock.Setup(x => x.Patch).Returns(patchOne);
            thisVersionMock.Setup(x => x.VersionType).Returns(typeOne);
            var thisDependenciesMock = new Mock<ICollection<IPackage>>();

            var thisPackage = new Package(name, thisVersionMock.Object, thisDependenciesMock.Object);

            // Configure Other Package
            int majorTwo = 6;
            int minorTwo = 1;
            int patchTwo = 3;
            VersionType typeTwo = VersionType.alpha;
            var otherVersionMock = new Mock<IVersion>();
            otherVersionMock.Setup(x => x.Major).Returns(majorTwo);
            otherVersionMock.Setup(x => x.Minor).Returns(minorTwo);
            otherVersionMock.Setup(x => x.Patch).Returns(patchTwo);
            otherVersionMock.Setup(x => x.VersionType).Returns(typeTwo);
            var otherDependenciesMock = new Mock<ICollection<IPackage>>();

            var otherPackage = new Package(name, otherVersionMock.Object, otherDependenciesMock.Object);

            // Act
            var result = thisPackage.Equals(otherPackage);

            //Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void ReturnTrue_IfPassedObjectIs_EqualToPackage()
        {
            // Arrange
            string name = "CoolPackage";

            // Configure This Package
            int majorOne = 6;
            int minorOne = 1;
            int patchOne = 3;
            VersionType typeOne = VersionType.alpha;
            var thisVersionMock = new Mock<IVersion>();
            thisVersionMock.Setup(x => x.Major).Returns(majorOne);
            thisVersionMock.Setup(x => x.Minor).Returns(minorOne);
            thisVersionMock.Setup(x => x.Patch).Returns(patchOne);
            thisVersionMock.Setup(x => x.VersionType).Returns(typeOne);
            var thisDependenciesMock = new Mock<ICollection<IPackage>>();

            var thisPackage = new Package(name, thisVersionMock.Object, thisDependenciesMock.Object);

            // Configure Other Package
            int majorTwo = 6;
            int minorTwo = 1;
            int patchTwo = 3;
            VersionType typeTwo = VersionType.alpha;
            var otherVersionMock = new Mock<IVersion>();
            otherVersionMock.Setup(x => x.Major).Returns(majorTwo);
            otherVersionMock.Setup(x => x.Minor).Returns(minorTwo);
            otherVersionMock.Setup(x => x.Patch).Returns(patchTwo);
            otherVersionMock.Setup(x => x.VersionType).Returns(typeTwo);
            var otherDependenciesMock = new Mock<ICollection<IPackage>>();

            var otherPackage = new Package(name, otherVersionMock.Object, otherDependenciesMock.Object);

            // Act
            var result = thisPackage.Equals(otherPackage);

            //Assert
            Assert.AreEqual(true, result);
        }
    }
}
