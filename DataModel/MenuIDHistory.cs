namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //[Table("MenuIDHistory")]
    public  class MenuIDHistory
    {
        public decimal ID { get; set; }


        [StringLength(50)]
        public string User { get; set; }

        public string Note { get; set; }
    }
}
