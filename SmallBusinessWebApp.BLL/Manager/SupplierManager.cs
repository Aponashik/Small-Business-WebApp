using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmallBusinessWebApp.Models.Models;
using SmallBusinessWebApp.Repository.Repository;

namespace SmallBusinessWebApp.BLL.Manager
{
    public class SupplierManager
    {
        SupplierRepository supplierRepository = new SupplierRepository();

        public bool Add(Supplier supplier)
        {
            return supplierRepository.Add(supplier);
        }

        public bool Delete(Supplier supplier)
        {
            return supplierRepository.Delete(supplier);
        }
        public Supplier GetById(int Id)
        {
            return supplierRepository.GetById(Id);
        }
        public bool Update(Supplier supplier)
        {
            return supplierRepository.Update(supplier);
        }
        public List<Supplier> GetAll()
        {
            return supplierRepository.GetAll();
        }
    }
}
