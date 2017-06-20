using System.Collections.Generic;

namespace ProjectManager.Framework.Core.Common.Providers.Validators
{
    public interface IParameterValidator
    {
        void ValidateParameters(IList<string> parameters, int count);
    }
}