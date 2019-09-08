using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmallBusinessWebApp.Models.Models;
using SmallBusinessWebApp.Repository.Repository;

namespace SmallBusinessWebApp.BLL.Manager
{
    public class PurchaseManager
    {
        PurchaseRepository purchaseRepository = new PurchaseRepository();
        public bool Add(List<PurchaseProduct> purchaseProducts)
        {
            return purchaseRepository.Add(purchaseProducts);
        }

        public List<PurchaseProduct> GetProductQ(int ProductId)
        {
            return purchaseRepository.GetProductQ(ProductId);
        }
    }
}
