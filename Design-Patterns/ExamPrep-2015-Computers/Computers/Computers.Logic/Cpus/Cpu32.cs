namespace Computers.Logic.Cpus
{
    using Computers.Logic.VideoCards;

    public class Cpu32 : Cpu
    {
        public Cpu32(byte cores) : base(cores)
        {
        }

        public override void SquareIt()
        {
            this.SquareNumber(500);
        }
    }
}
