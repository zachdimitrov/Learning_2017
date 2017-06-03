namespace Computers.Tests.LaptopBatteryTests
{
    using Computers.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ChargeShould
    {
        [TestMethod]
        public void AddToPercentageWhenGivenPositivePower()
        {
            var battery = new LaptopBattery();
            battery.Percentage = 50;
            battery.Charge(10);
            Assert.AreEqual(60, battery.Percentage);
        }

        [TestMethod]
        public void SubstractWhenNegativePower()
        {
            var battery = new LaptopBattery();
            battery.Percentage = 50;
            battery.Charge(-10);
            Assert.AreEqual(40, battery.Percentage);
        }

        [TestMethod]
        public void NotSubstractWhenZeroPercentageIsGiven()
        {
            var battery = new LaptopBattery();
            battery.Percentage = 0;
            battery.Charge(-10);
            Assert.AreEqual(0, battery.Percentage);
        }

        [TestMethod]
        public void NootGoOver100Percent()
        {
            var battery = new LaptopBattery();
            battery.Percentage = 100;
            battery.Charge(10);
            Assert.AreEqual(100, battery.Percentage);
        }

        [TestMethod]
        public void NotChangeWhenGivenZero()
        {
            var battery = new LaptopBattery();
            battery.Percentage = 50;
            battery.Charge(0);
            Assert.AreEqual(50, battery.Percentage);
        }
    }
}
