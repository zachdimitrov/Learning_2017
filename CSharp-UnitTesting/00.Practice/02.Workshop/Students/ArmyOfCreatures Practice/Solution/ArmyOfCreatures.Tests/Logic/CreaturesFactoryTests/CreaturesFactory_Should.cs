using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Logic.Creatures;
using NUnit.Framework;
using System;

namespace ArmyOfCreatures.Tests.Logic.CreaturesFactoryTests
{
    [TestFixture]
    public class CreaturesFactory_Should
    {
        [TestCase("Angel")]
        [TestCase("Archangel")]
        [TestCase("ArchDevil")]
        [TestCase("Behemoth")]
        [TestCase("Devil")]
        public void ReturnValidCreature_WhenValidNameIsPassed(string name)
        {
            // Arrange
            var factory = new CreaturesFactory();

            // Act
            var creature = factory.CreateCreature(name);

            // Assert
            Assert.AreEqual(name, creature.GetType().Name);
        }

        [Test]
        public void ThrowArgumentException_WhenInvalidNameIsPassed()
        {
            // Arrange
            var factory = new CreaturesFactory();

            // Act
            var creature = 

            // Assert
            Assert.Throws<ArgumentException>(() => factory.CreateCreature("Gosho"));
        }
    }
}
