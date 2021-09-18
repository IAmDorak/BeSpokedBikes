using BeSpokedBikes.App.Services;
using BeSpokedBikes.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpokedBikes.App.Pages
{
    public partial class SalesPersonEditView
    {
        [Inject]
        public IBeSpokedBikesService Service { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        public SalesPersonUpdateDto UpdateSalesPerson { get; set; } = new SalesPersonUpdateDto();

        //used for failure messages.
        protected string Message = string.Empty;
        protected bool Failed = false;

        protected async override Task OnInitializedAsync()
        {
            var salesPerson = await Service.GetSalesPerson(int.Parse(Id));
            UpdateSalesPerson = new SalesPersonUpdateDto()
            {
                FirstName = salesPerson.FirstName,
                LastName = salesPerson.LastName,
                Address = salesPerson.Address,
                Phone = salesPerson.Phone,
                TerminationDate = salesPerson.TerminationDate,
                Manager = salesPerson.Manager
            };
        }

        protected async Task HandleValidSubmit()
        {
            Failed = false;
            var passed = await Service.UpdateSalesPerson(int.Parse(Id), UpdateSalesPerson);

            if (passed)
            {
                NavigationManager.NavigateTo("/salespersons");
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

        protected void NavigateToSalesPersons()
        {
            NavigationManager.NavigateTo("/salespersons");
        }

        protected async void ReinstateSalesPerson()
        {
            UpdateSalesPerson.TerminationDate =  null;
            await HandleValidSubmit();
        }
    }
}
