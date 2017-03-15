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
    class CompareTo_Should
    {
        [Test]
        public void ThrowArgumentNullException_IfInvalidOtherPassed()
        {
            // Arrange
            string name = "CoolPackage";
            var versionMock = new Mock<IVersion>();
            var dependenciesMock = new Mock<ICollection<IPackage>>();
            var package = new Package(name, versionMock.Object, dependenciesMock.Object);
            IPackage invalidOther = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => package.CompareTo(invalidOther));
        }

        [Test]
        public void ThrowArgumentException_IfNamesOfThisAndOther_AreNotEqual()
        {
            // Arrange
                // Configure This Package
            string thisName = "CoolPackage";
            var thisVersionMock = new Mock<IVersion>();
            var dependenciesMock = new Mock<ICollection<IPackage>>();

            var thisPackage = new Package(thisName, thisVersionMock.Object, dependenciesMock.Object);

                // Configure Other Package
            string otherName = "BadPackage";
            var otherVersionMock = new Mock<IVersion>();
            var otherDependenciesMock = new Mock<ICollection<IPackage>>();

            var otherPackage = new Package(otherName, otherVersionMock.Object, otherDependenciesMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => thisPackage.CompareTo(otherPackage));
        }


        [Test]
        public void ReturnPositiveValue_IfOtherPackage_IsHigherVersion()
        {
            // Arrange
            string name = "CoolPackage";

            // Configure This Package
            int majorOne = 5; // changed value
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
            var result = thisPackage.CompareTo(otherPackage);

            //Assert
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void ReturnNegativeValue_IfOtherPackage_IsLowerVersion()
        {
            // Arrange
            string name = "CoolPackage";

            // Configure This Package
            int majorOne = 6; // changed value
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
            int majorTwo = 5;
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
            var result = thisPackage.CompareTo(otherPackage);

            //Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void ReturnZero_IfOtherPackage_IsSameVersion()
        {
            // Arrange
            string name = "CoolPackage";

            // Configure This Package
            int majorOne = 5;
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
            int majorTwo = 5;
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
            var result = thisPackage.CompareTo(otherPackage);

            //Assert
            Assert.AreEqual(0, result);
        }

    }
}
