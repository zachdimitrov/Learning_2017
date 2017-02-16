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
    class Attack_Should
    {
        [Test]
        public void ShouldThrowArgumentException_WhenCreatureIdentifierIsNotValid()
        {
            // Arrange
            var factoryMock = new Mock<ICreaturesFactory>();
            var loggerMock = new Mock<ILogger>();

            var creature = new AngelMock();
            var battleManager = new BattleManager(factoryMock.Object, loggerMock.Object);

            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Pesho(1)");

            // Act & Assert
            Assert.Throws<ArgumentException>(() => battleManager.Attack(null, identifier));
        }

        [Test]
        public void ShouldThrowArgumentException_WhenCreatureIdentifier2IsValid()
        {
            // Arrange
            var factoryMock = new Mock<ICreaturesFactory>();
            var loggerMock = new Mock<ILogger>();

            var creature = new AngelMock();
            var battleManager = new BattleManager(factoryMock.Object, loggerMock.Object);

            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => battleManager.Attack(identifier, null));
        }
    }
}
