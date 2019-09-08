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
    public class PurchaseController : Controller
    {
        PurchaseManager purchaseManager = new PurchaseManager();
        ProductManager productManager = new ProductManager();
        SupplierManager supplierManager = new SupplierManager();
        PurchaseVM purchaseVM = new PurchaseVM();


        // GET: Purchase
        [HttpGet]
        public ActionResult Add()
        {
           

            purchaseVM.Suppliers = supplierManager.GetAll();
            purchaseVM.Products = productManager.GetAll();
            return View(purchaseVM);

            //purchaseVm.SupplierSelectListItem = supplierManager.GetAll()
            //    .Select(c => new SelectListItem()
            //    {
            //        Value = c.Id.ToString(),
            //        Text = c.SupplierName
            //    })
            //    .ToList();

            //purchaseVm.ProductSelectListItem = productManager.GetAll()
            //   .Select(c => new SelectListItem()
            //   {
            //       Value = c.Id.ToString(),
            //       Text = c.ProductName
            //   })
            //   .ToList();

            //return View(purchaseVm);
        }
        [HttpPost]
        public ActionResult Add(PurchaseVM purchaseVm)
        {

            //_invoiceManager.Add(purchaseVM.Invoice);
            purchaseManager.Add(purchaseVm.PurchaseProducts);

            purchaseVM.Suppliers = supplierManager.GetAll();
            purchaseVM.Products = productManager.GetAll();
            //if (ModelState.IsValid)
            //{
            //    var purchase = Mapper.Map<PurchaseProduct>(purchaseVm);
            //    if (purchaseManager.Add(purchase))
            //    {
            //        ViewBag.SuccessMsg = "Saved";
            //    }
            //    else
            //    {
            //        ViewBag.FailMsg = "Failed";
            //    }
            //}
            //else ViewBag.FailMsg = "Error";
            //purchaseVm.SupplierSelectListItem = supplierManager.GetAll()
            //    .Select(c => new SelectListItem()
            //    {
            //        Value = c.Id.ToString(),
            //        Text = c.SupplierName
            //    })
            //    .ToList();

            //purchaseVm.ProductSelectListItem = productManager.GetAll()
            //  .Select(c => new SelectListItem()
            //  {
            //      Value = c.Id.ToString(),
            //      Text = c.ProductName
            //  })
            //  .ToList();
            return View(purchaseVm);
        }

        public ActionResult GetProductQ(int ProductId)
        {
            var products = purchaseManager.GetProductQ(ProductId);

            return Json(products);
        }
    }
}