using BeSpokedBikes.Shared.Models;
using BeSpokedBikes.API.Services;
using BeSpokedBikes.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpokedBikes.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IBikeSalesRepository _repository;

        public DiscountsController(IBikeSalesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiscountDto>>> GetDiscounts(bool OnlyActiveDiscounts = false)
        {
            var discountEntities = await _repository.GetDiscounts(OnlyActiveDiscounts);

            var discounts = discountEntities.Select(d =>
                new DiscountDto()
                {
                    Id = d.Id,
                    Product = new ProductDto() 
                    {
                        Id = d.Product.Id,
                        Name = d.Product.Name,
                        Manufacture = d.Product.Manufacture,
                        Style = d.Product.Style,
                        PurchasePrice = d.Product.PurchasePrice,
                        SalePrice = d.Product.SalePrice,
                        QtyOnHand = d.Product.QtyOnHand,
                        CommissionPercentage = d.Product.CommissionPercentage
                    },
                    BeginDate = d.BeginDate,
                    EndDate = d.EndDate,
                    DiscountPercentage = d.DiscountPercentage
                }
            ).ToList();

            return Ok(discounts);
        }
    }
}
