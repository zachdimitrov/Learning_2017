using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Tests.Mocks;

namespace ArmyOfCreatures.Tests.Logic.BattleManagerTests
{
    [TestFixture]
    class AddCreatures_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenCreatureIdentifierIsNull()
        {
            // Arrange
            var factoryMock = new Mock<ICreaturesFactory>();
            var loggerMock = new Mock<ILogger>();

            var battleManager = new BattleManager(factoryMock.Object, loggerMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => battleManager.AddCreatures(null, 1));
        }

        [Test]
        public void CallCreateCreature_WhenCreatureIdentifierIsValid()
        {
            // Arrange
            var factoryMock = new Mock<ICreaturesFactory>();
            var loggerMock = new Mock<ILogger>();

            var creature = new AngelMock();

            factoryMock.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(creature);

            var battleManager = new BattleManager(factoryMock.Object, loggerMock.Object);
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            battleManager.AddCreatures(identifier, 1);

            // Act & Assert
            factoryMock.Verify(x => x.CreateCreature(It.IsAny<string>()), Times.Exactly(1));
        }
    }
}
