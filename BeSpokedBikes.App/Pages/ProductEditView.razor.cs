using BeSpokedBikes.App.Services;
using BeSpokedBikes.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpokedBikes.App.Pages
{
    public partial class ProductEditView
    {
        [Inject]
        public IBeSpokedBikesService Service { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        public ProductUpdateDto UpdateProduct { get; set; } = new ProductUpdateDto();

        protected async override Task OnInitializedAsync()
        {
            var product = await Service.GetProduct(int.Parse(Id));
            UpdateProduct = new ProductUpdateDto()
            {
                Name = product.Name,
                Manufacture = product.Manufacture,
                Style = product.Style,
                PurchasePrice = product.PurchasePrice,
                SalePrice = product.SalePrice,
                QtyOnHand = product.QtyOnHand,
                CommissionPercentage = product.CommissionPercentage
            };
        }

        //used for failure messages.
        protected string Message = string.Empty;
        protected bool Failed = false;

        protected async Task HandleValidSubmit()
        {
            Failed = false;
            var passed = await Service.UpdateProduct(int.Parse(Id), UpdateProduct);

            if (passed)
            {
                NavigationManager.NavigateTo("/products");
            }
            else
            {
                Message = "Product update failed.";
                Failed = true;
            }
        }
        protected void HandleInvalidSubmit()
        {
            Message = "There are some validation error. Please try again.";
        }

        protected void NavigateToProducts()
        {
            NavigationManager.NavigateTo("/products");
        }
    }
}
