using BeSpokedBikes.App.Services;
using BeSpokedBikes.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpokedBikes.App.Pages
{
    public partial class SaleAddView
    {
        [Inject]
        public IBeSpokedBikesService Service { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public IEnumerable<ProductDto> Products { get; set; } = new List<ProductDto>();
        public IEnumerable<SalesPersonDto> SalesPersons { get; set; } = new List<SalesPersonDto>();
        public IEnumerable<CustomerDto> Customers { get; set; } = new List<CustomerDto>();

        public SalesCreationDto CreateSale { get; set; } = new SalesCreationDto();

        public string ProductId 
        { 
            get
            {
                return (CreateSale.Product != null) ? CreateSale.Product.Id.ToString() : string.Empty;
            }
            set
            {
                CreateSale.Product = (value != string.Empty) ? Products.FirstOrDefault(c => c.Id == int.Parse(value)) : null;
            }
        }

        public string SalesPersonId 
        {
            get
            {
                return (CreateSale.SalesPerson != null) ? CreateSale.SalesPerson.Id.ToString() : string.Empty;
            }
            set
            {
                CreateSale.SalesPerson = (value != string.Empty) ? SalesPersons.FirstOrDefault(c => c.Id == int.Parse(value)) : null;
            }
        }

        public string CustomerId 
        { 
            get
            {
                return (CreateSale.Customer != null) ? CreateSale.Customer.Id.ToString() : string.Empty;
            }
            set
            {
                CreateSale.Customer = (value != string.Empty) ? Customers.FirstOrDefault(c => c.Id == int.Parse(value)) : null;
            }
        }

        //used for failure messages.
        protected string Message = string.Empty;
        protected bool Failed = false;

        protected async override Task OnInitializedAsync()
        {
            Products = (await Service.GetProducts()).Where(p => p.QtyOnHand > 0);
            SalesPersons = (await Service.GetSalesPersons()).Where(sp => !sp.TerminationDate.HasValue);
            Customers = await Service.GetCustomers();

            CreateSale = new SalesCreationDto()
            {
                Product = Products.FirstOrDefault(),
                SalesPerson = SalesPersons.FirstOrDefault(),
                Customer = Customers.FirstOrDefault(),
                SaleDate = DateTime.Now
            };
        }

        protected async Task HandleValidSubmit()
        {
            Failed = false;

            var sale = await Service.CreateSale(CreateSale);

            var productUpdate = new ProductUpdateDto()
            {
                Name = CreateSale.Product.Name,
                Manufacture = CreateSale.Product.Manufacture,
                Style = CreateSale.Product.Style,
                PurchasePrice = CreateSale.Product.PurchasePrice,
                SalePrice = CreateSale.Product.SalePrice,
                QtyOnHand = --CreateSale.Product.QtyOnHand,
                CommissionPercentage = CreateSale.Product.CommissionPercentage
            };
            var passed = await Service.UpdateProduct(CreateSale.Product.Id, productUpdate);

            if (sale != null && passed)
            {
                NavigationManager.NavigateTo("/sales");
            }
            else
            {
                Message = "Salesperson update failed.";
                Failed = true;
            }
        }

        protected void HandleInvalidSubmit()
        {
            Message = "There are some validation error. Please try again.";
        }

        protected void NavigateToSales()
        {
            NavigationManager.NavigateTo("/sales");
        }
    }
}
