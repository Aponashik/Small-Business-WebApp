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
    public class SupplierRepository
    {
        SmallBusinessDbContext db = new SmallBusinessDbContext();

        public bool Add(Supplier supplier)
        {
            int isExecuted = 0;
            db.Suppliers.Add(supplier);
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
                return true;
            return false;
        }

        public bool Delete(Supplier supplier)
        {
            int isExecuted = 0;
            Supplier asupplier = db.Suppliers.FirstOrDefault(c => c.Id == supplier.Id);
            if (asupplier != null)
            {
                db.Suppliers.Remove(asupplier);
                isExecuted = db.SaveChanges();
            }
            if (isExecuted > 0)
                return true;
            return false;
        }

        public Supplier GetById(int Id)
        {
            Supplier asupplier= db.Suppliers.FirstOrDefault(c => c.Id ==Id);
            return asupplier;
        }
        public bool Update(Supplier supplier)
        {
            int isExecuted = 0;
            db.Entry(supplier).State = EntityState.Modified;
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
                return true;
            return false;
        }

        public List<Supplier> GetAll()
        {
            return db.Suppliers.ToList();
        }
    }
}
