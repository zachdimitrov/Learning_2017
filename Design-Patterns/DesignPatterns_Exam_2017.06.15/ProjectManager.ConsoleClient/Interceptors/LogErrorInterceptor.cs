using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytes2you.Validation;
using Ninject.Extensions.Interception;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;

namespace ProjectManager.ConsoleClient.Interceptors
{
    public class LogErrorInterceptor : IInterceptor
    {
        private readonly ILogger logger;
        private readonly IWriter consoleWriter;

        public LogErrorInterceptor(ILogger logger, IWriter consoleWriter)
        {
            Guard.WhenArgument(logger, "Logger").IsNull().Throw();
            Guard.WhenArgument(consoleWriter, "ConsoleWriter").IsNull().Throw();

            this.logger = logger;
            this.consoleWriter = consoleWriter;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
                var executionResult = invocation.ReturnValue;
                consoleWriter.WriteLine(executionResult);
            }
            catch (UserValidationException ex)
            {
                this.logger.Error(ex.Message);
                consoleWriter.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                consoleWriter.WriteLine("Opps, something happened. Check the log file :(");
                this.logger.Error(ex.Message);
            }
        }
    }
}
