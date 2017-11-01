using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeStudentCourses
{
    public class Student
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<Course> Courses { get; set; }
        public List<Enrollment> Enrollments { get; set; }
    }
}