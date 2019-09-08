using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmallBusinessWebApp.Databse.DatabseContext;
using SmallBusinessWebApp.Models.Models;

namespace SmallBusinessWebApp.Repository.Repository
{
    public  class ProductRepository
    {
        SmallBusinessDbContext db = new SmallBusinessDbContext();

        public bool Add(Product product)
        {
            int isExecuted = 0;
            db.Products.Add(product);
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
                return true;
            return false;
        }
        public bool Delete(Product product)
        {
            int isExecuted = 0;
            Product aproduct = db.Products.FirstOrDefault(c => c.Id == product.Id);
            
                db.Products.Remove(aproduct);
                isExecuted = db.SaveChanges();
            
           
               
            
            if (isExecuted > 0)
                return true;
            return false;
        }
        public Product GetById(int Id)
        {
            Product product = new Product();

            product = db.Products.FirstOrDefault(c => c.Id == Id);
            return product;

            //Product aproduct = db.Products.FirstOrDefault(c => c.Id == Id);
            //return aproduct;
        }
        public bool Update(Product product)
        {
            int isExecuted = 0;
            db.Entry(product).State = EntityState.Modified;
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }
            return false;
        }

        

        public List<Product> GetAll()
        {
            return db.Products.Include(c => c.Category).ToList();
        }
    }
}
