namespace Computers.Logic.Manifacturers
{
    using System.Collections.Generic;
    using ComputerTypes;
    using Cpus;
    using HardDrives;
    using VideoCards;

    public class DellComputersFactory : IComputersFactory
    {
        public Laptop CreateLaptop()
        {
            var laptop = new Laptop(new Cpu32(4), new Ram(8), new[] { new SingleDrive(1000) }, new ColorVideoCard(), new LaptopBattery());
            return laptop;
        }

        public PersonalComputer CreatePersonalComputer()
        {
            var pc = new PersonalComputer(new Cpu64(4), new Ram(8), new[] { new SingleDrive(1000) }, new ColorVideoCard());
            return pc;
        }

        public Server CreateServer()
        {
            var server = new Server(new Cpu64(8), new Ram(64), new List<HardDrive> { new RaidArray(2, new List<HardDrive> { new SingleDrive(2000), new SingleDrive(2000) }) }, new MonochromeVideoCard());
            return server;
        }
    }
}
