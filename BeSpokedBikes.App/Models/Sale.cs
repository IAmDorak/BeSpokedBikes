using BeSpokedBikes.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpokedBikes.App.Models
{
    public class Sale
    {
        public string ProductName { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public double Price { get; set; }
        public string SalesPersonFirstName { get; set; }
        public string SalesPersonLastName { get; set; }
        public double SalesPersonCommission { get; set; }
        public DateTime SaleDate { get; set; }

        public static IEnumerable<Sale> CreateSales(IEnumerable<SaleDto> saleDtos, IEnumerable<DiscountDto> discountDtos)
        {
            var saleModels = new List<Sale>();
            foreach (var saleDto in saleDtos)
            {
                var discountSum = discountDtos.Where(d => d.Product.Id == saleDto.Product.Id).Sum(d => d.DiscountPercentage);
                var price = saleDto.Product.SalePrice - (saleDto.Product.SalePrice * discountSum);
                var commission = price * saleDto.Product.CommissionPercentage;
                var sale = new Sale()
                {
                    ProductName = saleDto.Product.Name,
                    CustomerFirstName = saleDto.Customer.FirstName,
                    CustomerLastName = saleDto.Customer.LastName,
                    Price = price,
                    SalesPersonFirstName = saleDto.SalesPerson.FirstName,
                    SalesPersonLastName = saleDto.SalesPerson.LastName,
                    SalesPersonCommission = commission,
                    SaleDate = saleDto.SaleDate
                };
                saleModels.Add(sale);
            }

            return saleModels;
        }
    }
}
