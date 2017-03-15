using Moq;
using NUnit.Framework;
using PackageManager.Core;
using PackageManager.Core.Contracts;
using PackageManager.Enums;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using PackageManager.Repositories.Contracts;
using PackageManager.Tests.Core.Mocks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Core.PackageInstallerTests
{
    [TestFixture]
    class PerformOperation_Should
    {
        [Test]
        public void CallOneTimeRemove_WhenOperationIsInstall()
        {
            // Arrange
            var downloaderMock = new Mock<IDownloader>();
            var projectMock = new Mock<IProject>();
            var packageMock = new Mock<IPackage>();
            packageMock.Setup(x => x.Name).Returns("MyPackage");
            packageMock.Setup(x => x.Dependencies).Returns(new HashSet<IPackage>());

            var collection = new HashSet<IPackage>() { packageMock.Object };
            var repoMock = new PackageRepositoryMock(collection);

            projectMock.Setup(x => x.Location).Returns("Plovdiv");
            projectMock.Setup(x => x.Name).Returns("MyProject");
            projectMock.Setup(x => x.PackageRepository).Returns(repoMock);


            // Act
            var installer = new PackageInstaller(downloaderMock.Object, projectMock.Object);

            // Assert
            downloaderMock.Verify(x => x.Remove("MyPackage"), Times.Once);
        }

        [Test]
        public void CallTwoTimesDownload_WhenOperationIsInstall_AndEmptyDependenciesList()
        {
            // Arrange
            var downloaderMock = new Mock<IDownloader>();
            var projectMock = new Mock<IProject>();

            var versionMock = new Mock<IVersion>();
            versionMock.Setup(x => x.Major).Returns(1);
            versionMock.Setup(x => x.Minor).Returns(1);
            versionMock.Setup(x => x.Patch).Returns(1);
            versionMock.Setup(x => x.VersionType).Returns(VersionType.alpha);

            var packageMock = new Mock<IPackage>();
            packageMock.Setup(x => x.Name).Returns("MyPackage");
            packageMock.Setup(x => x.Dependencies).Returns(new HashSet<IPackage>());
            packageMock.Setup(x => x.Version).Returns(versionMock.Object);

            var collection = new HashSet<IPackage>() { packageMock.Object };
            var repoMock = new PackageRepositoryMock(collection);

            projectMock.Setup(x => x.Location).Returns("Plovdiv");
            projectMock.Setup(x => x.Name).Returns("MyProject");
            projectMock.Setup(x => x.PackageRepository).Returns(repoMock);


            // Act
            var installer = new PackageInstaller(downloaderMock.Object, projectMock.Object);

            // Assert
            downloaderMock.Verify(x => x.Download(It.IsAny<string>()), Times.Exactly(2));
        }

        [Test]
        public void CallFourTimesDownload_WhenOperationIsInstall_AndOneDependencyInTheList()
        {
            // Arrange
            var downloaderMock = new Mock<IDownloader>();
            var projectMock = new Mock<IProject>();

            var dversionMock = new Mock<IVersion>();
            dversionMock.Setup(x => x.Major).Returns(2);
            dversionMock.Setup(x => x.Minor).Returns(2);
            dversionMock.Setup(x => x.Patch).Returns(2);
            dversionMock.Setup(x => x.VersionType).Returns(VersionType.alpha);

            var dpackageMock = new Mock<IPackage>();
            dpackageMock.Setup(x => x.Name).Returns("MyPackage2");
            dpackageMock.Setup(x => x.Dependencies).Returns(new HashSet<IPackage>());
            dpackageMock.Setup(x => x.Version).Returns(dversionMock.Object);

            var depList = new HashSet<IPackage>();
            depList.Add(dpackageMock.Object);

            var versionMock = new Mock<IVersion>();
            versionMock.Setup(x => x.Major).Returns(1);
            versionMock.Setup(x => x.Minor).Returns(1);
            versionMock.Setup(x => x.Patch).Returns(1);
            versionMock.Setup(x => x.VersionType).Returns(VersionType.alpha);

            var packageMock = new Mock<IPackage>();
            packageMock.Setup(x => x.Name).Returns("MyPackage");
            packageMock.Setup(x => x.Dependencies).Returns(depList);
            packageMock.Setup(x => x.Version).Returns(versionMock.Object);

            var collection = new HashSet<IPackage>() { packageMock.Object };
            var repoMock = new PackageRepositoryMock(collection);

            projectMock.Setup(x => x.Location).Returns("Plovdiv");
            projectMock.Setup(x => x.Name).Returns("MyProject");
            projectMock.Setup(x => x.PackageRepository).Returns(repoMock);


            // Act
            var installer = new PackageInstaller(downloaderMock.Object, projectMock.Object);

            // Assert
            downloaderMock.Verify(x => x.Download(It.IsAny<string>()), Times.Exactly(4));
        }
    }
}
