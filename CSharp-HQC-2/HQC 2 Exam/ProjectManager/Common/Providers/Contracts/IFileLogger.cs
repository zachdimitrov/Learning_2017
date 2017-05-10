using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Common.Providers.Contracts
{
    public interface IFileLogger
    {
        void Info(object msg);

        void Error(object msg);

        void Fatal(object msg);
    }
}
