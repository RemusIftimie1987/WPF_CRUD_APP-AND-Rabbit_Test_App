namespace Lab33_MVC_Framework_Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int UserID { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        public int? CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}
