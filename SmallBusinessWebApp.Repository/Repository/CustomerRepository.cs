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
    public class CustomerRepository
    {
        SmallBusinessDbContext db = new SmallBusinessDbContext();

        public bool Add(Customer customer)
        {
            int isExecuted = 0;
            db.Customers.Add(customer);
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
                return true;
            return false;
        }

        public bool Delete(Customer customer)
        {
            int isExecuted = 0;
            Customer acustomer = db.Customers.FirstOrDefault(c => c.Id == customer.Id);
            if (acustomer != null)
            {
                db.Customers.Remove(acustomer);
                isExecuted = db.SaveChanges();
            }
            if (isExecuted > 0)
                return true;
            return false;
        }

        public Customer GetById(int Id)
        {
            Customer acustomer = db.Customers.FirstOrDefault(c => c.Id == Id);
            return acustomer;
        }
        public bool Update(Customer customer)
        {
            int isExecuted = 0;
            db.Entry(customer).State = EntityState.Modified;
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
                return true;
            return false;
        }

        public List<Customer> GetAll()
        {
            return db.Customers.ToList();
        }
    }
}
