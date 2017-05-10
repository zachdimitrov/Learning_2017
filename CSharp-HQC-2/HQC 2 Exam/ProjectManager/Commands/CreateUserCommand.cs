using System.Collections.Generic;
using System.Linq;
using ProjectManager.Commands.Contracts;
using ProjectManager.Common.Exceptions;
using ProjectManager.Common.Factories;
using ProjectManager.Common.Providers;
using ProjectManager.Data;

namespace ProjectManager.Commands
{
    public class CreateUserCommand : ICommand
    {
        public string Execute(List<string> commandParameters)
        {
            var database = new Database();
            var modelsFactory = new ModelsFactory();

            if (commandParameters.Count != 3)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (commandParameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            if (database != null)
            {
                if (database
                        .Projects[int.Parse(commandParameters[0])]
                        .Users
                        .Any() &&
                    database
                        .Projects[int.Parse(commandParameters[0])]
                        .Users
                        .Any(x => x.Username == commandParameters[1]))
                {
                    throw new UserValidationException("A user with that username already exists!");
                }

                database
                    .Projects[int.Parse(commandParameters[0])]
                    .Users
                    .Add(modelsFactory.CreateUser(commandParameters[1], commandParameters[2]));
            }

            return "Successfully created a new user!";
        }
    }
}
