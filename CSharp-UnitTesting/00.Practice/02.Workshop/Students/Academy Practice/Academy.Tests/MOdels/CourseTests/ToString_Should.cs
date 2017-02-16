using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Models;
using Academy.Models.Contracts;
using NUnit.Framework;
using Moq;

namespace Academy.Tests
{
    [TestFixture]
    public class ToString_Should
    {
        [Test]
        public void IterateOverLecturesCollection_WhenCollectionIsNotEmpty()
        {
            // Arrange
            var course = new Course("Valid name", 5, new DateTime(2017, 02, 10), new DateTime(2017, 03, 10));
            var lectureMock = new Mock<ILecture>();

            lectureMock.Setup(x => x.ToString());

            course.Lectures.Add(lectureMock.Object);

            // Act
            course.ToString();

            // Assert
            lectureMock.Verify(x => x.ToString(), Times.Once);
        }

        [Test]
        public void AddMessageToEndResult_WhenCollectionIsEmpty()
        {
            // Arrange
            var course = new Course("Valid name", 5, new DateTime(2017, 02, 10), new DateTime(2017, 03, 10));

            // Act
            var result = course.ToString();

            // Assert
            StringAssert.Contains("no lectures", result);
        }
    }
}
