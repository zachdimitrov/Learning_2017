using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.Core.Contracts;

namespace Tasker.Modules
{
    public class TaskJob : ITaskJob
    {
        public int Id { get; set; }
        public TaskJob(string description)
        {
            this.Description = description;
            this.IsDone = false;
        }

        public string Description { get; set; }

        public bool IsDone { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
