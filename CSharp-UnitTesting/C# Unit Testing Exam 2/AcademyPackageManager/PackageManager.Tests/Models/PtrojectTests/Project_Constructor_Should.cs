using Moq;
using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using PackageManager.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models.PtrojectTests
{
    [TestFixture]
    class Project_Constructor_Should
    {
        [Test]
        public void SetCorrectlyPackageRepository_WhenValidOptionalPackagesPassedIsNull()
        {
            // Arrange
            string name = "Batman";
            string location = "Plovdiv";
            IRepository<IPackage> repo = null;

            // Act
            var project = new Project(name, location, repo);

            // Assert
            Assert.IsInstanceOf<PackageRepository>(project.PackageRepository);
        }

        [Test]
        public void SetCorrectlyPackageRepository_WhenValidPackagesArePassed()
        {
            // Arrange
            string name = "Batman";
            string location = "Plovdiv";
            var packageMock = new Mock<IPackage>();
            var repoMock = new Mock<IRepository<IPackage>>();
            repoMock.Setup(x => x.Add(packageMock.Object));

            // Act
            var project = new Project(name, location, repoMock.Object);

            // Assert
            Assert.AreSame(repoMock.Object, project.PackageRepository);
        }

        [Test]
        public void SetNameCorrectly_WhenValidValuePassed()
        {
            // Arrange
            string expectedName = "Batman";
            string location = "Plovdiv";
            IRepository<IPackage> repo = null;

            // Act
            var project = new Project(expectedName, location, repo);

            // Assert
            Assert.AreEqual(expectedName, project.Name);
        }

        [Test]
        public void SetLocationCorrectly_WhenValidValuePassed()
        {
            // Arrange
            string name = "Batman";
            string expectedLocation = "Plovdiv";
            IRepository<IPackage> repo = null;

            // Act
            var project = new Project(name, expectedLocation, repo);

            // Assert
            Assert.AreEqual(expectedLocation, project.Location);
        }

        [Test]
        public void ThrowsArgumentNullException_WhenInvalidNamePassed()
        {
            // Arrange
            string invalidName = null;
            string location = "Plovdiv";
            IRepository<IPackage> repo = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException >(() => new Project(invalidName, location, repo));
        }

        [Test]
        public void ThrowsArgumentNullException_WhenInvalidLocationPassed()
        {
            // Arrange
            string name = "CoolProject";
            string invalidLocation = null;
            IRepository<IPackage> repo = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Project(name, invalidLocation, repo));
        }
    }
}
