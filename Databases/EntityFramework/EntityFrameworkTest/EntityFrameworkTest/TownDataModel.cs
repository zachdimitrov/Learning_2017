using System.Collections.Generic;

namespace EntityFrameworkTest
{
    internal class TownDataModel
    {
        public IEnumerable<string> Addresses { get; set; }

        public string Name { get; set; }
    }
}