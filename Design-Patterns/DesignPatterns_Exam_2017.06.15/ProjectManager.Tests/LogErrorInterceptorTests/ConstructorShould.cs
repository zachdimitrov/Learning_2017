using System;
using Moq;
using NUnit.Framework;
using ProjectManager.ConsoleClient.Interceptors;
using ProjectManager.Framework.Core.Common.Contracts;

namespace ProjectManager.Tests.LogErrorInterceptorTests
{
    [TestFixture]
    class ConstructorShould
    {
        [Test]
        public void CreateCorrectInstanceWhenProperArgumentsProvided()
        {
            // arrange
            var loggerMock = new Mock<ILogger>();
            var writerMock = new Mock<IWriter>();
            // act
            var logInterceptor = new LogErrorInterceptor(loggerMock.Object, writerMock.Object);
            // assert
            Assert.IsInstanceOf<LogErrorInterceptor>(logInterceptor);
        }

        [Test]
        public void ThrowArgumentNullExceptionWhenLoggerIsMissing()
        {
            // arrange
            var writerMock = new Mock<IWriter>();
            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => new LogErrorInterceptor(null, writerMock.Object));
        }

        [Test]
        public void ThrowArgumentNullExceptionWhenWriterIsMissing()
        {
            // arrange
            var loggerMock = new Mock<ILogger>();
            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => new LogErrorInterceptor(loggerMock.Object, null));
        }
    }
}
