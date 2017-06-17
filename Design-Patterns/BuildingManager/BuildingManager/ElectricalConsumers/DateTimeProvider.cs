using BuildingManager.Interfaces;
using System;

namespace BuildingManager.ElectricalConsumers
{
    class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow
        {
            get
            {
                return DateTime.UtcNow;
            }
        }
    }
}
