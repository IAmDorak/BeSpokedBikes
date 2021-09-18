using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeSpokedBikes.Data.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public SalesPerson SalesPerson { get; set; }
        public int SalesPersonId { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
