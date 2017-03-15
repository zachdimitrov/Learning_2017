using Moq;
using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models.PackageTests
{
    [TestFixture]
    class Package_Constructor_Should
    {
        [Test]
        public void SetDependenciesCorrectly_WhenOptionalDependenciesParameterUsed()
        {
            // Arrange
            string name = "CoolPackage";
            var versionMock = new Mock<IVersion>();
            ICollection<IPackage> dependencies = null;

            // Act
            var package = new Package(name, versionMock.Object, dependencies);

            // Assert
            Assert.IsInstanceOf<HashSet<IPackage>>(package.Dependencies);
        }

        [Test]
        public void SetDependenciesCorrectly_WhenDependenciesParameterIsPassed()
        {
            // Arrange
            string name = "CoolPackage";
            var versionMock = new Mock<IVersion>();
            var dependenciesMock = new Mock<ICollection<IPackage>>();

            // Act
            var package = new Package(name, versionMock.Object, dependenciesMock.Object);

            // Assert
            Assert.AreSame(dependenciesMock.Object, package.Dependencies);
        }

        [Test]
        public void SetNameCorrectly_WhenValidValuePassed()
        {
            // Arrange
            string expectedName = "CoolPackage";
            var versionMock = new Mock<IVersion>();
            var dependenciesMock = new Mock<ICollection<IPackage>>();

            // Act
            var package = new Package(expectedName, versionMock.Object, dependenciesMock.Object);

            // Assert
            Assert.AreEqual(expectedName, package.Name);
        }

        [Test]
        public void SetVersionCorrectly_WhenValidValuePassed()
        {
            // Arrange
            string name = "CoolPackage";
            var versionMock = new Mock<IVersion>();
            var dependenciesMock = new Mock<ICollection<IPackage>>();

            // Act
            var package = new Package(name, versionMock.Object, dependenciesMock.Object);

            // Assert
            Assert.AreSame(versionMock.Object, package.Version);
        }

        [Test]
        public void SetURLCorrectly_WhenValidValuesPassed()
        {
            // Arrange
            string name = "CoolPackage";

            int major = 5;
            int minor = 1;
            int patch = 3;
            VersionType type = VersionType.alpha;

            var expectedUrl = "5.1.3-alpha";
            // string.Format("{0}.{1}.{2}-{3}", major, minor, patch, type);

            var versionMock = new Mock<IVersion>();
            versionMock.Setup(x => x.Major).Returns(major);
            versionMock.Setup(x => x.Minor).Returns(minor);
            versionMock.Setup(x => x.Patch).Returns(patch);
            versionMock.Setup(x => x.VersionType).Returns(type);

            var dependenciesMock = new Mock<ICollection<IPackage>>();

            // Act
            var package = new Package(name, versionMock.Object, dependenciesMock.Object);

            // Assert
            Assert.AreEqual(expectedUrl, package.Url);
        }

        [Test]
        public void ThrowsArgumentNullException_WhenInvalidNamePassed()
        {
            // Arrange
            string invalidName = null;
            var versionMock = new Mock<IVersion>();
            var dependenciesMock = new Mock<ICollection<IPackage>>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Package(invalidName, versionMock.Object, dependenciesMock.Object));
        }

        [Test]
        public void ThrowsArgumentNullException_WhenInvalidVersionPassed()
        {
            // Arrange
            string name = "Garga";
            var invalidVersion = (IVersion)null;
            var dependenciesMock = new Mock<ICollection<IPackage>>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Package(name, invalidVersion, dependenciesMock.Object));
        }
    }
}
