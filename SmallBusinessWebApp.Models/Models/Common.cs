using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallBusinessWebApp.Models.Models
{
    public class Common
    {
        [NotMapped]
        public List<Category> Categories { get; set; }
        [NotMapped]
        public List<Product> Products { get; set; }
        [NotMapped]
        public Product Product { get; set; }
        [NotMapped]
        public Category Category { get; set; }
        [NotMapped]
        public List<Customer> Customers { get; set; }
        [NotMapped]
        public Customer Customer { get; set; }
        [NotMapped]
        public List<Supplier> Suppliers { get; set; }
        [NotMapped]
        public Supplier Supplier { get; set; }
    }
}
