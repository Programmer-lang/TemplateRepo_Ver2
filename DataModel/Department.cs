namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    
    public partial class Department 
    {
      

        public decimal DepartmentID { get; set; }

        [StringLength(100)]
        public string DepartmentName { get; set; }

        [StringLength(250)]

        public string Description { get; set; }

        
        public decimal SchoolID { get; set; }

        public virtual School School { get; set; }


        
    }
}
