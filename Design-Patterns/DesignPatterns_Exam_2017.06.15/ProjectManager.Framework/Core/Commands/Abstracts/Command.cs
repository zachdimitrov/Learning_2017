using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using ProjectManager.Framework.Data;
using ProjectManager.Data;

namespace ProjectManager.Framework.Core.Commands.Abstracts
{
    public abstract class Command : ICommand
    {
        public abstract int ParameterCount
        {
            get;
        }

        public abstract string Execute(IList<string> parameters);
    }
}
