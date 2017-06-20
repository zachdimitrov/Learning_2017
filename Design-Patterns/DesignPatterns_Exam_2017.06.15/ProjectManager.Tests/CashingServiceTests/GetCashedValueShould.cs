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
    class GetCachedValueShould
    {
        [Test]
        public void ReturnTheCorrectCasheValueAdded()
        {
            // arrange
            var obj = new object();
            var expTime = new DateTime(2017, 6, 15);
            var dateTimeMock = new Mock<IDateTimeProvider>();
            dateTimeMock.Setup(d => d.Now).Returns(expTime);
            // act
            var cachingService = new CachingService(TimeSpan.FromSeconds(20), dateTimeMock.Object);
            cachingService.AddCacheValue("x", "y", obj);
            // assert
            Assert.AreEqual(cachingService.GetCacheValue("x", "y"), obj);
        }
    }
}
