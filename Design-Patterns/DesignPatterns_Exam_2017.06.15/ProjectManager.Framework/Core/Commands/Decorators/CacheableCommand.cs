using ProjectManager.Framework.Core.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytes2you.Validation;
using ProjectManager.Framework.Core.Common.Providers.Validators;
using ProjectManager.Framework.Services;

namespace ProjectManager.Framework.Core.Commands.Decorators
{
    public class CacheableCommand : ICommand
    {
        private readonly ICommand command;
        private readonly ICachingService cashingService;
        private readonly IParameterValidator validator;

        public CacheableCommand(ICommand command, ICachingService cashingService, IParameterValidator validator)
        {
            Guard.WhenArgument(command, "Models factory is missing!").IsNull().Throw();
            Guard.WhenArgument(validator, "Validator is missing!").IsNull().Throw();
            Guard.WhenArgument(cashingService, "Database is missing!").IsNull().Throw();

            this.command = command;
            this.cashingService = cashingService;
            this.validator = validator;
        }

        public int ParameterCount
        {
            get
            {
                return command.ParameterCount;
            }
        }

        public string Execute(IList<string> parameters)
        {
            validator.ValidateParameters(parameters, this.ParameterCount);
            var value = this.command.Execute(parameters);
            cashingService.AddCacheValue(this.command.GetType().ToString(), "Execute", value);
            return cashingService.GetCacheValue(this.command.GetType().ToString(), "Execute").ToString();
        }
    }
}
