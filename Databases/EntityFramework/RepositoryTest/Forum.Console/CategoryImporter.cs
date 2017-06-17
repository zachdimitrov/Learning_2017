using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.ConsoleApp
{
    public class CategoryImporter : IImporter
    {
        public string Message
        {
            get
            {
                return "Start Importing Categories";
            }
        }

        public int Order
        {
            get
            {
                return 1;
            }
        }

        public void Import()
        {
            Console.WriteLine("Importing Categories");
        }
    }
}
