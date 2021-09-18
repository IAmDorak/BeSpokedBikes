using BeSpokedBikes.App.Services;
using BeSpokedBikes.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpokedBikes.App.Pages
{
    public partial class ProductsView
    {
        [Inject]
        public IBeSpokedBikesService Service { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Products = await Service.GetProducts();
        }
    }
}
