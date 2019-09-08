using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SmallBusinessWebApp.Models.Models;

namespace SmallBusinessWebApp.Models
{
    public class CategoryModelView
    {
        public int Id { get; set; }
        [Required]

        public string Code { get; set; }
        
        [Required(ErrorMessage = "Please Enter Name")]
        public string CategoryName { get; set; }
        
        public List<Category> Categories { get; set; }
    }
}