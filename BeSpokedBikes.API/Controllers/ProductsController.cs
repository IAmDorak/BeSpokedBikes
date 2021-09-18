using BeSpokedBikes.Shared.Models;
using BeSpokedBikes.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeSpokedBikes.Data.Entities;

namespace BeSpokedBikes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IBikeSalesRepository _repository;

        public ProductsController(IBikeSalesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var productEntities = await _repository.GetProducts();

            var products = productEntities.Select(p =>
                CreateProductDto(p)
            ).ToList();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var productEntity = await _repository.GetProduct(id);

            if (productEntity == null)
            {
                return NotFound();
            }

            var product = CreateProductDto(productEntity);

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(int id, [FromBody] ProductUpdateDto product)
        {
            if (!await _repository.ProductAtIndexExists(id))
            {
                return NotFound();
            }

            if (await _repository.UpdateProductAlreadyExist(product))
            {
                ModelState.AddModelError("Product", "The updated product matches an existing product.");
                ModelState.AddModelError("Code", "100");
                return BadRequest(ModelState);
            }

            var updatedProductEntity = await _repository.UpdateProduct(id, product);
            _repository.Save();

            var UpdatedProduct = CreateProductDto(updatedProductEntity);

            return Ok(UpdatedProduct);
        }

        private ProductDto CreateProductDto(Product productEntity)
        {
            return new ProductDto()
            {
                Id = productEntity.Id,
                Name = productEntity.Name,
                Manufacture = productEntity.Manufacture,
                Style = productEntity.Style,
                PurchasePrice = productEntity.PurchasePrice,
                SalePrice = productEntity.SalePrice,
                QtyOnHand = productEntity.QtyOnHand,
                CommissionPercentage = productEntity.CommissionPercentage
            };
        }
    }
}
