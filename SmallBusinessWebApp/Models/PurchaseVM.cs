using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmallBusinessWebApp.Models.Models;

namespace SmallBusinessWebApp.Models
{
    public class PurchaseVM
    {
        public List<Supplier> Suppliers { get; set; }
        public List<Product> Products { get; set; }
        //public Invoice Invoice { get; set; }
        public List<PurchaseProduct> PurchaseProducts { get; set; }
    }
}