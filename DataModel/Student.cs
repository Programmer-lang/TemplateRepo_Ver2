namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    //[Table("dbo.Student")]
    public  class Student : ISchoolType
    {
       public Student()
        {
            StudentCourses = new HashSet<Student_Course>();
        }

        public decimal StudentID { get; set; }

        [StringLength(150)]
        public string StudentName { get; set; }

       public virtual ICollection<Student_Course> StudentCourses { get; set; }
    }
}
