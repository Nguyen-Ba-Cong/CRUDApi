using System;
using System.Collections.Generic;

#nullable disable

namespace StudentManagementApi.Models
{
    public partial class Student
    {
        public Student()
        {
            ClassEnrolments = new HashSet<ClassEnrolment>();
        }

        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<ClassEnrolment> ClassEnrolments { get; set; }
    }
}
