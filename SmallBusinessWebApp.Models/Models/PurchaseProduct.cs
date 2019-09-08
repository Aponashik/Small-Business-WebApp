using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallBusinessWebApp.Models.Models
{
    public class PurchaseProduct
    {
        public int ID { get; set; }
        public string InvoiceNo { get; set; }
        public string ProductCode { get; set; }
        public string ManufacturedDate { get; set; }
        public string ExpireDate { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int TotalPrice { get; set; }
        public int NewMRP { get; set; }
        public string Remarks { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
