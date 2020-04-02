namespace DataModel
{
   
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //[Table("dbo.School")]
    public  class School
    {
        public School()
        {
            Teachers = new HashSet<Teacher>();
        }

        public decimal SchoolID { get; set; }

        [StringLength(50)]
        public string SchoolName { get; set; }

        [StringLength(50)]
        public string Director { get; set; }

       public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
