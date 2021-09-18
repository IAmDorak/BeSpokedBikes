using System;

namespace BeSpokedBikes.Shared.Models
{
    public class SaleDto
    {
        public int Id { get; set; }
        public ProductDto Product { get; set; }
        public SalesPersonDto SalesPerson { get; set; }
        public CustomerDto Customer { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
