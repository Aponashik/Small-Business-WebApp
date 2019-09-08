using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using SmallBusinessWebApp.Models;
using SmallBusinessWebApp.Models.Models;

namespace SmallBusinessWebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Mapper.Initialize(cfg=> {
                cfg.CreateMap<ProductViewModel, Product>();
                cfg.CreateMap<Product, ProductViewModel>();

                cfg.CreateMap<CategoryModelView, Category>();
                cfg.CreateMap<Category, CategoryModelView>();

                cfg.CreateMap<CustomerModelView, Customer>();
                cfg.CreateMap<Customer, CustomerModelView>();

                cfg.CreateMap<SupplierModelView, Supplier>();
                cfg.CreateMap<Supplier, SupplierModelView>();

                cfg.CreateMap<PurchaseVM, PurchaseProduct>();
                cfg.CreateMap<PurchaseProduct, PurchaseVM>();

            });

        }
    }
}
