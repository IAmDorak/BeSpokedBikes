using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpokedBikes.Shared.Models
{
    public class ProductUpdateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Manufacture { get; set; }
        [Required]
        public string Style { get; set; }
        [Required]
        public double PurchasePrice { get; set; }
        [Required]
        public double SalePrice { get; set; }
        [Required]
        public int QtyOnHand { get; set; }
        [Required]
        [Range(0, 1)]
        public double CommissionPercentage { get; set; }
    }
}
