using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academy.Models;
using Academy.Models.Contracts;
using NUnit.Framework;
using Moq;
using Academy.Models.Abstractions;
using Academy.Tests.Models.Abstractions.Mocks;

namespace Academy.Tests
{
    [TestFixture]
    public class GetUserName_Should
    {
        [Test]
        public void ReturnProperUserName_WhenTheGetMethodIsCalled()
        {
            // Arrange
            var user = new UserMock("Valid Name");

            // Act
            var foundUserName = user.Username;

            // Assert
            Assert.AreEqual("Valid Name", foundUserName);
        }
    }
}
