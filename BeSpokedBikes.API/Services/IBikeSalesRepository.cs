using BeSpokedBikes.Shared.Models;
using BeSpokedBikes.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpokedBikes.API.Services
{
    public interface IBikeSalesRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task<bool> UpdateProductAlreadyExist(ProductUpdateDto product);
        Task<bool> ProductAtIndexExists(int id);
        Task<Product> UpdateProduct(int id, ProductUpdateDto product);
        Task<IEnumerable<SalesPerson>> GetSalesPersons();
        Task<SalesPerson> GetSalesPerson(int id);
        Task<bool> UpdateSalesPersonAlreadyExist(SalesPersonUpdateDto salesPerson);
        Task<bool> SalesPersonAtIndexExists(int id);
        Task<SalesPerson> UpdateSalesPerson(int id, SalesPersonUpdateDto salesPerson);
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomer(int id);
        Task<IEnumerable<Sale>> GetSales();
        Task<Sale> GetSale(int id);
        Task AddSale(Sale newSale);
        Task<IEnumerable<Discount>> GetDiscounts(bool OnlyActiveDiscounts);
        bool Save();
    }
}
