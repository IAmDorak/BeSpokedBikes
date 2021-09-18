using BeSpokedBikes.Shared.Models;
using BeSpokedBikes.Data;
using BeSpokedBikes.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpokedBikes.API.Services
{
    public class BikeSaleRepository : IBikeSalesRepository
    {
        private readonly BikeSalesContext _context;

        public BikeSaleRepository(BikeSalesContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateProductAlreadyExist(ProductUpdateDto product)
        {
            return await _context.Products.AnyAsync(p => p.Name == product.Name &&
                                                    p.Manufacture == product.Manufacture &&
                                                    p.Style == product.Style &&
                                                    p.PurchasePrice == product.PurchasePrice &&
                                                    p.SalePrice == product.SalePrice &&
                                                    p.QtyOnHand == product.QtyOnHand &&
                                                    p.CommissionPercentage == product.CommissionPercentage);
        }

        public async Task<bool> ProductAtIndexExists(int id)
        {
            return await _context.Products.AnyAsync(p => p.Id == id);
        }

        public async Task<Product> UpdateProduct(int id, ProductUpdateDto product)
        {
            var productToBeUpdated = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();

            productToBeUpdated.Name = product.Name;
            productToBeUpdated.Manufacture = product.Manufacture;
            productToBeUpdated.Style = product.Style;
            productToBeUpdated.PurchasePrice = product.PurchasePrice;
            productToBeUpdated.SalePrice = product.SalePrice;
            productToBeUpdated.QtyOnHand = product.QtyOnHand;
            productToBeUpdated.CommissionPercentage = product.CommissionPercentage;
            _context.Entry(productToBeUpdated).State = EntityState.Modified;

            return productToBeUpdated;
        }

        public async Task<IEnumerable<SalesPerson>> GetSalesPersons()
        {
            return await _context.SalesPersons.OrderBy(sp => sp.FirstName).OrderBy(sp => sp.LastName).ToListAsync();
        }

        public async Task<SalesPerson> GetSalesPerson(int id)
        {
            return await _context.SalesPersons.Where(sp => sp.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateSalesPersonAlreadyExist(SalesPersonUpdateDto salesPerson)
        {
            return await _context.SalesPersons.AnyAsync(sp => sp.FirstName == salesPerson.FirstName &&
                                             sp.LastName == salesPerson.LastName &&
                                             sp.Address == salesPerson.Address &&
                                             sp.Phone == salesPerson.Phone &&
                                             sp.TerminationDate == salesPerson.TerminationDate &&
                                             sp.Manager == salesPerson.Manager);
        }

        public async Task<bool> SalesPersonAtIndexExists(int id)
        {
            return await _context.SalesPersons.AnyAsync(p => p.Id == id);
        }

        public async Task<SalesPerson> UpdateSalesPerson(int id, SalesPersonUpdateDto salesPerson)
        {
            var salesPersonToBeUpdated = await _context.SalesPersons.Where(p => p.Id == id).FirstOrDefaultAsync();

            salesPersonToBeUpdated.FirstName = salesPerson.FirstName;
            salesPersonToBeUpdated.LastName = salesPerson.LastName;
            salesPersonToBeUpdated.Address = salesPerson.Address;
            salesPersonToBeUpdated.Phone = salesPerson.Phone;
            salesPersonToBeUpdated.TerminationDate = salesPerson.TerminationDate;
            salesPersonToBeUpdated.Manager = salesPerson.Manager;
            _context.Entry(salesPersonToBeUpdated).State = EntityState.Modified;

            return salesPersonToBeUpdated;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _context.Customers.OrderBy(c => c.FirstName).OrderBy(c => c.LastName).ToListAsync();
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await _context.Customers.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Sale>> GetSales()
        {
            return await _context.Sales.OrderBy(s => s.Id).Include(s => s.Product).Include(s => s.SalesPerson).Include(s => s.Customer).ToListAsync();
        }

        public async Task<Sale> GetSale(int id)
        {
            return await _context.Sales.Where(p => p.Id == id).Include(s => s.Product).Include(s => s.SalesPerson).Include(s => s.Customer).FirstOrDefaultAsync();
        }

        public async Task AddSale(Sale newSale)
        {
            await _context.Sales.AddAsync(newSale);
        }

        public async Task<IEnumerable<Discount>> GetDiscounts(bool OnlyActiveDiscounts = false)
        {
            if (OnlyActiveDiscounts)
            {
                var currentDate = DateTime.Now;
                return await _context.Discounts.Include(d => d.Product)
                                               .Where(d => d.BeginDate <= currentDate && d.EndDate >= currentDate)
                                               .OrderBy(d => d.EndDate)
                                               .OrderBy(d => d.BeginDate).ToListAsync();
            }

            return await _context.Discounts.Include(d => d.Product).OrderBy(d => d.EndDate).OrderBy(d => d.BeginDate).ToListAsync();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
