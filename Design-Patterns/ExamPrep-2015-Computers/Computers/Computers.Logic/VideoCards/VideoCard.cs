namespace Computers.Logic.VideoCards
{
    using System;

    public abstract class VideoCard
    {
        public void Draw(string a)
        {
            ConsoleColor color = this.GetColor();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(a);
            Console.ResetColor();
        }

        protected abstract ConsoleColor GetColor();
    }
}
