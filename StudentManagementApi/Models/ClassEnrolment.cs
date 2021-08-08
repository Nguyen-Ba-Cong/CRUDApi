using System;
using System.Collections.Generic;

#nullable disable

namespace StudentManagementApi.Models
{
    public partial class ClassEnrolment
    {
        //private static ClassEnrolment classEnrolment = null;

        //public static ClassEnrolment GetClassEnrolment
        //{
        //    get
        //    {
        //        if (classEnrolment == null)
        //        {
        //            classEnrolment = new ClassEnrolment();
        //        }
        //        return classEnrolment;
        //    }
        //}
        public ClassEnrolment()
        {

        }
        public int StudentId { get; set; }
        public int ClassId { get; set; }

        public virtual Class Class { get; set; }
        public virtual Student Student { get; set; }
    }
}
