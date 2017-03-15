using Moq;
using NUnit.Framework;
using PackageManager.Commands;
using PackageManager.Core.Contracts;
using PackageManager.Enums;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Commands.InstallCommandTests
{
    [TestFixture]
    class InstallCommand_Constructor_Should
    {
        [Test]
        public void SetTheAppropriateValues_WhenValidParametersPassed()
        {
            // Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();
            installerMock.Setup(x => x.Operation).Returns(InstallerOperation.Install);

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

            var packageMock = new Mock<IPackage>();
            packageMock.Setup(x => x.Name).Returns("CoolPackage");
            packageMock.Setup(x => x.Version).Returns(thisVersionMock.Object);
            packageMock.Setup(x => x.Dependencies).Returns(thisDependenciesMock.Object);
            
            
            // Act 
            var installCommand = new InstallCommand(installerMock.Object, packageMock.Object);

            // Assert
            Assert.IsInstanceOf<InstallCommand>(installCommand);
        }

        [Test]
        public void SetTheRightValue_ForInstaller()
        {
            // Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();
            installerMock.Setup(x => x.Operation).Returns(InstallerOperation.Install);

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

            var packageMock = new Mock<IPackage>();
            packageMock.Setup(x => x.Name).Returns("CoolPackage");
            packageMock.Setup(x => x.Version).Returns(thisVersionMock.Object);
            packageMock.Setup(x => x.Dependencies).Returns(thisDependenciesMock.Object);


            // Act 
            var installCommand = new InstallCommand(installerMock.Object, packageMock.Object);
            installCommand.Execute();

            // Assert
            installerMock.Verify(x => x.PerformOperation(It.IsAny<IPackage>()), Times.Once);
        }

        [Test]
        public void SetTheRightValue_ForPackage()
        {
            // Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();
            installerMock.Setup(x => x.Operation).Returns(InstallerOperation.Install);

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

            var packageMock = new Mock<IPackage>();
            packageMock.Setup(x => x.Name).Returns("CoolPackage");
            packageMock.Setup(x => x.Version).Returns(thisVersionMock.Object);
            packageMock.Setup(x => x.Dependencies).Returns(thisDependenciesMock.Object);


            // Act 
            var installCommand = new InstallCommand(installerMock.Object, packageMock.Object);
            installCommand.Execute();

            // Assert
            installerMock.Verify(x => x.PerformOperation(packageMock.Object), Times.Once);
        }
    }
}
