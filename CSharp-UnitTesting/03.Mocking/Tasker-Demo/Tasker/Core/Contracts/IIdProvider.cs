namespace Tasker.Core.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IIdProvider
    {
        int NextId();
    }
}