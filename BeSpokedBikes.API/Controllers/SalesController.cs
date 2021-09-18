using BeSpokedBikes.Shared.Models;
using BeSpokedBikes.API.Services;
using BeSpokedBikes.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpokedBikes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IBikeSalesRepository _repository;

        public SalesController(IBikeSalesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaleDto>>> GetSales()
        {
            var salesEntities = await _repository.GetSales();

            var sales = salesEntities.Select(s =>
                CreateSaleDto(s)
            ).ToList();

            return Ok(sales);
        }

        [HttpGet("{id}", Name = "GetSale")]
        public async Task<ActionResult<SaleDto>> GetSale(int id)
        {
            var saleEntity = await _repository.GetSale(id);

            if (saleEntity == null)
            {
                return NotFound();
            }

            var sale = CreateSaleDto(saleEntity);

            return Ok(sale);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSale([FromBody] SalesCreationDto sale)
        {
            var saleEntity = new Sale()
            {
                ProductId = sale.Product.Id,
                SalesPersonId = sale.SalesPerson.Id,
                CustomerId = sale.Customer.Id,
                SaleDate = sale.SaleDate
            };

            await _repository.AddSale(saleEntity);
            _repository.Save();

            saleEntity = await _repository.GetSale(saleEntity.Id);

            var newSale = CreateSaleDto(saleEntity);

            return CreatedAtRoute("GetSale", new { id = newSale.Id }, newSale);
        }

        private SaleDto CreateSaleDto(Sale saleEntity)
        {
            return new SaleDto()
            {
                Id = saleEntity.Id,
                Product = new ProductDto()
                {
                    Id = saleEntity.Product.Id,
                    Name = saleEntity.Product.Name,
                    Manufacture = saleEntity.Product.Manufacture,
                    Style = saleEntity.Product.Style,
                    PurchasePrice = saleEntity.Product.PurchasePrice,
                    SalePrice = saleEntity.Product.SalePrice,
                    QtyOnHand = saleEntity.Product.QtyOnHand,
                    CommissionPercentage = saleEntity.Product.CommissionPercentage
                },
                SalesPerson = new SalesPersonDto()
                {
                    Id = saleEntity.SalesPerson.Id,
                    FirstName = saleEntity.SalesPerson.FirstName,
                    LastName = saleEntity.SalesPerson.LastName,
                    Address = saleEntity.SalesPerson.Address,
                    Phone = saleEntity.SalesPerson.Phone,
                    StartDate = saleEntity.SalesPerson.StartDate,
                    TerminationDate = (saleEntity.SalesPerson.TerminationDate.HasValue) ? saleEntity.SalesPerson.TerminationDate : null,
                    Manager = saleEntity.SalesPerson.Manager
                },
                Customer = new CustomerDto()
                {
                    Id = saleEntity.Customer.Id,
                    FirstName = saleEntity.Customer.FirstName,
                    LastName = saleEntity.Customer.LastName,
                    Address = saleEntity.Customer.Address,
                    Phone = saleEntity.Customer.Phone,
                    StartDate = saleEntity.Customer.StartDate
                },
                SaleDate = saleEntity.SaleDate
            };
        }
    }
}
