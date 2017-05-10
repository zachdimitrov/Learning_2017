using ProjectManager.Commands.Processors;
using ProjectManager.Common;
using ProjectManager.Common.Factories;
using ProjectManager.Common.Providers;
using ProjectManager.Common.Utilities;
using ProjectManager.Data;

namespace ProjectManager
{
    public class Startup
    {
        public static void Main()
        {
            var fileLogger = new FileLogger();
            var dataBase = new Database();
            var modelsFactory = new ModelsFactory();
            var commandFactory = new CommandsFactory(dataBase, modelsFactory);
            var reader = new ConsoleReaderProvider();
            var writer = new ConsoleWriterProvider();
            var commandProcessor = new CommandProcessor(commandFactory);
            var engine = new Engine(fileLogger, commandProcessor, reader, writer);
            var provider = new EngineProvider(engine);
            provider.Startup();
        }
    }
}
