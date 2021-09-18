using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpokedBikes.Shared.Models
{
    public class SalesCreationDto
    {
        [Required]
        public ProductDto Product { get; set; }
        [Required]
        public SalesPersonDto SalesPerson { get; set; }
        [Required]
        public CustomerDto Customer { get; set; }
        [Required]
        public DateTime SaleDate { get; set; }
    }
}
