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
    public partial class SalesPersonsView
    {
        [Inject]
        public IBeSpokedBikesService Service { get; set; }
        public IEnumerable<SalesPerson> SalesPersons { get; set; }

        protected async override Task OnInitializedAsync()
        {
            SalesPersons = (await Service.GetSalesPersons()).Select(sp => new SalesPerson(sp));
        }
    }
}
