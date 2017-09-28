using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Services
{
    public class ExampleService : IExampleService
    {
        public string GetName()
        {
            return "Pesho";
        }

        public ICollection<string> GetFriends()
        {
            return new List<string>()
            {
                "Ivan",
                "Stoyan",
                "Gosho",
                "Mariika"
            };
        }
    }
}
