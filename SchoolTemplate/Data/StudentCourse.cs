using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel
{
    //[Table("dbo.Student_Course")]
    public  class Student_Course : ISchoolType
    {
        public decimal StudentID { get; set; }
        public decimal CourseID { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
