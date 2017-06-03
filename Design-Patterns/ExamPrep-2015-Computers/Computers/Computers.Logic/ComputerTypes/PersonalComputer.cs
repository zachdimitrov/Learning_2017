namespace Computers.Logic.ComputerTypes
{
    using System.Collections.Generic;
    using Cpus;
    using HardDrives;
    using VideoCards;

    public class PersonalComputer : Computer
    {
        private const string WInMessage = "You win!";

        private const string WrongNumberString = "You didn't guess the number ";

        internal PersonalComputer(Cpu cpu, IRam ram, IEnumerable<HardDrive> hardDrives, VideoCard videoCard) : base(cpu, ram, hardDrives, videoCard)
        {
        }

        public void Play(int guessNumber)
        {
            this.Cpu.Rand(1, 10);
            var number = this.Ram.Value;

            if (number + 1 != guessNumber + 1)
            {
                string guessNumberString = WrongNumberString + number;
                this.VideoCard.Draw(guessNumberString);
            }
            else
            {
                this.VideoCard.Draw(WInMessage);
            }
        }
    }
}
