using Moq;
using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Info.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Repositories.PackageRepositoryTests
{
    [TestFixture]
    class Add_Should
    {
        [Test]
        public void AddPackageSuccessFully_IfDoesNotExistInPackages()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var repo = new PackageRepository(loggerMock.Object, null);

            var versionMock = new Mock<IVersion>();
            versionMock.Setup(x => x.Major).Returns(1);
            versionMock.Setup(x => x.Minor).Returns(1);
            versionMock.Setup(x => x.Patch).Returns(1);
            versionMock.Setup(x => x.VersionType).Returns(VersionType.alpha);

            var packageMock = new Mock<IPackage>();
            packageMock.Setup(x => x.Name).Returns("MyPackage");
            packageMock.Setup(x => x.Dependencies).Returns(new HashSet<IPackage>());
            packageMock.Setup(x => x.Version).Returns(versionMock.Object);

            // Act
            repo.Add(packageMock.Object);

            // Assert
            var allPackages = repo.GetAll();
            Assert.AreSame(packageMock.Object, allPackages.First());
        }

        [Test]
        public void ThrowArgumentNullExceptionWithProperMessage_IfpackageIsNull()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var repo = new PackageRepository(loggerMock.Object, null);
            var invalidPackage = (IPackage)null;

            // Act & Assert
            var expectedExceptionMessage = "The package cannot be null";
            var exc = Assert.Throws<ArgumentNullException>(
                () => repo.Add(invalidPackage));
            var actualExceptionMessage = exc.Message;

            // Assert
            StringAssert.Contains(expectedExceptionMessage, actualExceptionMessage);
        }

        [Test]
        public void AddPackageReturnsLog_IfExistInPackages()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var repo = new PackageRepository(loggerMock.Object, null);

            var versionMock = new Mock<IVersion>();
            versionMock.Setup(x => x.Major).Returns(1);
            versionMock.Setup(x => x.Minor).Returns(1);
            versionMock.Setup(x => x.Patch).Returns(1);
            versionMock.Setup(x => x.VersionType).Returns(VersionType.alpha);

            var packageMock = new Mock<IPackage>();
            packageMock.Setup(x => x.Name).Returns("MyPackage");
            packageMock.Setup(x => x.Dependencies).Returns(new HashSet<IPackage>());
            packageMock.Setup(x => x.Version).Returns(versionMock.Object);

            // Act
            repo.Add(packageMock.Object);
            repo.Add(packageMock.Object);

            // Assert
            loggerMock.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(3 + 1));
        }

        public void AddPackageWithHigherVersionReturnsLog_IfExistInPackages()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var repo = new PackageRepository(loggerMock.Object, null);

            var versionMock = new Mock<IVersion>();
            versionMock.Setup(x => x.Major).Returns(1);
            versionMock.Setup(x => x.Minor).Returns(1);
            versionMock.Setup(x => x.Patch).Returns(1);
            versionMock.Setup(x => x.VersionType).Returns(VersionType.alpha);

            var packageMock = new Mock<IPackage>();
            packageMock.Setup(x => x.Name).Returns("MyPackage");
            packageMock.Setup(x => x.Dependencies).Returns(new HashSet<IPackage>());
            packageMock.Setup(x => x.Version).Returns(versionMock.Object);

            var versionMock2 = new Mock<IVersion>();
            versionMock2.Setup(x => x.Major).Returns(2);
            versionMock2.Setup(x => x.Minor).Returns(1);
            versionMock2.Setup(x => x.Patch).Returns(1);
            versionMock2.Setup(x => x.VersionType).Returns(VersionType.alpha);

            var packageMock2 = new Mock<IPackage>();
            packageMock2.Setup(x => x.Name).Returns("MyPackage");
            packageMock2.Setup(x => x.Dependencies).Returns(new HashSet<IPackage>());
            packageMock2.Setup(x => x.Version).Returns(versionMock2.Object);

            // Act
            repo.Add(packageMock.Object);
            repo.Add(packageMock2.Object);

            // Assert
            loggerMock.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(2 + 1));
        }

        [Test]
        public void UpdatePackageReturnsFalse_IfExistInPackages()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var repo = new PackageRepository(loggerMock.Object, null);

            var versionMock = new Mock<IVersion>();
            versionMock.Setup(x => x.Major).Returns(1);
            versionMock.Setup(x => x.Minor).Returns(1);
            versionMock.Setup(x => x.Patch).Returns(1);
            versionMock.Setup(x => x.VersionType).Returns(VersionType.alpha);

            var packageMock = new Mock<IPackage>();
            packageMock.Setup(x => x.Name).Returns("MyPackage");
            packageMock.Setup(x => x.Dependencies).Returns(new HashSet<IPackage>());
            packageMock.Setup(x => x.Version).Returns(versionMock.Object);

            // Act
            repo.Add(packageMock.Object);
            bool result = repo.Update(packageMock.Object);

            // Assert
            Assert.AreEqual(false, result);
        }
    }
}
