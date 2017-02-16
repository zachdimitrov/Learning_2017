using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.Core.Contracts;
using Tasker.Core.Providers;
using Tasker.Modules;

namespace Tasker.Core
{
    public class TaskManager : ITaskManager
    {
        private ICollection<ITaskJob> tasks;

        private readonly IIdProvider idProvider;
        private readonly ILogger logger;

        public TaskManager(IIdProvider idProvider, ILogger logger)
        {
            this.tasks = new List<ITaskJob>();
            this.idProvider = idProvider;
            this.logger = logger;
        }

        public IList<ITaskJob> Members()
        {
            return new List<ITaskJob>(this.tasks);
        }

        public void Add(ITaskJob task)
        {
            if (task == null)
            {
                throw new ArgumentNullException("Task cannot be null!");
            }

            task.Id = this.idProvider.NextId();

            this.tasks.Add(task);
            this.logger.Log($"A new task [{task.Description}] was added!");
        }

        public void Remove(int id)
        {
            var task = this.tasks.SingleOrDefault(x => x.Id == id);
            if (task == null)
            {
                this.logger.Log($"Task with ID {id} was not found!");
            }
            else
            {
                this.tasks.Remove(task);
            }
            this.logger.Log($"The task with ID {id} called [{task.Description}] was removed!");
        }
    }
}
