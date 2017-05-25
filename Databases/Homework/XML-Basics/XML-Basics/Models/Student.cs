using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XML_Basics.Contracts;
using XML_Basics.Enumerations;
using XML_Basics.Utilities;

namespace XML_Basics
{
    class Student : IStudent
    {
        private int MinFacultyNumber = Constants.MinFacultyNumber;
        private int MaxFacultyNumber = Constants.MaxFacultyNumber;
        private int DaysInAYear = Constants.DaysInAYear;

        private string _name;
        private string _email;
        private int _facultyNumber;

        public Student(string name, Gender studentGender, DateTime birthDate, string phone, string email, Course course, Speciality speciality, int facultyNumber, IEnumerable<IExam> exams)
        {
            this.Name = name;
            this.StudentGender = studentGender;
            this.BirthDate = birthDate;
            this.Phone = phone;
            this.Email = email;
            this.Course = course;
            this.Speciality = speciality;
            this.FacultyNumber = facultyNumber;
            this.Exams = new List<IExam>(exams);
        }

        public Student()
        {
        }

        public Gender StudentGender { get; set; }

        public DateTime BirthDate { get; set; }

        public string Phone { get; set; }

        public Course Course { get; set; }

        public Speciality Speciality { get; set; }

        public IEnumerable<IExam> Exams { get; set; }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == null || value.Length < 3)
                {
                    throw new ArgumentException("Name must be a string more than 3 symbols long!");
                }
                _name = value;
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (!Validator.EmailIsValid(value))
                {
                    throw new ArgumentException("Email address is not valid!");
                }

                _email = value;
            }
        }

        public int FacultyNumber
        {
            get { return _facultyNumber; }
            set
            {
                if (value < MinFacultyNumber || value > MaxFacultyNumber)
                {
                    throw new ArgumentOutOfRangeException("Faculty number is not correct!");
                }
                _facultyNumber = value;
            }
        }

        public double GetAge()
        {
            return Math.Round((DateTime.Now - this.BirthDate).TotalDays / DaysInAYear, 0);
        }

        public override string ToString()
        {
            return $@"
------ student ------
Name: {this.Name}
Gender: {this.StudentGender}
Age: {this.GetAge()}
Phone: {this.Phone}
E-Mail: {this.Email}
Course: {this.Course}
Speciality: {this.Speciality}
Fac Number: {this.FacultyNumber}
Passsed exams: {string.Join("", this.Exams)}
------ student ------
";
        }
    }
}
