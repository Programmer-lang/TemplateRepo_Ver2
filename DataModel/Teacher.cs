namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    //[Table("dbo.Teacher")]
    public partial class Teacher:EntityBase
    { 
        public Teacher()
        {
            Courses = new ObservableCollection<Course>();
        }

        public decimal TeacherID { get; set; }

       

        private string teacherName;

        [StringLength(150)]
        public string TeacherName
        {
            get
            {
                return teacherName;
            }

            set
            {
                if (teacherName != value)
                {
                    teacherName = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal SchoolID { get; set; }

        public virtual School School { get; set; }

        public virtual ObservableCollection<Course> Courses { get; set; }

        
    }
}
