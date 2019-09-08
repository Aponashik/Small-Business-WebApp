using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmallBusinessWebApp.Models.Models;
using SmallBusinessWebApp.Repository.Repository;

namespace SmallBusinessWebApp.BLL.Manager
{
   public class ProductManager
    {
        ProductRepository productRepository = new ProductRepository();

        public bool Add(Product product)
        {
            return productRepository.Add(product);
        }
        public bool Delete(Product product)
        {
            return productRepository.Delete(product);
        }
        public Product GetById(int Id)
        {
            return productRepository.GetById(Id);
        }
        public bool Update(Product product)
        {
            return productRepository.Update(product);
        }
        public List<Product> GetAll()
        {
            return productRepository.GetAll();
        }
    }
}
