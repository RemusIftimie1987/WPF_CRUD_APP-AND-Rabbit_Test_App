using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lab_20_Northwind_Products
{
   public class Program
    {
        //List<> customers = new List<Customer>();
        static void Main(string[] args)
        {
            // Create a test to work out the number of products beginning with P

            using (var db = new Northwind())
            {
                //Console.WriteLine(GetProduct());
            }
        }

        //public static int GetProduct()
        //{
        //    using (var db = new Northwind())
        //    {
        //        string inputLetter = "p";
        //        return db.Products.Where
        //            (p =>
        //            p.ProductName.StartsWith("p") ||
        //            p.ProductName.StartsWith("P"))
        //            .Count();

        //        //Different way
        //        var products =
        //            db.Products.Where(p =>
        //            p.ProductName.StartsWith(inputLetter.ToUpper()) ||
        //            p.ProductName.StartsWith(inputLetter.ToLower()))
        //            .Count();
        //    }
        //    return -1;
        //}
    }

    public class NorthindProductTest
    {

        public int GetProduct(string letter)
        {
            using (var db = new Northwind())
            {
                //string inputLetter = "p";
                return db.Products.Where
                    (p =>
                    p.ProductName.StartsWith(letter))
                    .Count();

                //Different way
                //var products =
                //    db.Products.Where(p =>
                //    p.ProductName.StartsWith(inputLetter.ToUpper()) ||
                //    p.ProductName.StartsWith(inputLetter.ToLower()))
                //    .Count();
            }
            //return -1;
        }
        
        public static int TestNumberOfProductsContainingALetter(string letter)
        {
            using (var db = new Northwind())
            {
                return db.Products.Where(p => p.ProductName.Contains(letter)).Count();
            }
        }

    }

    #region NorthwindContextAndClasses
    public partial class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            this.Products = new List<Product>();
        }
    }

    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; } = 0;
        public short? UnitsInStock { get; set; } = 0;
        public short? UnitsOnOrder { get; set; } = 0;
        public short? ReorderLevel { get; set; } = 0;
        public bool Discontinued { get; set; } = false;
    }

    public class Northwind : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;" + "Initial Catalog=Northwind;" + "Integrated Security = true;" + "MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

            // define a one-to-many relationship
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category);

            modelBuilder.Entity<Product>()
                .Property(c => c.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products);
        }
    }
    #endregion
}
