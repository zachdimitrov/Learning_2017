using ProjectManager.Common.Providers;
using ProjectManager.Common.Utilities;

namespace ProjectManager.Common
{
    using System;
    using Bytes2you.Validation;
    using Commands.Contracts;
    using Exceptions;
    using Providers.Contracts;

    public class Engine
    {
        private readonly IFileLogger logger;
        private readonly ICommandProcessor commandsProcessor;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IFileLogger logger, ICommandProcessor processor, IReader reader, IWriter writer)
        {
            // validate clauses
            Guard
                .WhenArgument(logger, "Engine Logger provider")
                .IsNull()
                .Throw();

            Guard
                .WhenArgument(processor, "Engine Processor provider")
                .IsNull()
                .Throw();

            Guard
                .WhenArgument(reader, "Engine Processor provider")
                .IsNull()
                .Throw();

            Guard
                .WhenArgument(writer, "Engine Processor provider")
                .IsNull()
                .Throw();

            this.logger = logger;
            this.commandsProcessor = processor;
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            while (true)
            {
                // read from console
                var input = this.reader.ReadLine();

                if (input.ToLower() == "exit")
                {
                    this.writer.WriteLine("Program terminated.");
                    break;
                }

                try
                {
                    var executionResult = this.commandsProcessor.Process(input);
                    this.writer.WriteLine(executionResult);
                }
                catch (UserValidationException ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine("Opps, something happened. :(");
                    this.logger.Error(ex.Message);
                }
            }
        }
    }
}
