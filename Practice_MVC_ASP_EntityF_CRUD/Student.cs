namespace Practice_MVC_ASP_EntityF_CRUD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Student
    {
        public int StudentID { get; set; }

        [StringLength(50)]
        public string Studentname { get; set; }

        public int? TutorID { get; set; }

        public virtual Tutor Tutor { get; set; }
    }
}
