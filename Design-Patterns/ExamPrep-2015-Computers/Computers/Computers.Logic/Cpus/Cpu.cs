namespace Computers.Logic.Cpus
{
    using System;
    using Motherboards;
    using MotherBoards;
    using VideoCards;

    public abstract class Cpu : IMotherboardComponent
    {
        private const string NumberTooLowMessage = "Number too low.";

        private const string NumberTooHighMessage = "Number too high.";

        private const string SquareNumberStringFormat = "Square of {0} is {1}.";

        private static readonly Random Random = new Random();

        private IMotherBoard motherBoard;

        internal Cpu(byte numberOfCores)
        {
            this.NumberOfCores = numberOfCores;
        }

        public byte NumberOfCores { get; set; }

        public void AttachTo(IMotherBoard motherBoard)
        {
            this.motherBoard = motherBoard;
        }

        public abstract void SquareIt();

        public void SquareNumber(int maxValue)
        {
            var data = this.motherBoard.LoadRamValue();
            if (data < 0)
            {
                this.motherBoard.DrawOnVideoCard(NumberTooLowMessage);
            }
            else if (data > maxValue)
            {
                this.motherBoard.DrawOnVideoCard(NumberTooHighMessage);
            }
            else
            {
                int value = data * data;

                this.motherBoard.DrawOnVideoCard(string.Format(SquareNumberStringFormat, data, value));
            }
        }

        internal void Rand(int a, int b)
        {
            int randomNumber = Random.Next(a, b + 1);

            this.motherBoard.SaveRamValue(randomNumber);
        }
    }
}