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
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager();
        ProductManager productManager = new ProductManager();

        [HttpGet]
        public ActionResult Add()
        {
            CategoryModelView categoryVm = new CategoryModelView();

            return View();
        }
        [HttpPost]
        public ActionResult Add(CategoryModelView categoryVm)
        {

            if (ModelState.IsValid)

            {
                var category = Mapper.Map<Category>(categoryVm);
                if (categoryManager.Add(category))
                {
                    ViewBag.SuccessMsg = "Saved";
                }
                else
                {
                    ViewBag.FailMsg = "Failed";
                }
            }
            else
            {
                ViewBag.FailMsg = "Validation Error";
            }
            return View(categoryVm);
        }
        [HttpGet]
        public ActionResult Show()
        {
            CategoryModelView categoryVm = new CategoryModelView();
            categoryVm.Categories = categoryManager.GetAll();
           
            return View(categoryVm);
        }

        public ActionResult Show(CategoryModelView categoryVm)
        {

            var categories = categoryManager.GetAll();
            if (categoryVm.Code != null)
            {
                categories = categories.Where(c => c.Code.ToLower().Contains(categoryVm.Code.ToLower())).ToList();
            }

            if (categoryVm.CategoryName != null)
            {
                categories = categories.Where(c => c.CategoryName.ToLower().Contains(categoryVm.CategoryName.ToLower())).ToList();
            }


            categoryVm.Categories = categories;
           
            return View(categoryVm);

        }


        [HttpGet]
        public ActionResult Delete(int Id)
        {
            CategoryModelView categoryVm = new CategoryModelView();
            Category category = new Category();

            category = categoryManager.GetById(Id);

            categoryVm = Mapper.Map<CategoryModelView>(category);





            return View(categoryVm);
        }


        [HttpPost]
        public ActionResult Delete(CategoryModelView categoryVm)
        {


            if (ModelState.IsValid)
            {
                var category = Mapper.Map<Category>(categoryVm);

                if (categoryManager.Delete(category))
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


            return RedirectToAction("Show", "Category");

        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Category category = new Category();
            category.Id = Id;
            category = categoryManager.GetById(Id);

            CategoryModelView categoryVm = new CategoryModelView();
            categoryVm = Mapper.Map<CategoryModelView>(category);

            return View(categoryVm);

        }
        [HttpPost]
        public ActionResult Edit(CategoryModelView categoryVm)
        {
            if (ModelState.IsValid)
            {
                var category = Mapper.Map<Category>(categoryVm);
                if (categoryManager.Update(category))
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
                ViewBag.FailMsg = "Validation Error";
            }
            return View(categoryVm);
        }


        

        

    }

}