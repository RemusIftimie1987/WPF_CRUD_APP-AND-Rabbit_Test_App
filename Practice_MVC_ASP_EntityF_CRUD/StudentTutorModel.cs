namespace Practice_MVC_ASP_EntityF_CRUD
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StudentTutorModel : DbContext
    {
        public StudentTutorModel()
            : base("name=StudentTutorModel")
        {
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Tutor> Tutors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
