using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.Core;
using Tasker.Core.Providers;
using Tasker.Modules;

namespace Tasker
{
    public class Startup
    {
        static void Main()
        {
            var idProvider = new IdProvider();
            var logger = new ConsoleLogger();
            var manager = new TaskManager(idProvider, logger);
            manager.Add(new TaskJob("Some task"));
            manager.Add(new TaskJob("Another task"));
            manager.Add(new TaskJob("Third task"));
            manager.Remove(2);
        }
    }
}
