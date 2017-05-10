using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using ProjectManager.Commands.Contracts;
using ProjectManager.Common.Exceptions;
using ProjectManager.Common.Factories;
using ProjectManager.Data;

namespace ProjectManager.Commands
{
    public class CreateProjectCommand : ICommand
    {
        private readonly Database database;
        private readonly ModelsFactory modelsFactory;

        public CreateProjectCommand(Database database, ModelsFactory factory)
        {
            Guard
                .WhenArgument(database, "CreateProjectCommand Database")
                .IsNull()
                .Throw();

            Guard
                .WhenArgument(factory, "CreateProjectCommand ModelsFactory")
                .IsNull()
                .Throw();

            this.database = database;
            this.modelsFactory = factory;
        }

        public string Execute(List<string> commandParameters)
        {
            if (commandParameters.Count != 4)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (commandParameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            if (this.database.Projects.Any(x => x.Name == commandParameters[0]))
            {
                throw new UserValidationException("A project with that name already exists!");
            }

            var project = this.modelsFactory.CreateProject(commandParameters[0], commandParameters[1], commandParameters[2], commandParameters[3]);
            this.database.Projects.Add(project);

            return "Successfully created a new project!";
        }
    }
}
