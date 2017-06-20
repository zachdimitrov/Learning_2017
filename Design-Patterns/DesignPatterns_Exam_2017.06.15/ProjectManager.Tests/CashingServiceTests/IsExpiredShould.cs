using System;
using Moq;
using NUnit.Framework;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Commands.Decorators;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Providers.Validators;
using ProjectManager.Framework.Services;

namespace ProjectManager.Tests.CasheableCommandTests
{
    [TestFixture]
    class IsExpiredShould
    {
        [Test]
        public void ReturnFalseIfThereAreEnoughSecondsProvided()
        {
            // arrange
            var expTime = new DateTime(2017, 6, 15);
            var dateTimeMock = new Mock<IDateTimeProvider>();
            dateTimeMock.Setup(d => d.Now).Returns(expTime);
            // act
            var cachingService = new CachingService(TimeSpan.FromSeconds(20), dateTimeMock.Object);
            // assert
            Assert.AreEqual(cachingService.IsExpired, false);
        }

        [Test]
        public void ReturnTrueIfThereAreNoSecondsLeft()
        {
            // arrange
            var expTime = new DateTime(2017, 6, 15);
            var dateTimeMock = new Mock<IDateTimeProvider>();
            dateTimeMock.Setup(d => d.Now).Returns(expTime);
            // act
            var cachingService = new CachingService(TimeSpan.FromSeconds(0), dateTimeMock.Object);
            // assert
            Assert.AreEqual(cachingService.IsExpired, false);
        }
    }
}
