using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Ninject.Extensions.Interception;
using NUnit.Framework;
using ProjectManager.ConsoleClient.Interceptors;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;

namespace ProjectManager.Tests.LogErrorInterceptorTests
{
    [TestFixture]
    class InterceptShould
    {
        [Test]
        public void RunTheProceedMethodOnlyOneTime()
        {
            // arrange
            var loggerMock = new Mock<ILogger>();
            var writerMock = new Mock<IWriter>();
            var invocationMock = new Mock<IInvocation>();
            // act
            var logInterceptor = new LogErrorInterceptor(loggerMock.Object, writerMock.Object);
            logInterceptor.Intercept(invocationMock.Object);
            // assert
            invocationMock.Verify(i => i.Proceed(), Times.Once);
        }

        [Test]
        public void LoggerShouldLogOneTimeIfUserValidationExceptionIsThrown()
        {
            // arrange
            var ex = new UserValidationException("test");
            var loggerMock = new Mock<ILogger>();
            var writerMock = new Mock<IWriter>();
            var invocationMock = new Mock<IInvocation>();
            invocationMock.Setup(i => i.Proceed()).Throws(ex);
            invocationMock.Setup(i => i.ReturnValue).Returns(ex);
            // act
            var logInterceptor = new LogErrorInterceptor(loggerMock.Object, writerMock.Object);
            logInterceptor.Intercept(invocationMock.Object);
            // assert
            loggerMock.Verify(i => i.Error(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void LoggerShouldLogOneTimeIfExceptionIsThrown()
        {
            // arrange
            var ex = new Exception("test");
            var loggerMock = new Mock<ILogger>();
            var writerMock = new Mock<IWriter>();
            var invocationMock = new Mock<IInvocation>();
            invocationMock.Setup(i => i.Proceed()).Throws(ex);
            invocationMock.Setup(i => i.ReturnValue).Returns(ex);
            // act
            var logInterceptor = new LogErrorInterceptor(loggerMock.Object, writerMock.Object);
            logInterceptor.Intercept(invocationMock.Object);
            // assert
            loggerMock.Verify(i => i.Error(It.IsAny<string>()), Times.Once);
        }
    }
}
