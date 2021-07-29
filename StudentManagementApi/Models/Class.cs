using System;
using System.Collections.Generic;

#nullable disable

namespace StudentManagementApi.Models
{
    public partial class Class
    {
        public Class()
        {
            ClassEnrolments = new HashSet<ClassEnrolment>();
        }

        public int ClassId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ClassEnrolment> ClassEnrolments { get; set; }
    }
}
