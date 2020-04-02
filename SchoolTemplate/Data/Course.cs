namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    //[Table("dbo.Course")]
    public  class Course : ISchoolType
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student_Course> StudentCourses { get; set; }
    }
}
