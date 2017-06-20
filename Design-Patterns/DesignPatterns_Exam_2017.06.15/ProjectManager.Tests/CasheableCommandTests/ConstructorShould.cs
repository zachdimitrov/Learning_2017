using System;
using Moq;
using NUnit.Framework;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Commands.Decorators;
using ProjectManager.Framework.Core.Common.Providers.Validators;
using ProjectManager.Framework.Services;

namespace ProjectManager.Tests.CasheableCommandTests
{
    [TestFixture]
    class ConstructorShould
    {
        [Test]
        public void CreateTheCorrectObjectWhenProperParametersProvided()
        {
            // arrange
            var commandMock = new Mock<ICommand>();
            var validatorMock = new Mock<IParameterValidator>();
            var cashingServMock = new Mock<ICachingService>();
            // act
            var casheableCommand = new CacheableCommand(commandMock.Object, cashingServMock.Object,
                validatorMock.Object);
            // assert
            Assert.IsInstanceOf<CacheableCommand>(casheableCommand);
        }

        [Test]
        public void ThrowArgumentNullExceptionIfCommandIsNull()
        {
            // arrange
            var validatorMock = new Mock<IParameterValidator>();
            var cashingServMock = new Mock<ICachingService>();
            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => new CacheableCommand(null, cashingServMock.Object,
                validatorMock.Object));
        }

        [Test]
        public void ThrowArgumentNullExceptionIfValidatorIsNull()
        {
            // arrange
            var commandMock = new Mock<ICommand>();
            var cashingServMock = new Mock<ICachingService>();
            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => new CacheableCommand(commandMock.Object, cashingServMock.Object,
                null));
        }

        [Test]
        public void ThrowArgumentNullExceptionIfCachingServiceIsNull()
        {
            // arrange
            var commandMock = new Mock<ICommand>();
            var validatorMock = new Mock<IParameterValidator>();
            // act
            // assert
            Assert.Throws<ArgumentNullException>(() => new CacheableCommand(commandMock.Object, null,
                validatorMock.Object));
        }
    }
}
