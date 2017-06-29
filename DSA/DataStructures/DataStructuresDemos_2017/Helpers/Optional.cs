using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpers
{
    public class Optional<T>
    {
        class Box
        {
            public T Value { get; set; }
        }

        private Box box;

        public Optional()
        {
            box = null;
        }

        public Optional(T value)
        {
            box = new Box();
            box.Value = value;
        }

        public bool HasValue => box != null;

        public void WithValue(Action<T> func)
        {
            if(HasValue)
            {
                func(box.Value);
            }
        }

        public Optional<R> WithValue<R>(Func<T, R> func)
        {
            if(HasValue)
            {
                return new Optional<T>(func(box.Value));
            }
            else
            {
                return new Optional<R>();
            }
        }
    }
}
