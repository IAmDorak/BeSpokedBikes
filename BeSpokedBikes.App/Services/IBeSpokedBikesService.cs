using BeSpokedBikes.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpokedBikes.App.Services
{
    public interface IBeSpokedBikesService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProduct(int id);
        Task<bool> UpdateProduct(int id, ProductUpdateDto updateProduct);
        Task<IEnumerable<SalesPersonDto>> GetSalesPersons();
        Task<SalesPersonDto> GetSalesPerson(int id);
        Task<bool> UpdateSalesPerson(int id, SalesPersonUpdateDto updateSalesPerson);
        Task<IEnumerable<CustomerDto>> GetCustomers();
        Task<CustomerDto> GetCustomer(int id);
        Task<IEnumerable<SaleDto>> GetSales();
        Task<SaleDto> GetSale(int id);
        Task<SaleDto> CreateSale(SalesCreationDto createSale);
        Task<IEnumerable<DiscountDto>> GetDiscounts(bool OnlyActiveDiscounts = false);
    }
}
