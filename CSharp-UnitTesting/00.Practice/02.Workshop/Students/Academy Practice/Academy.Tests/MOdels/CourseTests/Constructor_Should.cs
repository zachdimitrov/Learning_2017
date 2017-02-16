using Academy.Models;
using Academy.Models.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Academy.Tests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void SetProperName_WhenTheObjectIsConstructed()
        {
            // Arrange & Act
            var course = new Course("Valid name", 5, new DateTime(2017, 02, 10), new DateTime(2017, 03, 10));

            // Assert
            Assert.AreEqual("Valid name", course.Name);
        }

        [Test]
        public void SetProperStartingDate_WhenTheObjectIsConstructed()
        {
            // Arrange & Act
            var course = new Course("Valid name", 5, new DateTime(2017, 02, 10), new DateTime(2017, 03, 10));

            // Assert
            Assert.AreEqual(new DateTime(2017, 02, 10), course.StartingDate);
        }

        [Test]
        public void SetProperEndingDate_WhenTheObjectIsConstructed()
        {
            // Arrange & Act
            var course = new Course("Valid name", 5, new DateTime(2017, 02, 10), new DateTime(2017, 03, 10));

            // Assert
            Assert.AreEqual(new DateTime(2017, 03, 10), course.EndingDate);
        }

        [TestCase(1)]
        [TestCase(4)]
        [TestCase(7)]
        public void SetProperLecturesPerWeekNumber_WhenTheObjectIsConstructed(int number)
        {
            // Arrange & Act
            var course = new Course("Valid name", number, new DateTime(2017, 02, 10), new DateTime(2017, 03, 10));

            // Assert
            Assert.AreEqual(number, course.LecturesPerWeek);
        }

        [Test]
        public void InitializeLecturesCollection_whenObjectIsConstructed()
        {
            // Arrange & Act
            var course = new Course("Valid name", 3, new DateTime(2017, 02, 10), new DateTime(2017, 03, 10));

            // Assert
            // Assert.IsInstanceOf(typeof(List<ILecture>), course.Lectures);
            // Assert.AreEqual(0, course.Lectures.Count);
            Assert.IsNotNull(course.Lectures);
        }
    }
}
