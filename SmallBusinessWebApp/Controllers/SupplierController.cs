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
    public class SupplierController : Controller
    {
        SupplierManager supplierManager = new SupplierManager();
       
        // GET: Supplier
        [HttpGet]
        public ActionResult Add()
        {
            SupplierModelView supplierVm = new SupplierModelView();
            return View(supplierVm);
        }
        [HttpPost]
        public ActionResult Add(SupplierModelView supplierVm)
        {

            if (ModelState.IsValid)
            {
                var supplier= Mapper.Map<Supplier>(supplierVm);

                if (supplierManager.Add(supplier))
                {
                    ViewBag.SuccessMsg = "Supplier Added";
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
            return View(supplierVm);
        }
        

        [HttpGet]
        public ActionResult Show()
        {
            SupplierModelView supplierVm = new SupplierModelView();
            supplierVm.Suppliers = supplierManager.GetAll();


            return View(supplierVm);
        }
        [HttpPost]
        public ActionResult Show(SupplierModelView supplierVm)
        {
            var suppliers = supplierManager.GetAll();
            if (supplierVm.Code != null)
            {
                suppliers = suppliers.Where(c => c.Code.ToLower().Contains(supplierVm.Code.ToLower())).ToList();
            }

            if (supplierVm.SupplierName != null)
            {
                suppliers = suppliers.Where(c => c.SupplierName.ToLower().Contains(supplierVm.SupplierName.ToLower())).ToList();
            }

            if (supplierVm.Email != null)
            {
                suppliers = suppliers.Where(c => c.Email.ToLower().Contains(supplierVm.Email.ToLower())).ToList();
            }
            supplierVm.Suppliers = suppliers;

            return View(supplierVm);
        }


        [HttpGet]
        public ActionResult Delete(int Id)
        {
            SupplierModelView supplierVm = new SupplierModelView();
            Supplier supplier = new Supplier();
            supplier = supplierManager.GetById(Id);

            supplierVm = Mapper.Map<SupplierModelView>(supplier);

            return View(supplierVm);
        }
        [HttpPost]
        public ActionResult Delete(SupplierModelView supplierVm)
        {


            if (ModelState.IsValid)
            {
                var supplier = Mapper.Map<Supplier>(supplierVm);

                if (supplierManager.Delete(supplier))
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


            return RedirectToAction("Show", "Supplier");

        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Supplier supplier = new Supplier();
            supplier.Id = Id;
            supplier = supplierManager.GetById(Id);

            SupplierModelView supplierVm = new SupplierModelView();
            supplierVm = Mapper.Map<SupplierModelView>(supplier);
            return View(supplierVm);
        }
        [HttpPost]
        public ActionResult Edit(SupplierModelView supplierVm)
        {
            if (ModelState.IsValid)
            {
                var supplier = Mapper.Map<Supplier>(supplierVm);
                if (supplierManager.Update(supplier))
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

            
            return View(supplierVm);
        }



    }
}