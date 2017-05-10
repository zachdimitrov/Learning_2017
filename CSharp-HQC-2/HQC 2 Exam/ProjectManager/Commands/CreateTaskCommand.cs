using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using System.Collections.Generic;
using System.Linq;
using ProjectManager.Commands.Contracts;
using ProjectManager.Common.Factories;

namespace ProjectManager.Commands
{
    public sealed class CreateTaskCommand : ICommand
    {
        public string Execute(List<string> commandParameters)
        {
            var dataBase = new Database();
            var modelsFactory = new ModelsFactory();
            var projects = dataBase.Projects[int.Parse(commandParameters[0])];
            var owner = projects.Users[int.Parse(commandParameters[1])];
            var task = modelsFactory.CreateTask(owner, commandParameters[2], commandParameters[3]);

            if (commandParameters.Count != 4)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (commandParameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }
            
            projects.Tasks.Add(task);

            return "Successfully created a new task!";
        }
    }
}
