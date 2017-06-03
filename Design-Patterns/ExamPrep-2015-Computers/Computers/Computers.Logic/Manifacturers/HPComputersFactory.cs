namespace Computers.Logic.Manifacturers
{
    using System.Collections.Generic;
    using ComputerTypes;
    using Cpus;
    using HardDrives;
    using VideoCards;

    public class HpComputersFactory : IComputersFactory
    {
        public Laptop CreateLaptop()
        {
            var laptop = new Laptop(new Cpu64(2), new Ram(4), new[] { new SingleDrive(500) }, new ColorVideoCard(), new LaptopBattery());
            return laptop;
        }

        public PersonalComputer CreatePersonalComputer()
        {
            var pc = new PersonalComputer(new Cpu32(2), new Ram(2), new[] { new SingleDrive(500) }, new ColorVideoCard());
            return pc;
        }

        public Server CreateServer()
        {
            var server = new Server(new Cpu32(4), new Ram(32), new List<HardDrive> { new RaidArray(2, new List<HardDrive> { new SingleDrive(1000), new SingleDrive(1000) }) }, new MonochromeVideoCard());
            return server;
        }
    }
}
