using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeStudentCourses
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void assignment1Button_Click(object sender, EventArgs e)
        {
            List<Course> courses = new List<Course>()
            {
                new Course() { Name = "Econ 101", Id = 1,
                    Students = new List<Student>()
                    {
                        new Student() { Name = "Bob Tabor", Id = 1 },
                        new Student() { Name = "Steve Jaworski", Id = 2 }
                    }
                },
                new Course() { Name = "Discrete Math", Id = 2,
                    Students = new List<Student>()
                    {
                        new Student() { Name = "Brian Faley", Id = 3 },
                        new Student() { Name = "Chuck Ravetto", Id = 4 }
                    }
                },
                new Course() { Name = "History 302", Id = 3,
                    Students = new List<Student>()
                    {
                        new Student() { Name = "Andrew Flowers", Id = 5 },
                        new Student() { Name = "Andrew Sekala", Id = 6 }
                    }
                }
            };

            string result = "";
            foreach(Course course in courses)
            {
                result += String.Format("Course: {0} - {1} <br />", course.Id, course.Name);
                foreach(Student student in course.Students)
                {
                    result += String.Format(
                        "<div style=\"margin-left: 10px;\"> Student: {0} - {1} </div>", 
                        student.Id, student.Name
                    );
                }
                result += "<hr />";
            }

            resultLabel.Text = result;
        }

        protected void assignment2Button_Click(object sender, EventArgs e)
        {
            Student student1 = new Student() { Name = "Joe Dirt", Id = 1,
                Courses = new List<Course>() {
                new Course() { Name = "Econ 101", Id = 1 },
                new Course() { Name = "Discrete Math", Id = 2 } }
            };
            Student student2 = new Student()
            {
                Name = "Billy Madison",
                Id = 2,
                Courses = new List<Course>() {
                new Course() { Name = "Physics", Id = 3 },
                new Course() { Name = "PE", Id = 4 } }
            };
            Student student3 = new Student()
            {
                Name = "Peggy",
                Id = 3,
                Courses = new List<Course>() {
                new Course() { Name = "Algebra", Id = 5 },
                new Course() { Name = "Chemistry", Id = 6 } }
            };
            Dictionary<int, Student> students = new Dictionary<int, Student>()
            {
                { student1.Id, student1 },
                { student2.Id, student2 },
                { student3.Id, student3 }
            };

            string result = "";
            foreach (KeyValuePair<int, Student> student in students)
            {
                result += String.Format("Student: {0} - {1} <br />", student.Key, student.Value.Name);
                foreach (Course course in student.Value.Courses)
                {
                    result += String.Format(
                        "<div style=\"margin-left: 10px;\"> Course: {0} - {1} </div>",
                        course.Id, course.Name
                    );
                }
                result += "<hr />";
            }

            resultLabel.Text = result;
        }

        protected void assignment3Button_Click(object sender, EventArgs e)
        {
            Student student1 = new Student()
            {
                Name = "Batman",
                Id = 1,
                Enrollments = new List<Enrollment>() {
                new Enrollment() { Course = new Course() { Name = "Econ 101", Id = 1 }, Grade = 97 },
                new Enrollment() { Course = new Course() { Name = "Calculus", Id = 2 }, Grade = 67 }
                }
            };
            Student student2 = new Student()
            {
                Name = "Superman",
                Id = 2,
                Enrollments = new List<Enrollment>() {
                new Enrollment() { Course = new Course() { Name = "Photography", Id = 3}, Grade = 50 },
                new Enrollment() { Course = new Course() { Name = "Dodgeball", Id = 4 }, Grade = 100 }
                }
            };
            Student student3 = new Student()
            {
                Name = "Spiderman",
                Id = 3,
                Enrollments = new List<Enrollment>() {
                new Enrollment() { Course = new Course() { Name = "English", Id = 5}, Grade = 85 },
                new Enrollment() { Course = new Course() { Name = "Writing", Id = 6 }, Grade = 87 }
                }
            };
            Dictionary<int, Student> students = new Dictionary<int, Student>()
            {
                { student1.Id, student1 },
                { student2.Id, student2 },
                { student3.Id, student3 }
            };

            string result = "";
            foreach (KeyValuePair<int, Student> student in students)
            {
                result += String.Format("Student: {0} - {1} <br />", student.Key, student.Value.Name);
                result += "Enrollments: <br />";
                foreach (Enrollment enrollment in student.Value.Enrollments)
                {
                    result += String.Format(
                        "<div style=\"margin-left: 20px;\"> Course: {0} - {1} - <strong> Grade: {2} </strong> </div>",
                        enrollment.Course.Id, enrollment.Course.Name, enrollment.Grade
                    );
                }
                result += "<hr />";
            }

            resultLabel.Text = result;
        }
    }
}