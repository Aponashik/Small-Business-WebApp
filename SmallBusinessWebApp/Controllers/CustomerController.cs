using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SmallBusinessWebApp.BLL.Manager;
using SmallBusinessWebApp.Models;
using SmallBusinessWebApp.Models.Models;

namespace SmallBusinessWebApp.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager customerManager = new CustomerManager();
        
        // GET: Customer
         [HttpGet]
        public ActionResult Add()
        {
            CustomerModelView customerVm = new CustomerModelView();
            return View(customerVm);
        }
        [HttpPost]
        public ActionResult Add(CustomerModelView customerVm)
        {

            if (ModelState.IsValid)
            {
                var customer = Mapper.Map<Customer>(customerVm);
                if (customerManager.Add(customer))
                {
                    ViewBag.SuccessMsg = "Customer Added";
                }
                else
                {
                    ViewBag.FailMsg = "Failed";
                }
            }
            else
            {
                ViewBag.FailMsg = "Upps!Something Wrong";
            }
            return View(customerVm);
        }



        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Customer customer = new Customer();
            customer.Id = Id;
            customer = customerManager.GetById(Id);

            CustomerModelView customerVm = new CustomerModelView();
            customerVm = Mapper.Map<CustomerModelView>(customer);
            return View(customerVm);
        }
        [HttpPost]
        public ActionResult Edit(CustomerModelView customerVm)
        {
            if (ModelState.IsValid)
            {
                var customer= Mapper.Map<Customer>(customerVm);
                if (customerManager.Update(customer))
                {
                    ViewBag.SuccessMsg = "Updated";
                }
                else
                {
                    ViewBag.FailMsg = "Failed";
                }
            }
            else
            {
                ViewBag.FailMsg = "Upps!Something Wrong";
            }
            return View(customerVm);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            CustomerModelView customerVm = new CustomerModelView();
            Customer customer = new Customer();
            customer = customerManager.GetById(Id);

            customerVm = Mapper.Map<CustomerModelView>(customer);

            return View(customerVm);
        }
        [HttpPost]
        public ActionResult Delete(CustomerModelView customerVm)
        {


            if (ModelState.IsValid)
            {
                var cutomer = Mapper.Map<Customer>(customerVm);

                if (customerManager.Delete(cutomer))
                {
                    ViewBag.SuccessMsg = "Deleted!";
                }
                else
                {
                    ViewBag.ErrorMsg = "Failed!";
                }
            }
            else
            {
                ViewBag.ErrorMsg = "Validation!";
            }

           
            return RedirectToAction("Show", "Customer");

        }

        [HttpGet]
        public ActionResult Show()
        {
            CustomerModelView customerVm = new CustomerModelView();
            customerVm.Customers = customerManager.GetAll();
           
            
            return View(customerVm);
        }
        [HttpPost]
        public ActionResult Show(CustomerModelView customerVm)
        {
            var customers = customerManager.GetAll();
            if (customerVm.Code != null)
            {
                customers = customers.Where(c => c.Code.ToLower().Contains(customerVm.Code.ToLower())).ToList();
            }

            if (customerVm.CustomerName != null)
            {
                customers = customers.Where(c => c.CustomerName.ToLower().Contains(customerVm.CustomerName.ToLower())).ToList();
            }

            if (customerVm.Email != null)
            {
                customers = customers.Where(c => c.Email.ToLower().Contains(customerVm.Email.ToLower())).ToList();
            }
            customerVm.Customers = customers;

            return View(customerVm);
        }

    }
}