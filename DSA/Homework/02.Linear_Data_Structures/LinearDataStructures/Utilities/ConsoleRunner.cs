using System;

namespace LinearDataStructures.Utilities
{
    /// <summary>
    /// Global class - pretifys the console
    /// </summary>
    public class ConsoleRunner
    {
        private int x;
        private int h;
        private int y;

        public ConsoleRunner(string title, string header, string errorMessage)
        {
            Console.Clear();
            this.x = 2;
            this.h = 4;
            this.y = h;
            this.Header = header;
            this.Title = title;
            this.ErrorMessage = errorMessage;
        }

        public string Header { get; set; }
        public string Title { get; set; }
        public string ErrorMessage { get; set; }

        public void AddTitle()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(Title);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(Header);
        }

        public void GetErrorMessage()
        {
            y--;
            Console.SetCursorPosition(x, h - 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(ErrorMessage);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public string GetInput(int count)
        {
            string input = "";
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(x, y);
            Console.Write((count + 1) + " - ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(new string(' ', Console.WindowWidth - 6));
            Console.SetCursorPosition(x + (count + 1).ToString().Length + 3, y);
            input = Console.ReadLine();
            y++;
            Console.SetCursorPosition(x, h - 1);
            Console.Write(new string(' ', ErrorMessage.Length));
            return input;
        }

        public void PrintResult(string result)
        {
            y--;
            Console.SetCursorPosition(x, y);

            if (result != null && result.Trim() != "")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Result");
                Console.SetCursorPosition(x, y + 1);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("No input! Terminated!");
            }

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write("  Next?  ");
            Console.ReadKey(true);
        }
    }
}
