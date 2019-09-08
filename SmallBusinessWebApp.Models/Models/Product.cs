using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SmallBusinessWebApp.Models.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(50, MinimumLength = 4)]
        public string ProductName { get; set; }
        [Required]
        public int ReorderLevel { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Please Select Category")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
       
        //public byte Image { get; set; }  

    }
}
