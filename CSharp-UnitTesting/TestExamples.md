### Simple Test
```c#
// Constructor Should...
[Test]
        public void ReturnNewProcyon_WhenValidCommandIsPassed()
        {
            // Arrange
            var command = "create unit Procyon Gosho 1";
            var unitsFactory = new IntergalacticTravel.UnitsFactory();

            // Act
            var actualUnit = unitsFactory.GetUnit(command);

            // Assert
            Assert.IsInstanceOf<Procyon>(actualUnit);
        }
```

### With Testcases
```c#
        [TestCase("create resources x y z")]
        [TestCase("tansta resources a b")]
        [TestCase("absolutelyRandomStringThatMustNotBeAValidCommand")]
        public void ThrowInvalidOperationExceptionWhichContainsTheStringCommand_WhenTheInputStringRepresentsInvalidCommand(string invalidCommand)
        {
            // Arrange
            var resourcesFactory = new IntergalacticTravel.ResourcesFactory();
            var expectedExceptionMessage = "command";

            // Act & Assert
            var exc = Assert.Throws<InvalidOperationException>(
                () => resourcesFactory.GetResources(invalidCommand));
            var actualExceptionMessage = exc.Message;

            // Assert
            StringAssert.Contains(expectedExceptionMessage, actualExceptionMessage);
        }
```

### Multiple Asserts
```c#
[Test]
        public void SetupAllOfTheProvidedFields_WhenValidParametersArePased()
        {
            // Arrange
            var locationMock = new Mock<ILocation>();
            var ownerMock = new Mock<IBusinessOwner>();
            var mapMock = new Mock<IEnumerable<IPath>>();
            var expectedMap = mapMock.Object;
            var expectedOwner = ownerMock.Object;
            var expectedLocation = locationMock.Object;

            // Act
            var teleportStation = new ExtendedTeleportStation(expectedOwner, expectedMap, expectedLocation);
            var actualOwner = teleportStation.Owner;
            var actualMap = teleportStation.GalacticMap;
            var actualLocation = teleportStation.Location;

            // Assert
            Assert.AreSame(expectedOwner, actualOwner);
            Assert.AreSame(expectedLocation, actualLocation);
            Assert.AreSame(expectedMap, actualMap);
        }
```

### Check Exception
```c#
 [Test]
        public void ThrowArgumentNullException_WhenTheParameterUnitToTeleportIsNull()
        {
            // Arrange
            var teleportStationLocationMock = new Mock<ILocation>();
            var teleportStationOwnerMock = new Mock<IBusinessOwner>();
            var teleportStationMapMock = new Mock<IEnumerable<IPath>>();
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleport = (IUnit)null;
            var teleportStation = new ExtendedTeleportStation(teleportStationOwnerMock.Object, teleportStationMapMock.Object, teleportStationLocationMock.Object);
            var expectedExceptionMessage = "unitToTeleport";

            // Act & Assert
            var exc = Assert.Throws<ArgumentNullException>(
                () => teleportStation.TeleportUnit(unitToTeleport, targetLocationMock.Object));
            var actualExceptionMessage = exc.Message;

            // Assert
            StringAssert.Contains(expectedExceptionMessage, actualExceptionMessage);
        }
```

### Mocking Usage
```c#
[Test]
        public void DecreaseTheOwnerResourcesByTheAmountOfTheCost_WhenTheCostObjectIsNotNull()
        {
            // Arrange
            var unitId = 4124;
            var unitName = "Mecho";
            var unit = new IntergalacticTravel.Unit(unitId, unitName);

            var costMock = new Mock<IResources>();
            costMock.Setup(x => x.BronzeCoins).Returns(10);
            costMock.Setup(x => x.SilverCoins).Returns(20);
            costMock.Setup(x => x.GoldCoins).Returns(30);

            unit.Resources.Add(costMock.Object);
            unit.Resources.Add(costMock.Object);

            var expectedBronzeCoins = unit.Resources.BronzeCoins - costMock.Object.BronzeCoins;
            var expectedSilverCoins = unit.Resources.SilverCoins - costMock.Object.SilverCoins;
            var expectedGoldCoins = unit.Resources.GoldCoins - costMock.Object.GoldCoins;

            // Act
            unit.Pay(costMock.Object);
            var actualBronzeCoins = unit.Resources.BronzeCoins;
            var actualSilverCoins = unit.Resources.SilverCoins;
            var actualGoldCoins = unit.Resources.GoldCoins;

            // Assert
            Assert.AreEqual(expectedBronzeCoins, actualBronzeCoins);
            Assert.AreEqual(expectedSilverCoins, actualSilverCoins);
            Assert.AreEqual(expectedGoldCoins, actualGoldCoins);
        }
```

