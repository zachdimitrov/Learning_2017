using System.Collections.Generic;
using Bytes2you.Validation;
using ProjectManager.Framework.Core.Commands.Abstracts;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using ProjectManager.Framework.Core.Common.Providers.Validators;
using ProjectManager.Framework.Data;

namespace ProjectManager.Framework.Core.Commands.Listing
{
    public sealed class ListProjectDetailsCommand : Command, ICommand
    {
        private const int ParameterCountConstant = 1;
        private readonly IParameterValidator validator;
        private readonly IDatabase database;

        public ListProjectDetailsCommand(IDatabase database, IParameterValidator validator)
        {
            Guard.WhenArgument(validator, "Validator is missing!").IsNull().Throw();
            Guard.WhenArgument(database, "Database is missing!").IsNull().Throw();

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
            if (this.database.Projects.Count <= projectId || projectId < 0)
            {
                throw new UserValidationException("The project is not present in the database");
            }

            var project = this.database.Projects[projectId];

            return project.ToString();
        }
    }
}
