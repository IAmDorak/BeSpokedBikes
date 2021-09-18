using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BeSpokedBikes.Shared.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacture { get; set; }
        public string Style { get; set; }
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }
        public int QtyOnHand { get; set; }
        public double CommissionPercentage { get; set; }
    }
}
