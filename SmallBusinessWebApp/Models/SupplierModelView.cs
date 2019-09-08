using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SmallBusinessWebApp.Models.Models;

namespace SmallBusinessWebApp.Models
{
    public class SupplierModelView
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        public string SupplierName { get; set; }
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [Required]
        public string Contact { get; set; }
        public string ContactPerson { get; set; }
       
        public List<Supplier> Suppliers { get; set; }

    }
}