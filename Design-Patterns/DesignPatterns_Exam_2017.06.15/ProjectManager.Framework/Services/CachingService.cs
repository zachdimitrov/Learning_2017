using System;
using System.Collections.Generic;

using Bytes2you.Validation;
using ProjectManager.Framework.Core.Common.Contracts;

namespace ProjectManager.Framework.Services
{
    public class CachingService : ICachingService
    {
        private readonly TimeSpan duration;
        private DateTime timeExpiring;
        private IDateTimeProvider dateTime;
        private IDictionary<string, object> cache;

        public CachingService(TimeSpan duration, IDateTimeProvider dateTime)
        {
            Guard.WhenArgument(duration, "duration").IsLessThan(TimeSpan.Zero).Throw();
            Guard.WhenArgument(dateTime, "DateTime Provider").IsNull().Throw();

            this.dateTime = dateTime;

            this.duration = duration;
            this.timeExpiring = this.dateTime.Now;
            this.cache = new Dictionary<string, object>();
        }

        public void ResetCache()
        {
            this.cache = new Dictionary<string, object>();
            this.timeExpiring = this.dateTime.Now + this.duration;
        }

        public bool IsExpired
        {
            get
            {
                if (this.timeExpiring < this.dateTime.Now)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public object GetCacheValue(string className, string methodName)
        {
            return this.cache[$"{className}.{methodName}"];
        }

        public void AddCacheValue(string className, string methodName, object value)
        {
            this.cache.Add($"{className}.{methodName}", value);
        }
    }
}
