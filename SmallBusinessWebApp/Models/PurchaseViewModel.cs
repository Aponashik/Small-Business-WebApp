using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmallBusinessWebApp.Models.Models;

namespace SmallBusinessWebApp.Models
{
    public class PurchaseViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Bill_No { get; set; }
        [Required]
        public string Manufacture_Date { get; set; }
        [Required]
        public string Expire_Date { get; set; }
        [Required]
        public int Quantity { get; set; }
        public double Unite_Price { get; set; }
        public double Total_Price { get; set; }
        public double Previous_Cost_Price { get; set; }
        public double Previous_Mrp { get; set; }
        [Required]
        public double New_Mrp { get; set; }

        public string Remarks { get; set; }
       

        [Required(ErrorMessage = "Please Select Product")]
        [Display(Name = "Product")]
        public int ProductId { get; set; }
        public IEnumerable<SelectListItem> ProductSelectListItem { get; set; }

        [Required(ErrorMessage = "Please Select Supplier")]
        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }
        public IEnumerable<SelectListItem> SupplierSelectListItem { get; set; }

        //public  List<Purchase> Purchases { get; set; }
        public  List<Product>Products { get; set; }

    }
}