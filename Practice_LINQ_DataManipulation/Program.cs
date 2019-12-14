using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;

namespace Practice_LINQ_DataManipulation
{
    class Program
    {
        List<Customer> customers = new List<Customer>();
        static void Main(string[] args)
        {
            //LINQ_Over_Northwind.ListCustomersFromSpecificCity();
            //LINQ_Over_Northwind.ListProductsLIKE();
            //LINQ_Over_Northwind.ListProductsLIKEWithJoin();
            LINQ_Over_Northwind.DisplayProductsPerCategory();
        }
    }

    class LINQ_Over_Northwind
    {
        //List all customers based on specific City
        public static void ListCustomersFromSpecificCity()
        {
            using (var db = new Northwind())
            {
                var customers =
                    (db.Customers.Where(c => c.CustomerID != null)
                .Where(c => c.City == "London" || c.City == "Paris")).ToList();
                 customers.ForEach(c => Console.WriteLine($"City as{c.CompanyName, -15}{c.ContactName,-15}{c.Address,-15}"));
                Console.Read();
            }
        }

        // List all products stored IN bottle
        public static void ListProductsLIKE()
        {
            using (var db = new Northwind())
            {
                var products = db.Products.Where(p => p.QuantityPerUnit.Contains("bottle")).ToList();
                products.ForEach(p => Console.WriteLine($"Products that contains bottle are:{p.ProductName}"));
                Console.ReadLine();
            }
        }

        //List all products stored IN bottle
        // Plus add Supplier Name and Country
        public static void ListProductsLIKEWithJoin()
        {
            using (var db = new Northwind())
            {
                var products = (from p in db.Products
                               join s in db.Suppliers
                               on p.SupplierID equals s.SupplierID
                               select new
                               {
                                   BottleProducts = p.QuantityPerUnit,
                                   SupplierName = s.CompanyName,
                                   SupplyingCountry = s.Country
                               }).ToList();
                products.ForEach(p => Console.WriteLine($"{p.BottleProducts, -15}{p.SupplierName, -30}{p.SupplyingCountry}"));
                Console.ReadLine();
            }
        }

        // Display the total number of products for each category
        public static void DisplayProductsPerCategory()
        {
            using (var db = new Northwind())
            {
                var totalProducts = (from p in db.Products
                                    join c in db.Categories
                                    on p.CategoryID equals c.CategoryID
                                    group c by c.CategoryName into CategorySpecific
                                    select new
                                    {
                                        CategName = CategorySpecific.Key,
                                        NumberOfProducts = CategorySpecific.Count()
                                        
                                    }).ToList();
                totalProducts.ForEach(p => Console.WriteLine($"{p.CategName, -15}{p.NumberOfProducts}"));
            }
        }
    }

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
        public int? SupplierID { get; set; }
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

        public DbSet<Supplier> Suppliers { get; set; }

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
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Country { get; set; }
    }
}