### Mocking Very Very Heavy Usage
```c#
[Test]
        public void ReturnTheTotalAmountOfProfitsGeneratedUsingTheTeleportUnitService_WhenTheArgumentPassedRepresentsTheActualOwnerOfTheTeleportStation()
        {
            // Arrange
            var planetName = "P1";
            var galaxyName = "G1";
            var longtitude = 45d;
            var latitude = 45d;
            var teleportStationLocationMock = new Mock<ILocation>();
            var teleportStationOwnerMock = new Mock<IBusinessOwner>();
            teleportStationOwnerMock.Setup(x => x.IdentificationNumber).Returns(12412);
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();

            var planetaryUnitMock = new Mock<IUnit>();
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude + 15d);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude + 15d);

            var targetLocationPlanetaryUnitsCollectionEnumeratorMock = new Mock<IEnumerator<IUnit>>();
            targetLocationPlanetaryUnitsCollectionEnumeratorMock
                .Setup(x => x.Current)
                .Returns(planetaryUnitMock.Object)
                .Callback(
                    () =>
                        targetLocationPlanetaryUnitsCollectionEnumeratorMock
                        .Setup(x => x.Current)
                        .Returns((IUnit)null));

            var targetLocationPlanetaryUnitsCollectionMock = new Mock<IList<IUnit>>();
            targetLocationPlanetaryUnitsCollectionMock.Setup(x => x.GetEnumerator()).Returns(targetLocationPlanetaryUnitsCollectionEnumeratorMock.Object);

            var pathMock = new Mock<IPath>();
            pathMock.Setup(x => x.Cost.BronzeCoins).Returns(10);
            pathMock.Setup(x => x.Cost.SilverCoins).Returns(10);
            pathMock.Setup(x => x.Cost.GoldCoins).Returns(10);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns(planetName);
            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns(galaxyName);
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(targetLocationPlanetaryUnitsCollectionMock.Object);

            var currentUnitLocationPlanetaryUnitsCollectionEnumeratorMock = new Mock<IEnumerator<IUnit>>();
            currentUnitLocationPlanetaryUnitsCollectionEnumeratorMock
                .Setup(x => x.Current)
                .Returns(unitToTeleportMock.Object)
                .Callback(
                    () =>
                        currentUnitLocationPlanetaryUnitsCollectionEnumeratorMock
                        .Setup(x => x.Current)
                        .Returns((IUnit)null));

            var currentUnitLocationPlanetaryUnitsCollectionMock = new Mock<IList<IUnit>>();
            currentUnitLocationPlanetaryUnitsCollectionMock.Setup(x => x.GetEnumerator()).Returns(currentUnitLocationPlanetaryUnitsCollectionEnumeratorMock.Object);

            var teleportStationMapMock = new List<IPath> { pathMock.Object };
            var teleportStation = new ExtendedTeleportStation(teleportStationOwnerMock.Object, teleportStationMapMock, teleportStationLocationMock.Object);
            var initialTeleportStationResources = teleportStation.Resources.Clone();

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);
            unitToTeleportMock.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(x => x.Pay(pathMock.Object.Cost)).Returns(pathMock.Object.Cost);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Units).Returns(currentUnitLocationPlanetaryUnitsCollectionMock.Object);

            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);
            targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);

            teleportStationLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            teleportStationLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);

            var expectedResourcesAmount = new Mock<IResources>();
            expectedResourcesAmount.Setup(x => x.BronzeCoins).Returns(500);
            expectedResourcesAmount.Setup(x => x.SilverCoins).Returns(400);
            expectedResourcesAmount.Setup(x => x.GoldCoins).Returns(300);
            teleportStation.Resources.Add(expectedResourcesAmount.Object);
            
            // Act
            var actualResourcesAmount = teleportStation.PayProfits(teleportStationOwnerMock.Object);

            // Assert
            Assert.AreEqual(expectedResourcesAmount.Object.BronzeCoins, actualResourcesAmount.BronzeCoins);
            Assert.AreEqual(expectedResourcesAmount.Object.SilverCoins, actualResourcesAmount.SilverCoins);
            Assert.AreEqual(expectedResourcesAmount.Object.GoldCoins, actualResourcesAmount.GoldCoins);
        }
```