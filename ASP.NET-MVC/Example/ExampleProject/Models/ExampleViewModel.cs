using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleProject.Models
{
    public class ExampleViewModel
    {
        public ExampleViewModel(string name, ICollection<string> friends)
        {
            this.Name = name;
            this.Friends = new List<string>(friends);
        }

        public string Name { get; set; }
        public ICollection<string> Friends { get; set; }
    }
}