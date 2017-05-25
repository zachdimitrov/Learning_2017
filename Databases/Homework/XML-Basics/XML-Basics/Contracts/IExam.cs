using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XML_Basics.Enumerations;

namespace XML_Basics.Contracts
{
    interface IExam
    {
        Course Name { get; set; }

        string Tutor { get; set; }

        float Score { get; set; }
    }
}
