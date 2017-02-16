using Moq;
using NUnit.Framework;
using System;
using Tasker.Core;
using Tasker.Core.Contracts;
using Tasker.Modules;
using Tasker.Tests.Core.Mocks;

namespace Tasker.Tests.Core
{
    [TestFixture]
    public class TaskManagerTests
    {
        [Test]
        public void Add_Should_LogSuccesfulMessage_WhenValidTaskPased()
        {
            // Arrange
            var mockIDProvider = new Mock<IIdProvider>();

            mockIDProvider.Setup(x => x.NextId()).Returns(1);

            var mockLogger = new Mock<ILogger>();
            var mockTask = new Mock<ITaskJob>();

            var manager = new TaskManager(mockIDProvider.Object, mockLogger.Object);
            // Act
            manager.Add(mockTask.Object);

            // Assert
            mockLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void TaskManager_ShouldAssignId_WhenTaskIsAdded()
        {
            // Arrange
            var mockIDProvider = new Mock<IIdProvider>();

            mockIDProvider.Setup(x => x.NextId()).Returns(1);

            var mockLogger = new Mock<ILogger>();
            var mockTaskOne = new Mock<ITaskJob>();

            var manager = new TaskManager(mockIDProvider.Object, mockLogger.Object);
            // Act
            manager.Add(mockTaskOne.Object);

            //Assert
            mockTaskOne.Verify(x => (x.Id == 1));
        }

        [Test]
        public void TaskList_ShouldFillCorrectly_whenANewTaskIsAdde()
        {
            // Arrange
            var mockIDProvider = new Mock<IIdProvider>();
            var mockLogger = new Mock<ILogger>();
            var mockTaskOne = new Mock<ITaskJob>();
            var mockTaskTwo = new Mock<ITaskJob>();

            mockTaskOne.Setup(x => x.Description).Returns("Pesho");
            mockTaskTwo.Setup(x => x.Description).Returns("Ivan");
   

            var manager = new TaskManager(mockIDProvider.Object, mockLogger.Object);
            // Act
            manager.Add(mockTaskOne.Object);
            manager.Add(mockTaskTwo.Object);

            // Assert
            Assert.AreEqual(manager.Members().Count, 2);
        }
    }
}
