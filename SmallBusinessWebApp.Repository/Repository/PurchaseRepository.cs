using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmallBusinessWebApp.Databse.DatabseContext;
using SmallBusinessWebApp.Models.Models;

namespace SmallBusinessWebApp.Repository.Repository
{
    public class PurchaseRepository
    {
        SmallBusinessDbContext db = new SmallBusinessDbContext();
        public bool Add(List<PurchaseProduct> purchaseProducts)
        {
            int isExecuted = 0;
            db.PurchaseProducts.AddRange(purchaseProducts);
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
                return true;
            return false;
        }

        public List<PurchaseProduct> GetProductQ(int ProductId)
        {
            return db.PurchaseProducts.Where(c => c.ProductId == ProductId).ToList();
        }
    }
}
