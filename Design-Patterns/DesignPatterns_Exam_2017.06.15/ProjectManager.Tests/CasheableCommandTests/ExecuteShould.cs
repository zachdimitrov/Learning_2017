using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Commands.Decorators;
using ProjectManager.Framework.Core.Common.Providers.Validators;
using ProjectManager.Framework.Services;

namespace ProjectManager.Tests.CasheableCommandTests
{
    [TestFixture]
    class ExecuteShould
    {
        [Test]
        public void RunProvidedCommandExecuteMethodOnlyOnce()
        {
            // arrange
            var count = 3;
            var commandMock = new Mock<ICommand>();
            commandMock.Setup(x => x.ParameterCount).Returns(count);
            commandMock.Setup(x => x.Execute(It.IsAny<IList<string>>())).Verifiable();

            var validatorMock = new Mock<IParameterValidator>();
            validatorMock.Setup(v => v.ValidateParameters(It.IsAny<IList<string>>(), It.IsAny<int>())).Verifiable();

            var cashingServMock = new Mock<ICachingService>();
            cashingServMock.Setup(c => c.AddCacheValue(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<object>())).Verifiable();
            cashingServMock.Setup(c => c.GetCacheValue(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(It.IsAny<string>());
            // act
            var casheableCommand = new CacheableCommand(commandMock.Object, cashingServMock.Object,
                validatorMock.Object);
            try
            {
                casheableCommand.Execute(It.IsAny<IList<string>>());
            }
            catch { }
            // assert
            commandMock.Verify(x => x.Execute(It.IsAny<IList<string>>()), Times.Once);
        }
    }
}
