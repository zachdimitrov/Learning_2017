namespace Computers.Logic.Cpus
{
    using Computers.Logic.VideoCards;

    public class Cpu64 : Cpu
    {
        public Cpu64(byte cores) : base(cores)
        {
        }

        public override void SquareIt()
        {
            this.SquareNumber(1000);
        }
    }
}
