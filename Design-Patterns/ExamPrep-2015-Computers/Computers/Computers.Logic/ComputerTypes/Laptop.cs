namespace Computers.Logic.ComputerTypes
{
    using System.Collections.Generic;
    using Cpus;
    using HardDrives;
    using VideoCards;

    public class Laptop : Computer
    {
        private const string BatteryStatusStringFormat = "Battery status: ";
        private readonly ILaptopBattery battery;

        public Laptop(Cpu cpu, IRam ram, IEnumerable<HardDrive> hardDrives, VideoCard videoCard, ILaptopBattery battery) : base(cpu, ram, hardDrives, videoCard)
        {
            this.battery = battery;
        }

        public void ChargeBattery(int percentage)
        {
            this.battery.Charge(percentage);
            string percentageString = BatteryStatusStringFormat + this.battery.Percentage + "%";
            this.VideoCard.Draw(percentageString);
        }
    }
}
