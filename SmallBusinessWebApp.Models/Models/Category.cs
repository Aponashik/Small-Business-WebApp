using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallBusinessWebApp.Models.Models
{
    public class Category
    {
        public Category()
        {
            Categories = new List<Category>();
        }
        public int Id { get; set; }
        [Required]
        
        public string Code { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [NotMapped]
        public  List<Category> Categories { get; set; }
    }
}
