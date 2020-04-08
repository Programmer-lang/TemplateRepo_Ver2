namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    //[Table("dbo.Course")]
    public  class Course 
    {
       public Course()
        {
            StudentCourses = new HashSet<Student_Course>();
        }

         public decimal CourseID { get; set; }

        [StringLength(150)]
        public string CourseName { get; set; }

        public decimal TeacherID { get; set; }

        public virtual Teacher Teacher { get; set; }

       public virtual ICollection<Student_Course> StudentCourses { get; set; }
    }
}
