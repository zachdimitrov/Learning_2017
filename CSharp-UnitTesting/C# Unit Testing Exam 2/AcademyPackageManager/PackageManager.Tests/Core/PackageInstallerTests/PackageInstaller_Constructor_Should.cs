using Moq;
using NUnit.Framework;
using PackageManager.Core;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Repositories.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Core.PackageInstallerTests
{
    [TestFixture]
    class PackageInstaller_Constructor_Should
    {
        [Test]
        public void RestorePackages_WhenObjectIsConstructed()
        {
            // Arrange
            var downloaderMock = new Mock<IDownloader>();
            var projectMock = new Mock<IProject>();
            var repoMock = new Mock<IRepository<IPackage>>();
            var packageMock = new Mock<IPackage>();

            //var collection = new List<IPackage>() { packageMock.Object };
            //repoMock.Setup(x => x.GetAll()).Returns(collection);

            projectMock.Setup(x => x.Location).Returns("Plovdiv");
            projectMock.Setup(x => x.Name).Returns("MyProject");
            projectMock.Setup(x => x.PackageRepository).Returns(repoMock.Object);


            // Act
            var installer = new PackageInstaller(downloaderMock.Object, projectMock.Object);

            // Assert
            repoMock.Verify(x => x.GetAll(), Times.Once);
        }
    }
}
