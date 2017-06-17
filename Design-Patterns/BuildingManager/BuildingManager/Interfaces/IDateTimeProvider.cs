namespace BuildingManager.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}