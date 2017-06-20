using System;
using System.Collections.Generic;
using Bytes2you.Validation;
using ProjectManager.Framework.Core.Commands.Abstracts;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Common.Providers.Validators;
using ProjectManager.Framework.Data;

namespace ProjectManager.Framework.Core.Commands.Listing
{
    public class ListProjectsCommand : Command, ICommand
    {
        private const int ParameterCountConstant = 0;

        private readonly IParameterValidator validator;
        private readonly IDatabase database;

        public ListProjectsCommand(IDatabase database, IParameterValidator validator)
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

            var projects = this.database.Projects;

            if(projects.Count == 0)
            {
                return "No projects in the database!";
            }

            return string.Join(Environment.NewLine, projects);
        }
    }
}
