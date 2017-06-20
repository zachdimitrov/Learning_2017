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
    public sealed class CreateProjectCommand : Command, ICommand
    {
        private const int ParameterCountConstant = 4;
        private readonly IModelsFactory factory;
        private readonly IParameterValidator validator;
        private readonly IDatabase database;

        public CreateProjectCommand(IModelsFactory factory, IDatabase database, IParameterValidator validator)
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

            if (this.database.Projects.Any(x => x.Name == parameters[0]))
            {
                throw new UserValidationException("A project with that name already exists!");
            }

            var project = this.factory.CreateProject(parameters[0], parameters[1], parameters[2], parameters[3]);
            this.database.Projects.Add(project);

            return "Successfully created a new project!";

        }
    }
}
