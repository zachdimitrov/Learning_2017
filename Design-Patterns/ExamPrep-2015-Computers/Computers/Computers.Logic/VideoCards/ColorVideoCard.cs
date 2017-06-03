namespace Computers.Logic.VideoCards
{
    using System;

    public class ColorVideoCard : VideoCard
    {
        protected override ConsoleColor GetColor()
        {
            return ConsoleColor.Green;
        }
    }
}
