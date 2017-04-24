using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        if (firstName == null)
        {
            throw new ArgumentNullException("The first name cannot be missing!");
        }

        if (lastName == null)
        {
            throw new ArgumentNullException("The last name cannot be missing!");
        }

        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public IList<Exam> Exams { get; set; }

    public IList<ExamResult> CheckExams()
    {
        if (this.Exams == null)
        {
            throw new ArgumentNullException(string.Format("There are no exams for student {0} {1}!", this.FirstName, this.LastName));
        }

        if (this.Exams.Count == 0)
        {
            throw new ArgumentOutOfRangeException(string.Format("There are no exams for student {0} {1}!", this.FirstName, this.LastName));
        }

        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        if (this.Exams == null)
        {
            // Cannot calculate average on missing exams
            throw new ArgumentNullException(string.Format(
                "There are no exams for student {0} {1} to calculate average!",
                this.FirstName,
                this.LastName));
        }

        if (this.Exams.Count == 0)
        {
            throw new ArgumentOutOfRangeException(string.Format(
                "There are no exams for student {0} {1} to calculate average!",
                this.FirstName,
                this.LastName));
        }

        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = this.CheckExams();

        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] =
                ((double)examResults[i].Grade - examResults[i].MinGrade) /
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}