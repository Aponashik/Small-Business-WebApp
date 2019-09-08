using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmallBusinessWebApp.Models.Models;
using System.ComponentModel.DataAnnotations;

namespace SmallBusinessWebApp.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(50, MinimumLength = 4)]
        public string ProductName { get; set; }

        public int ReorderLevel { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Please Select Category")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        
        //public byte Image { get; set; }

        public IEnumerable<SelectListItem> CategorySelectListItem { get; set; }

       
        public List<Product> Products { get; set; }
    }
}