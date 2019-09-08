using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SmallBusinessWebApp.Models.Models;

namespace SmallBusinessWebApp.Models
{
    public class CustomerModelView
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        public string CustomerName { get; set; }
        [Required]
        public string Address { get; set; }
        [RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Please enter a valid email address")]
        [Required(ErrorMessage = "Please Enter Name")]
        public string Email { get; set; }
        [Required]
        public string Contact { get; set; }
        public int LoyaltyPoint { get; set; }
        
        public List<Customer> Customers { get; set; }

        //public byte Image { get; set; }
    }
}