using Academy.Core.Factories;
using Academy.Models.Utils.LectureResources;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Models.Core.Factories.AcademyFactoryTests
{
    [TestFixture]
    class CreateLecture_Should
    {
        [Test]
        public void ReturnVideoResource_WhenVideoTypeIsPassed()
        {
            // Arrange
            var factory = AcademyFactory.Instance;

            // Act
            var resource = factory.CreateLectureResource("video", "ValidName", "11111");

            // Assert
            Assert.IsInstanceOf<VideoResource>(resource);
        }

        [Test]
        public void ReturnDemoResource_WhenDemoTypeIsPassed()
        {
            // Arrange
            var factory = AcademyFactory.Instance;

            // Act
            var resource = factory.CreateLectureResource("demo", "ValidName", "11111");

            // Assert
            Assert.IsInstanceOf<DemoResource>(resource);
        }

        [Test]
        public void ThrowArgumentException_WhenInvalidResourceType()
        {
            // Arrange
            var factory = AcademyFactory.Instance;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateLectureResource("pesho", "ValidName", "11111"));
        }
    }
}
