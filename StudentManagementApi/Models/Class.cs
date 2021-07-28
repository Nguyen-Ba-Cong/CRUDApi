using System;
using System.Collections.Generic;

#nullable disable

namespace StudentManagementApi.Models
{
    public partial class Class
    {
        public Class()
        {
            Students = new HashSet<Student>();
        }

        public int ClassId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
