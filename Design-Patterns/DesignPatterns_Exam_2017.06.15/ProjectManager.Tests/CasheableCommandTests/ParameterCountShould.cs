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
    class ParameterCountShould
    {
        [Test]
        public void ReturnTheCorrectParametersCountProvidedWithCommand()
        {
            // arrange
            var count = 3;
            var commandMock = new Mock<ICommand>();
            commandMock.Setup(x => x.ParameterCount).Returns(count);
            var validatorMock = new Mock<IParameterValidator>();
            var cashingServMock = new Mock<ICachingService>();
            // act
            var casheableCommand = new CacheableCommand(commandMock.Object, cashingServMock.Object,
                validatorMock.Object);
            // assert
            Assert.AreEqual(count, casheableCommand.ParameterCount);
        }
    }
}
