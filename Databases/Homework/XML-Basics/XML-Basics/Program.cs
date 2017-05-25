using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Xsl;
using XML_Basics.Contracts;
using XML_Basics.Enumerations;
using XML_Basics.Models;

namespace XML_Basics
{
    class Program
    {
        private static string xmlResultPath = "../../data/students.xml";

        static void Main()
        {
            var examMath1 = new Exam(Course.Math, "Gosho", 5.50f);
            var examEnglish1 = new Exam(Course.English, "Pesho", 4.50f);
            var examPhysics1 = new Exam(Course.Physics, "Mitko", 4.30f);

            var examMath2 = new Exam(Course.Sport, "Baba", 3.75f);
            var examEnglish2 = new Exam(Course.Music, "Jojo", 3.50f);
            var examPhysics2 = new Exam(Course.Literature, "Lelka", 5.30f);

            var student1 = new Student("Zahari", Gender.Male, new DateTime(1982, 03, 22), "0884555366", "zahari@abv.bg", Course.Math, Speciality.Architecture, 4433, new List<IExam>() { examPhysics1, examEnglish1, examMath1 });

            var student2 = new Student("Tsonko", Gender.Male, new DateTime(1985, 04, 21), "0874553345", "tsonko@abv.bg", Course.Math, Speciality.Architecture, 4433, new List<IExam>() { examPhysics2, examEnglish2, examMath2 });

            Console.WriteLine(student1);
            Console.WriteLine(student2);

            var students = new Student[] { student1, student2 };

            // create XML

            var doc = new XDocument();
            var root = new XElement("class",
                students.Select(student => new XElement("student",
                new XAttribute("faculty-number", student.FacultyNumber),
                new XElement("name", student.Name),
                new XElement("gender", student.StudentGender.ToString()),
                new XElement("age", student.GetAge()),
                new XElement("phone", student.Phone),
                new XElement("email", student.Email),
                new XElement("course", student.Course),
                new XElement("speciality", student.Speciality),
                new XElement("exams",
                    student.Exams.Select(exam => new XElement("exam",
                    new XElement("course", exam.Name),
                    new XElement("tutor", exam.Tutor),
                    new XElement("score", exam.Score)
                    )))
                )));
            doc.Add(root);
            doc.Save(xmlResultPath);

            // create html
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("../../data/students.xslt");
            xslt.Transform("../../data/students.xml", "../../data/students.html");
        }
    }
}
