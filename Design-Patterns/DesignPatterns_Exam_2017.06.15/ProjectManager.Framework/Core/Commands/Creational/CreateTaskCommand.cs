using System.Collections.Generic;
using Bytes2you.Validation;
using ProjectManager.Framework.Core.Commands.Abstracts;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Common.Providers.Validators;
using ProjectManager.Framework.Data;
using ProjectManager.Framework.Data.Factories;

namespace ProjectManager.Framework.Core.Commands.Creational
{
    public sealed class CreateTaskCommand : Command, ICommand
    {
        private const int ParameterCountConstant = 4;
        private readonly IModelsFactory factory;
        private readonly IParameterValidator validator;
        private readonly IDatabase database;

        public CreateTaskCommand(IModelsFactory factory, IDatabase database, IParameterValidator validator)
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

            var ownerId = int.Parse(parameters[1]);
            var owner = project.Users[ownerId];

            var task = this.factory.CreateTask(owner, parameters[2], parameters[3]);
            project.Tasks.Add(task);

            return "Successfully created a new task!";
        }
    }
}
