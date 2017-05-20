using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Process
{
    public class Food
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return $@"----- Food -----
Id: {this.Id}
Name: {this.Name}
Description: {this.Description}
----- End -----
";
        }
    }
}
