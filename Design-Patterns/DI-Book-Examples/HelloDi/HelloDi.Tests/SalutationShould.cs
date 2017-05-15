using Moq;
using NUnit.Framework;

namespace HelloDi.Tests
{
    [TestFixture]
    public class SalutationShould
    {
        [Test]
        public void ExclaimWillWriteCorrectMessageToMessageWriter()
        {
            var writerMock = new Mock<IMessageWriter>();
            var sut = new Salutation(writerMock.Object);
            sut.Exclaim();
            writerMock.Verify(w => w.Write("Hello DI!"));
        }
    }
}
