namespace Computers.Logic.MotherBoards
{
    using System;
    using Cpus;
    using VideoCards;

    public class MotherBoard : IMotherBoard
    {
        public MotherBoard(Cpu cpu, IRam ram, VideoCard videocard)
        {
            cpu.AttachTo(this);
            this.VideoCard = videocard;
            this.Ramm = ram;
        }

        public IRam Ramm { get; set; }

        public VideoCard VideoCard { get; set; }

        public void DrawOnVideoCard(string data)
        {
            this.VideoCard.Draw(data);
        }

        public int LoadRamValue()
        {
            return this.Ramm.Value;
        }

        public void SaveRamValue(int value)
        {
            this.Ramm.Value = value;
        }
    }
}
