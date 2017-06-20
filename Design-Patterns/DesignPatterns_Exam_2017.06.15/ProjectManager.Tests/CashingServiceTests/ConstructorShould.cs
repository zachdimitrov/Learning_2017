using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Services;

namespace ProjectManager.Tests.CashingServiceTests
{
    [TestFixture]
    class ConstructorShould
    {
        [Test]
        public void CreateProperInstanceWhenInvokedWithCorrectArguments()
        {
            // arrange
            var dateTimeMock = new Mock<IDateTimeProvider>();
            // act
            var cachingService = new CachingService(TimeSpan.FromSeconds(20), dateTimeMock.Object);
            // assert
            Assert.IsInstanceOf<CachingService>(cachingService);
        }

        [TestCase(-1)]
        [TestCase(-20)]
        [TestCase(-1000)]
        public void ThrowArgumentNullExceptionIfIncorrectTimeSpanProvided(int s)
        {
            // arrange
            var dateTimeMock = new Mock<IDateTimeProvider>();
            // act
            // assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new CachingService(TimeSpan.FromSeconds(s), dateTimeMock.Object));
        }

        [Test]
        public void ThrowArgumentNullExceptionIfDateTimeProviderNotProvided()
        {
            // arrange
            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => new CachingService(TimeSpan.FromSeconds(20), null));
        }
    }
}
