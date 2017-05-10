using ProjectManager.Common.Providers.Contracts;
using System;

namespace ProjectManager.Common.Providers
{
    public class ConsoleReaderProvider : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
