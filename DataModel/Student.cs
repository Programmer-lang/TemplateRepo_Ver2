namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;
    using Microsoft.EntityFrameworkCore;

    //[Table("dbo.Student")]
    public  class Student : EntityBase
    {
       public Student()
        {
            StudentCourses = new HashSet<Student_Course>();
        }

        public decimal StudentID { get; set; }

        private string studentName;

        [StringLength(150)]
        public string StudentName
        {
            get
            {
                return studentName;
            }

            set
            {
                if (studentName != value)
                {
                    studentName = value;
                    OnPropertyChanged();
                }
            }
        }
        public decimal SchoolID { get; set; }

        public virtual School School { get; set; }

        public virtual ICollection<Student_Course> StudentCourses { get; set; }

        
    }
}
