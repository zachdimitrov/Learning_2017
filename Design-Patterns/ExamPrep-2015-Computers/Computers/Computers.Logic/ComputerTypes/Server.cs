namespace Computers.Logic.ComputerTypes
{
    using System.Collections.Generic;
    using Cpus;
    using HardDrives;
    using VideoCards;

    public class Server : Computer
    {
        internal Server(Cpu cpu, IRam ram, IEnumerable<HardDrive> hardDrives, MonochromeVideoCard videoCard) : base(cpu, ram, hardDrives, videoCard)
        {
        }

        public void Process(int data)
        {
            this.Ram.Value = data;
            this.Cpu.SquareIt();
        }
    }
}
