namespace Tasker.Core.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface ITaskJob
    {
        int Id { get; set; }

        string Description { get; set; }

        bool IsDone { get; set; }

        DateTime? DueDate { get; set; }
    }
}