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
    public class ProductController : Controller
    {
        CategoryManager categoryManager = new CategoryManager();
        ProductManager productManager = new ProductManager();
       


        // GET: Product
        [HttpGet]
        public ActionResult Index()
        {
            ProductViewModel productVm = new ProductViewModel();
            productVm.CategorySelectListItem = categoryManager.GetAll()
                .Select(c=>new SelectListItem() {
                    Value=c.Id.ToString(),Text=c.CategoryName
                })
                .ToList();

           
            return View(productVm);
        }
        [HttpPost]
        public ActionResult Index(ProductViewModel productVm)
        {
            if (ModelState.IsValid) {
                var product = Mapper.Map<Product>(productVm);
                if (productManager.Add(product))
                {
                    ViewBag.SuccessMsg = "Saved";
                }
                else
                {
                    ViewBag.FailMsg = "Failed";
                }
            }
            else ViewBag.FailMsg = "Error";
            productVm.CategorySelectListItem = categoryManager.GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.CategoryName
                })
                .ToList();




           
            return View(productVm);
        }

        [HttpGet]
        public ActionResult Show()
        {
            ProductViewModel productVm = new ProductViewModel();

            productVm.Products = productManager.GetAll();
            productVm.CategorySelectListItem = categoryManager.GetAll().ToList()
            
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.CategoryName
                });
            return View(productVm);

            //product.Products = productManager.GetAll();
            //return View(product);
        }
        [HttpPost]
        public ActionResult Show(ProductViewModel productVm)
        {

            var products = productManager.GetAll();
            if (productVm.Code != null)
            {
                products = products.Where(c => c.Code.ToLower().Contains(productVm.Code.ToLower())).ToList();
            }

            if (productVm.ProductName != null)
            {
                products = products.Where(c => c.ProductName.ToLower().Contains(productVm.ProductName.ToLower())).ToList();
            }


            productVm.Products = products;
            productVm.CategorySelectListItem = categoryManager.GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.CategoryName
                });
            return View(productVm);
           
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            ProductViewModel productViewModel = new ProductViewModel();
            Product product = new Product();

            product = productManager.GetById(Id);

            productViewModel = Mapper.Map<ProductViewModel>(product);

            productViewModel.CategorySelectListItem = categoryManager.GetAll()
                .Select(c => new SelectListItem()
                {
                    Value=c.Id.ToString(),Text=c.CategoryName
                });

       return View(productViewModel); 
        }


        [HttpPost]
        public ActionResult Delete(ProductViewModel productViewModel)
        {
           

            if (ModelState.IsValid)
            {
                var product = Mapper.Map<Product>(productViewModel);

                if (productManager.Delete(product))
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

            productViewModel.CategorySelectListItem = categoryManager.GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.CategoryName
                });
            return RedirectToAction("Show", "Product");

        }


        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Product product = new Product();
            product.Id = Id;
            product = productManager.GetById(Id);

            ProductViewModel productVm = new ProductViewModel();
            productVm = Mapper.Map<ProductViewModel>(product);

            productVm.CategorySelectListItem = categoryManager.GetAll()
                .Select(c => new SelectListItem()
                {
                    Value=c.Id.ToString(),
                    Text=c.CategoryName
                });
                

            
            return View(productVm);

        }
        [HttpPost]
        public ActionResult Edit(ProductViewModel productVmedit)
        {
           

            if (ModelState.IsValid)
            {
                var product = Mapper.Map<Product>(productVmedit);
                if (productManager.Update(product))
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
            productVmedit.CategorySelectListItem = categoryManager.GetAll()
                .Select(c => new SelectListItem()
                {
                    Value=c.Id.ToString(),
                    Text=c.CategoryName
                });
            return View(productVmedit);
        }

        public ActionResult getProductCode(int ProductId)
        {
            var product = productManager.GetById(ProductId);

            return Json(product, JsonRequestBehavior.AllowGet);
        }
    }
}