using System;
using System.Collections.Generic;

#nullable disable

namespace StudentManagementApi.Models
{
    public partial class ClassEnrolment
    {
        public int StudentId { get; set; }
        public int ClassId { get; set; }

        public virtual Class Class { get; set; }
        public virtual Student Student { get; set; }
    }
}
