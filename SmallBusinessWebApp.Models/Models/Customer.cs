using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallBusinessWebApp.Models.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string Address { get; set; }
        [RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [Required]
        public string Contact { get; set; }
        public int LoyaltyPoint { get; set; }
        

        //public byte Image { get; set; }
    }
}
