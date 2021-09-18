using System;

namespace BeSpokedBikes.Shared.Models
{
    public class DiscountDto
    {
        public int Id { get; set; }
        public ProductDto Product { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public double DiscountPercentage { get; set; }
    }
}
