namespace Computers.Logic.Manifacturers
{
    using System.Collections.Generic;
    using ComputerTypes;
    using Cpus;
    using HardDrives;
    using VideoCards;

    public class LenovoComputersFactory : IComputersFactory
    {
        public Laptop CreateLaptop()
        {
            var ram = new Ram(16);
            var videoCard = new MonochromeVideoCard();
            var cpu = new Cpu64(2);
            var battery = new LaptopBattery();
            var hardDrives = new[] { new SingleDrive(100) };
            var laptop = new Laptop(cpu, ram, hardDrives, videoCard, battery);
            return laptop;
        }

        public PersonalComputer CreatePersonalComputer()
        {
            var ram = new Ram(4);
            var videoCard = new MonochromeVideoCard();
            var cpu = new Cpu64(2);
            var hardDrives = new[] { new SingleDrive(2000) };
            var pc = new PersonalComputer(cpu, ram, hardDrives, videoCard);
            return pc;
        }

        public Server CreateServer()
        {
            var ram = new Ram(8);
            var videCard = new MonochromeVideoCard();
            var cpu = new Cpu128(2);
            var hardDrives = new List<HardDrive> { new RaidArray(2, new List<HardDrive> { new SingleDrive(1000), new SingleDrive(1000) }) };
            var server = new Server(cpu, ram, hardDrives, videCard);
            return server;
        }
    }
}
