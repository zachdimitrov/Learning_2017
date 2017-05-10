using System;
using System.Collections.Generic;

namespace ProjectManager.Models.Contracts
{
    public interface IProject
    {
        string Name { get; set; }

        DateTime StartingDate { get; set; }

        DateTime EndingDate { get; set; }

        string State { get; set; }

        List<IUser> Users { get; set; }

        List<ITask> Tasks { get; set; }
    }
}
