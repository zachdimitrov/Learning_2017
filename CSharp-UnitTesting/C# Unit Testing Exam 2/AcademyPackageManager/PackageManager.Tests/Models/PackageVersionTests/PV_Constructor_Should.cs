using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models.PackageVersionTests
{
    [TestFixture]
    class PV_Constructor_Should
    {
        [Test]
        public void SetThePropertiesCorrectly_WhenProperPassedValues()
        {
            // Arrange
            int majorExpected = 5;
            int minorExpected = 0;
            int patchExpected = 3;
            VersionType typeExpected = VersionType.alpha;

            // Act
            var packageVersion = new PackageVersion(majorExpected, minorExpected, patchExpected, typeExpected);

            var majorActual = packageVersion.Major;
            var minorActual = packageVersion.Minor;
            var patchActual = packageVersion.Patch;
            var typeActual = packageVersion.VersionType;

            // Assert
            Assert.AreEqual(majorExpected, majorActual);
            Assert.AreEqual(minorExpected, minorActual);
            Assert.AreEqual(patchExpected, patchActual);
            Assert.AreEqual(typeExpected, typeActual);
        }

        [Test]
        public void ThrowArgumentException_IfInvalidMajorPassed()
        {
            // Arrange
            int majorPassed = -5; // Invalid value
            int minorPassed = 0;
            int patchPassed = 3;
            VersionType typePassed = VersionType.alpha;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(majorPassed, minorPassed, patchPassed, typePassed));
        }

        [Test]
        public void ThrowArgumentException_IfInvalidMinorPassed()
        {
            // Arrange
            int majorPassed = 5; 
            int minorPassed = -5; // Invalid value
            int patchPassed = 3;
            VersionType typePassed = VersionType.alpha;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(majorPassed, minorPassed, patchPassed, typePassed));
        }

        [Test]
        public void ThrowArgumentException_IfInvalidpPatchPassed()
        {
            // Arrange
            int majorPassed = 5;
            int minorPassed = 0; 
            int patchPassed = -5; // Invalid value
            VersionType typePassed = VersionType.alpha;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(majorPassed, minorPassed, patchPassed, typePassed));
        }

        [Test]
        public void ThrowArgumentException_IfInvalidpVersionTypePassed()
        {
            // Arrange
            int majorPassed = 5;
            int minorPassed = 0;
            int patchPassed = -5; 
            VersionType typePassed = (VersionType)7; // Invalid value

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(majorPassed, minorPassed, patchPassed, typePassed));
        }
    }
}
