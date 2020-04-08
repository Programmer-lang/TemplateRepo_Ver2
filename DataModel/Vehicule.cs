namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    //[Table("dbo.Teacher")]
    public partial class Vehicule 
    {
      

        public decimal VehiculeID { get; set; }

        [StringLength(100)]
        public string VehiculeName { get; set; }

        [StringLength(100)]

        public string VehiculeType { get; set; }

        [StringLength(100)]
        public string DriverName { get; set; }

        public decimal SchoolID { get; set; }

        public virtual School School { get; set; }


        
    }
}
