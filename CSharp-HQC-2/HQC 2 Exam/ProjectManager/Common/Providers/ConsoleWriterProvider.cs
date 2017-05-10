using ProjectManager.Common.Providers.Contracts;
using System;

namespace ProjectManager.Common.Providers
{
    public class ConsoleWriterProvider : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
