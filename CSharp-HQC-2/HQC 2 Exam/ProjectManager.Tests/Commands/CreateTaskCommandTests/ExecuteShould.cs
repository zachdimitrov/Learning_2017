using System;
using Moq;
using NUnit.Framework;
using ProjectManager.Commands;
using ProjectManager.Commands.Contracts;
using ProjectManager.Common;
using ProjectManager.Common.Providers.Contracts;
using System.Collections.Generic;
using ProjectManager.Common.Exceptions;

namespace ProjectManager.Tests.Commands.CreateTaskCommandTests
{
    [TestFixture]
    public class ExecuteShould
    {
        [Test]
        public void ThrowWhenInvalidParameterCountArePassed()
        {
            var parameters = new List<string> {"1", "2", "3"};
            var commandTask = new CreateTaskCommand();

            Assert.Throws<ArgumentOutOfRangeException>(() => commandTask.Execute(parameters));
        }

        [Test]
        public void ThrowWhenEmptyParameterCountArePassed()
        {
            var parameters = new List<string> {};
            var commandTask = new CreateTaskCommand();

            Assert.Throws<ArgumentOutOfRangeException>(() => commandTask.Execute(parameters));
        }
    }
}
