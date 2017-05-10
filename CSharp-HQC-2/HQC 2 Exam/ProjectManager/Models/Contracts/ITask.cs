using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Models.Contracts
{
    public interface ITask
    {
        string Name { get; set; }

        IUser Owner { get; set; }

        string State { get; set; }
    }
}
