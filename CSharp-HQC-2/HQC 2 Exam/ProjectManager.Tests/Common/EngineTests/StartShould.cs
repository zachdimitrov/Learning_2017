using Moq;
using NUnit.Framework;
using ProjectManager.Commands.Contracts;
using ProjectManager.Common;
using ProjectManager.Common.Providers.Contracts;
using System;

namespace ProjectManager.Tests.Common.EngineTests
{
    [TestFixture]
    public class StartShould
    {
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenReaderIsNotPassed()
        {
            var writer = new Mock<IWriter>();
            var logger = new Mock<IFileLogger>();
            var processor = new Mock<ICommandProcessor>();
            Assert.Throws<ArgumentNullException>(() => new Engine(logger.Object, processor.Object, null, writer.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenWriterIsNotPassed()
        {
            var reader = new Mock<IReader>();
            var logger = new Mock<IFileLogger>();
            var processor = new Mock<ICommandProcessor>();
            Assert.Throws<ArgumentNullException>(() => new Engine(logger.Object, processor.Object, reader.Object, null));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenFileLoggerIsNotPassed()
        {
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();
            var processor = new Mock<ICommandProcessor>();
            Assert.Throws<ArgumentNullException>(() => new Engine(null, processor.Object, reader.Object, writer.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenICommandProcessorIsNotPassed()
        {
            var reader = new Mock<IReader>();
            var writer = new Mock<IWriter>();
            var logger = new Mock<IFileLogger>();
            Assert.Throws<ArgumentNullException>(() => new Engine(logger.Object, null, reader.Object, writer.Object));
        }

        [Test]
        public void ReadSomethingFromTheConsole()
        {
            // Arrange
            var reader = new Mock<IReader>();
            reader.Setup(c => c.ReadLine()).Returns("CreateProject DeathStar 2016 - 1 - 1 2018 - 05 - 04 Active");
            reader.Setup(c => c.ReadLine()).Returns("Exit");
            var writer = new Mock<IWriter>();
            var logger = new Mock<IFileLogger>();
            var processor = new Mock<ICommandProcessor>();
            var engine = new Engine(logger.Object, processor.Object, reader.Object, writer.Object);

            // Act and Assert
            Assert.DoesNotThrow(() => engine.Start());
        }

        [Test]
        public void WritesSomethingWhenPassedExitCommand()
        {
            // Arrange
            var reader = new Mock<IReader>();
            reader.Setup(c => c.ReadLine()).Returns("Exit");
            var writer = new Mock<IWriter>();
            var logger = new Mock<IFileLogger>();
            var processor = new Mock<ICommandProcessor>();
            var engine = new Engine(logger.Object, processor.Object, reader.Object, writer.Object);

            // Act 
            engine.Start();

            // Assert
            writer.Verify(c => c.WriteLine(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void WritesErrorMessageWhenUserValidationErrorOccurs()
        {
            // Arrange
            var reader = new Mock<IReader>();
            reader.Setup(c => c.ReadLine()).Returns("CreateUser 0 sexybeast@darkside.com"); // missing parameter
            reader.Setup(c => c.ReadLine()).Returns("Exit");
            var writer = new Mock<IWriter>();
            var logger = new Mock<IFileLogger>();
            var processor = new Mock<ICommandProcessor>();
            var engine = new Engine(logger.Object, processor.Object, reader.Object, writer.Object);

            // Act 
            engine.Start();

            // Assert
            writer.Verify(c => c.WriteLine(It.IsAny<string>()), Times.AtLeast(1));
        }

        [Test, Timeout(1000)]
        public void LogsExceptionMessageWhenErrorOccurs()
        {
            // Arrange
            var reader = new Mock<IReader>();
            reader.Setup(c => c.ReadLine()).Returns("Test"); // Wrong Command
            //reader.Setup(c => c.ReadLine()).Returns("Exit");
            var writer = new Mock<IWriter>();
            var logger = new Mock<IFileLogger>();
            var processor = new Mock<ICommandProcessor>();
            processor.Setup(c => c.Process(It.IsAny<string>())).Throws<Exception>();
            var engine = new Engine(logger.Object, processor.Object, reader.Object, writer.Object);

            // Act 
            engine.Start();

            // Assert
            logger.Verify(l => l.Error(It.IsAny<object>()));
        }

        [Test, Timeout(1000)]
        public void WritesWritesAStringThatContainsSomethingHappenedWhenGenericErrorOccurs()
        {
            // Arrange
            var reader = new Mock<IReader>();
            reader.Setup(c => c.ReadLine()).Returns(string.Empty); // missing parameters
            //reader.Setup(c => c.ReadLine()).Returns("Exit");
            var writer = new Mock<IWriter>();
            var logger = new Mock<IFileLogger>();
            var processor = new Mock<ICommandProcessor>();
            processor.Setup(c => c.Process(It.IsAny<string>())).Throws<Exception>();
            var engine = new Engine(logger.Object, processor.Object, reader.Object, writer.Object);

            // Act 
            engine.Start();

            // Assert
            writer.Verify(c => c.WriteLine(It.IsAny<string>()), Times.AtLeast(1));
        }
    }
}
