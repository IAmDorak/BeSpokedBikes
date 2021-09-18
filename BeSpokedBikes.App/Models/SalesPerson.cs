using BeSpokedBikes.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpokedBikes.App.Models
{
    public class SalesPerson
    {
        public SalesPersonDto OriginalSalesPerson { get; private set; }
        public int Id 
        { 
            get
            {
                return OriginalSalesPerson.Id;
            }
        }
        public string FirstName 
        {
            get 
            {
                return OriginalSalesPerson.FirstName;
            } 
        }
        public string LastName
        {
            get
            {
                return OriginalSalesPerson.LastName;
            }
        }
        public string Address
        {
            get
            {
                return OriginalSalesPerson.Address;
            }
        }
        public string Phone
        {
            get
            {
                return OriginalSalesPerson.Phone;
            }
        }
        public string StartDate
        {
            get
            {
                return OriginalSalesPerson.StartDate.ToShortDateString();
            }
        }
        public string TerminationDate
        {
            get
            {
                return (OriginalSalesPerson.TerminationDate.HasValue) ? OriginalSalesPerson.TerminationDate.Value.ToShortDateString() : "---";
            }
        }
        public string Manager
        {
            get
            {
                return OriginalSalesPerson.Manager;
            }
        }


        public SalesPerson (SalesPersonDto salesPerson)
        {
            OriginalSalesPerson = salesPerson;
        }
    }
}
