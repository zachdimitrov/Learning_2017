using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XML_Basics.Contracts;
using XML_Basics.Enumerations;

namespace XML_Basics.Models
{
    public class Exam : IExam
    {
        public Course Name { get; set; }

        public string Tutor { get; set; }

        public float Score { get; set; }

        public Exam(Course name, string tutor, float score)
        {
            this.Name = name;
            this.Tutor = tutor;
            this.Score = score;
        }

        public override string ToString()
        {
            return $@"
----- Exam -----
Name: {this.Name}
Tutor: {this.Tutor}
Score: {this.Score:F2}
";
        }
    }
}
