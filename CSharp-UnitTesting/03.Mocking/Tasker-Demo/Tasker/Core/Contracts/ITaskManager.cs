namespace Tasker.Core.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface ITaskManager
    {
        void Add(ITaskJob task);

        void Remove(int id);
    }
}