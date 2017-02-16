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
    public class SetName_Should
    {
        [TestCase("i")]
        [TestCase("Very very very very very very very very very very very very very very very very very very long")]
        public void ThrowsArhumentException_WhenInvalidValueIsPassed(string name)
        {
            // Arrange
            var course = new Course("Valid name", 5, new DateTime(2017, 02, 10), new DateTime(2017, 03, 10));

            // Act & Assert
            Assert.Throws<ArgumentException>(() => course.Name = name);
        }
    }
}
