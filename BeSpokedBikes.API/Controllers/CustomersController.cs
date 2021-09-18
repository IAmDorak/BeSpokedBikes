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
    public class CustomersController : ControllerBase
    {
        private readonly IBikeSalesRepository _repository;

        public CustomersController(IBikeSalesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            var customerEntities = await _repository.GetCustomers();

            var customers = customerEntities.Select(c =>
                CreateCustomerDto(c)
            ).ToList();

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
        {
            var customerEntity = await _repository.GetCustomer(id);

            if (customerEntity == null)
            {
                return NotFound();
            }

            var customer = CreateCustomerDto(customerEntity);

            return Ok(customer);
        }

        private CustomerDto CreateCustomerDto(Customer customerEntity)
        {
            return new CustomerDto()
            {
                Id = customerEntity.Id,
                FirstName = customerEntity.FirstName,
                LastName = customerEntity.LastName,
                Address = customerEntity.Address,
                Phone = customerEntity.Phone,
                StartDate = customerEntity.StartDate
            };
        }
    }
}
