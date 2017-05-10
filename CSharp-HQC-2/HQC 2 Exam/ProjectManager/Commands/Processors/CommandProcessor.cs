using System;
using System.Linq;
using ProjectManager.Commands.Contracts;
using ProjectManager.Common.Factories;

namespace ProjectManager.Commands.Processors
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly CommandsFactory commandsFactory;

        public CommandProcessor(CommandsFactory commandsFactory)
        {
            this.commandsFactory = commandsFactory;
        }
    
        public string Process(string commandsList)
        {
            if (string.IsNullOrWhiteSpace(commandsList))
            {
                throw new Common.Exceptions.UserValidationException("No command has been provided!");
            }

            var splitString = commandsList.Split(' ');
            if (splitString.Count() > 10)
            {
                throw new ArgumentException();
            }

            var commandName = this.commandsFactory.CreateCommandFromString(commandsList.Split(' ')[0]);
            return commandName.Execute(commandsList.Split(' ').Skip(1).ToList());
        }
    }
}
