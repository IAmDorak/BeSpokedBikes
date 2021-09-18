using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeSpokedBikes.Data.Entities
{
    public class Product
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
