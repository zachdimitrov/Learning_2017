using ProjectManager.Framework.Core.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Framework.Core.Common.Providers.Validators;

namespace ProjectManager.Framework.Core.Commands.Decorators
{
    public class ValidatableCommand : ICommand
    {
        private readonly ICommand command;
        private readonly IParameterValidator validator;

        public ValidatableCommand(ICommand command, IParameterValidator validator)
        {
            this.command = command;
            this.validator = validator;
        }

        public int ParameterCount
        {
            get { return this.command.ParameterCount; }
        }

        public string Execute(IList<string> parameters)
        {
            validator.ValidateParameters(parameters, this.ParameterCount);
            return this.command.Execute(parameters);
        }
    }
}
