using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XML_Basics.Enumerations;

namespace XML_Basics.Contracts
{
    interface IStudent
    {
        string Name { get; set; }

        Gender StudentGender { get; set; }

        DateTime BirthDate { get; set; }

        string Phone { get; set; }

        string Email { get; set; }

        Course Course { get; set; }

        Speciality Speciality { get; set; }

        int FacultyNumber { get; set; }

        IEnumerable<IExam> Exams { get; set; }
    }
}
