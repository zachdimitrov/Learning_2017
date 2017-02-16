using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Models;
using Academy.Models.Contracts;
using NUnit.Framework;

namespace Academy.Tests
{
    [TestFixture]
    public class GetName_Should
    {
        [Test]
        public void ReturnTheProperValue_WhenGetMethodIsCalledd()
        {
            // Arrange
            var course = new Course("Valid name", 5, new DateTime(2017, 02, 10), new DateTime(2017, 03, 10));

            // Act
            var result = course.Name;

            // Assert
            Assert.AreEqual("Valid name", result);
        }
    }
}
