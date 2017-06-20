using Bytes2you.Validation;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using ProjectManager.Framework.Core.Common.Providers;
using System;

namespace ProjectManager.Framework.Core
{
    public class Engine : IEngine
    {
        private readonly ILogger logger;
        private readonly IProcessor processor;
        private readonly IReader consoleReader;
        private readonly IWriter consoleWriter;

        public Engine(ILogger logger, IProcessor processor, IReader consoleReader, IWriter consoleWriter)
        {
            this.logger = logger;
            this.processor = processor;
            this.consoleReader = consoleReader;
            this.consoleWriter = consoleWriter;
        }

        public void Start()
        {
            for (;;)
            {
                var commandLine = consoleReader.ReadLine();

                if (commandLine.ToLower() == "exit")
                {
                    consoleWriter.WriteLine("Program terminated.");
                    break;
                }

                this.processor.ProcessCommand(commandLine);
            }
        }
    }
}
