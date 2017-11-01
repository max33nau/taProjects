using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeStudentCourses
{
    public class Course
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<Student> Students { get; set; }
    }
}