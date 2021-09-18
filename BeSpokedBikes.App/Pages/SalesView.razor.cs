using BeSpokedBikes.App.Models;
using BeSpokedBikes.App.Services;
using BeSpokedBikes.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpokedBikes.App.Pages
{
    public partial class SalesView
    {
        [Inject]
        public IBeSpokedBikesService Service { get; set; }

        public IEnumerable<Sale> Sales { get; private set; }

        protected async override Task OnInitializedAsync()
        {
            var saleDtos = await Service.GetSales();
            var discountDtos = await Service.GetDiscounts(true);

            Sales = Sale.CreateSales(saleDtos, discountDtos);
        }
    }
}
