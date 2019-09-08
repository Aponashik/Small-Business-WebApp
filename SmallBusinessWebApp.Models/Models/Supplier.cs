using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallBusinessWebApp.Models.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string SupplierName { get; set; }
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [Required]
        public string Contact { get; set; }
        public string ContactPerson { get; set; }
       

        //public byte Image { get; set; }
    }
}
