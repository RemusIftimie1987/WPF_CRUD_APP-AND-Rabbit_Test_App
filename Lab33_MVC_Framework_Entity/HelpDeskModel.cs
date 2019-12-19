namespace Lab33_MVC_Framework_Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HelpDeskModel : DbContext
    {
        public HelpDeskModel()
            : base("name=AzureHelpDeskModel")
        {
        }


        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

