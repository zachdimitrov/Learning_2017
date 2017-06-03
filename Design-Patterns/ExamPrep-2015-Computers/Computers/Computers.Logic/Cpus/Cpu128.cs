namespace Computers.Logic.Cpus
{
    using Computers.Logic.VideoCards;

    public class Cpu128 : Cpu
    {
        public Cpu128(byte cores) : base(cores)
        {
        }

        public override void SquareIt()
        {
            this.SquareNumber(2000);
        }
    }
}
