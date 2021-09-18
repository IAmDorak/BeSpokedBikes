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
    public class SalesPersonsController : ControllerBase
    {
        private readonly IBikeSalesRepository _repository;

        public SalesPersonsController(IBikeSalesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesPersonDto>>> GetSalesPersons()
        {
            var salesPersonEntities = await _repository.GetSalesPersons();

            var salesPersons = salesPersonEntities.Select(sp =>
                CreateSalesPersonDto(sp)
            ).ToList();

            return Ok(salesPersons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetSalesPerson(int id)
        {
            var salesPersonEntity = await _repository.GetSalesPerson(id);

            if (salesPersonEntity == null)
            {
                return NotFound();
            }

            var salesPerson = CreateSalesPersonDto(salesPersonEntity);

            return Ok(salesPerson);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SalesPersonDto>> UpdateSalesPerson(int id, [FromBody] SalesPersonUpdateDto salesPerson)
        {
            if (!await _repository.SalesPersonAtIndexExists(id))
            {
                return NotFound();
            }

            if (await _repository.UpdateSalesPersonAlreadyExist(salesPerson))
            {
                ModelState.AddModelError("SalesPerson", "The updated sales person matches an existing sales person.");
                ModelState.AddModelError("Code", "200");
                return BadRequest(ModelState);
            }

            var salesPersonEntity = await _repository.UpdateSalesPerson(id, salesPerson);
            _repository.Save();

            var UpdatedSalesPerson = CreateSalesPersonDto(salesPersonEntity);

            return Ok(UpdatedSalesPerson);
        }

        private SalesPersonDto CreateSalesPersonDto(SalesPerson salesPersonEntity)
        {
            return new SalesPersonDto()
            {
                Id = salesPersonEntity.Id,
                FirstName = salesPersonEntity.FirstName,
                LastName = salesPersonEntity.LastName,
                Address = salesPersonEntity.Address,
                Phone = salesPersonEntity.Phone,
                StartDate = salesPersonEntity.StartDate,
                TerminationDate = (salesPersonEntity.TerminationDate.HasValue) ? salesPersonEntity.TerminationDate.Value : null,
                Manager = salesPersonEntity.Manager
            };
        }
    }
}
