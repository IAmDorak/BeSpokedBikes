using BeSpokedBikes.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeSpokedBikes.Data
{
    public class BikeSalesContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesPerson> SalesPersons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Discount> Discounts { get; set; }

        public BikeSalesContext(DbContextOptions<BikeSalesContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, Name = "Product1", Manufacture = "Manufacturer1", Style = "Style1", PurchasePrice = 100.00, SalePrice = 100.00, QtyOnHand = 10, CommissionPercentage = 0.15 },
                new Product() { Id = 2, Name = "Product2", Manufacture = "Manufacturer2", Style = "Style2", PurchasePrice = 200.00, SalePrice = 170.00, QtyOnHand = 5, CommissionPercentage = 0.2 },
                new Product() { Id = 3, Name = "Product3", Manufacture = "Manufacturer3", Style = "Style3", PurchasePrice = 200.00, SalePrice = 300.00, QtyOnHand = 500, CommissionPercentage = 0.33 },
                new Product() { Id = 4, Name = "Product4", Manufacture = "Manufacturer3", Style = "Style3", PurchasePrice = 200.00, SalePrice = 300.00, QtyOnHand = 0, CommissionPercentage = 0.33 }
            );

            modelBuilder.Entity<SalesPerson>().HasData(
                new SalesPerson() { Id = 1, FirstName = "John", LastName = "Doe", Address = "455 The Street, The City, GA 30107", Phone = "(555)555-5555", StartDate = DateTime.Now, TerminationDate = null, Manager = "Johnson" },
                new SalesPerson() { Id = 2, FirstName = "Jane", LastName = "Doe", Address = "455 The Street, The City, GA 30107", Phone = "(555)555-5555", StartDate = DateTime.Now, TerminationDate = null, Manager = "Johnson" },
                new SalesPerson() { Id = 3, FirstName = "Brian", LastName = "Haynes", Address = "544 My Street, My City, GA 30107", Phone = "(555)556-5555", StartDate = DateTime.Now, TerminationDate = DateTime.Now, Manager = "Henry" }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer() { Id = 1, FirstName = "Tom", LastName = "Milton", Address = "233 Whos Street, Whos City, TN 37356", Phone = "(555)557-5577", StartDate = DateTime.Now },
                new Customer() { Id = 2, FirstName = "Jim", LastName = "Harison", Address = "322 That Street, That City, PA 39601", Phone = "(555)559-9577", StartDate = DateTime.Now },
                new Customer() { Id = 3, FirstName = "Kelly", LastName = "Belly", Address = "966 Whos Street, Whos City, TN 37356", Phone = "(555)551-5511", StartDate = DateTime.Now }
            );

            modelBuilder.Entity<Sale>().HasData(
                new Sale() { Id = 1, ProductId = 1, SalesPersonId = 1, CustomerId = 1, SaleDate = DateTime.Now },
                new Sale() { Id = 2, ProductId = 2, SalesPersonId = 1, CustomerId = 1, SaleDate = DateTime.Now },
                new Sale() { Id = 3, ProductId = 3, SalesPersonId = 1, CustomerId = 1, SaleDate = DateTime.Now },
                new Sale() { Id = 4, ProductId = 1, SalesPersonId = 1, CustomerId = 3, SaleDate = DateTime.Now },
                new Sale() { Id = 5, ProductId = 2, SalesPersonId = 2, CustomerId = 3, SaleDate = DateTime.Now },
                new Sale() { Id = 6, ProductId = 3, SalesPersonId = 2, CustomerId = 3, SaleDate = DateTime.Now },
                new Sale() { Id = 7, ProductId = 3, SalesPersonId = 2, CustomerId = 2, SaleDate = DateTime.Now },
                new Sale() { Id = 8, ProductId = 3, SalesPersonId = 2, CustomerId = 2, SaleDate = DateTime.Now },
                new Sale() { Id = 9, ProductId = 3, SalesPersonId = 2, CustomerId = 2, SaleDate = DateTime.Now },
                new Sale() { Id = 10, ProductId = 3, SalesPersonId = 3, CustomerId = 2, SaleDate = DateTime.Now },
                new Sale() { Id = 11, ProductId = 3, SalesPersonId = 2, CustomerId = 2, SaleDate = DateTime.Now }
            );

            modelBuilder.Entity<Discount>().HasData(
                new Discount() { Id = 1, ProductId = 1, BeginDate = new DateTime(2021, 9, 1), EndDate = new DateTime(2021, 10, 1), DiscountPercentage = .2 },
                new Discount() { Id = 2, ProductId = 2, BeginDate = new DateTime(2021, 9, 1), EndDate = new DateTime(2021, 10, 1), DiscountPercentage = .1 },
                new Discount() { Id = 3, ProductId = 3, BeginDate = new DateTime(2021, 9, 1), EndDate = new DateTime(2021, 10, 1), DiscountPercentage = .05 },
                new Discount() { Id = 4, ProductId = 1, BeginDate = new DateTime(2021, 1, 1), EndDate = new DateTime(2021, 2, 1), DiscountPercentage = .2 },
                new Discount() { Id = 5, ProductId = 2, BeginDate = new DateTime(2021, 1, 1), EndDate = new DateTime(2021, 2, 1), DiscountPercentage = .1 },
                new Discount() { Id = 6, ProductId = 3, BeginDate = new DateTime(2021, 1, 1), EndDate = new DateTime(2021, 2, 1), DiscountPercentage = .05 }
            );
        }
    }
}
