using System;
using System.Collections.Generic;

#nullable disable

namespace StudentManagementApi.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Gender { get; set; }
        public int? ClassId { get; set; }

        public virtual Class Class { get; set; }
    }
}
