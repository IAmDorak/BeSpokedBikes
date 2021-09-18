using BeSpokedBikes.App.Services;
using BeSpokedBikes.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpokedBikes.App.Pages
{
    public partial class CustomersView
    {
        [Inject]
        public IBeSpokedBikesService Service { get; set; }
        public IEnumerable<CustomerDto> Customers { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Customers = await Service.GetCustomers();
        }
    }
}
