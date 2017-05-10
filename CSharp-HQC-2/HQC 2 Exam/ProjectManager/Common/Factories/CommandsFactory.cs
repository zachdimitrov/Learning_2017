using ProjectManager.Commands;
using ProjectManager.Commands.Contracts;
using ProjectManager.Common.Contracts;
using ProjectManager.Common.Exceptions;
using ProjectManager.Common.Providers;
using ProjectManager.Data;

namespace ProjectManager.Common.Factories
{
    public class CommandsFactory : ICommandsFactory
    {
        private readonly Database dataBase;
        private readonly ModelsFactory modelsFactory;

        public CommandsFactory(Database dataBase, ModelsFactory modelsFactory)
        {
            this.dataBase = dataBase;
            this.modelsFactory = modelsFactory;
        }

        public ICommand CreateCommandFromString(string commandName)
        {
            var outputCommand = this.BuildCommand(commandName);
            switch (outputCommand)
            {
                case "createproject": return new CreateProjectCommand(this.dataBase, this.modelsFactory);
                case "createtask": return new CreateTaskCommand();
                case "createuser": return new CreateUserCommand();
                case "listprojects": return new ListProjectsCommand(this.dataBase);
                default: throw new UserValidationException("The passed command is not valid!");
            }
        }

        private string BuildCommand(string inputCommand)
        {
            var lowercaseCommand = string.Empty;

            foreach (char c in inputCommand)
            {
                lowercaseCommand += c.ToString().ToLower();
            }

            return lowercaseCommand;
        }
    }
}