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
    class Update_Should
    {
        
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
