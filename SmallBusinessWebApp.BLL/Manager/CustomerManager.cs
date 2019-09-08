using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmallBusinessWebApp.Models.Models;
using SmallBusinessWebApp.Repository.Repository;

namespace SmallBusinessWebApp.BLL.Manager
{
    public class CustomerManager
    {
        CustomerRepository customerRepository = new CustomerRepository();

        public bool Add(Customer customer)
        {
            return customerRepository.Add(customer);
        }

        public bool Delete(Customer customer)
        {
            return customerRepository.Delete(customer);
        }
        public Customer GetById(int Id)
        {
            return customerRepository.GetById(Id);
        }
        public bool Update(Customer customer)
        {
            return customerRepository.Update(customer);
        }
        public List<Customer> GetAll()
        {
            return customerRepository.GetAll();
        }
    }
}
