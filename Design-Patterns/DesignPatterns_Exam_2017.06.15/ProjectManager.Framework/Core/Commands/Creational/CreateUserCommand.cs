using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using ProjectManager.Framework.Core.Commands.Abstracts;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using ProjectManager.Framework.Core.Common.Providers.Validators;
using ProjectManager.Framework.Data;
using ProjectManager.Framework.Data.Factories;

namespace ProjectManager.Framework.Core.Commands.Creational
{
    public sealed class CreateUserCommand : Command, ICommand
    {
        private const int ParameterCountConstant = 3;
        private readonly IModelsFactory factory;
        private readonly IParameterValidator validator;
        private readonly IDatabase database;

        public CreateUserCommand(IModelsFactory factory, IDatabase database, IParameterValidator validator)
        {
            Guard.WhenArgument(factory, "Models factory is missing!").IsNull().Throw();
            Guard.WhenArgument(validator, "Validator is missing!").IsNull().Throw();
            Guard.WhenArgument(database, "Database is missing!").IsNull().Throw();

            this.factory = factory;
            this.database = database;
            this.validator = validator;
        }

        public override int ParameterCount
        {
            get
            {
                return ParameterCountConstant;
            }
        }

        public override string Execute(IList<string> parameters)
        {
            validator.ValidateParameters(parameters, this.ParameterCount);

            var projectId = int.Parse(parameters[0]);
            var project = this.database.Projects[projectId];

            if (project.Users.Any() && project.Users.Any(x => x.Username == parameters[1]))
            {
                throw new UserValidationException("A user with that username already exists!");
            }

            var user = this.factory.CreateUser(parameters[1], parameters[2]);
            project.Users.Add(user);

            return "Successfully created a new user!";
        }
    }
}
