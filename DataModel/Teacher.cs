namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    //[Table("dbo.Teacher")]
    public partial class Teacher : ISchoolType
    {
        public Teacher()
        {
            Courses = new HashSet<Course>();
        }

        public decimal TeacherID { get; set; }

        [StringLength(150)]
        public string TeacherName { get; set; }

        public decimal SchoolID { get; set; }

        public virtual School School { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        
    }
}
