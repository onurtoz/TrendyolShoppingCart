using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Business.Service.Services.ShoppingService;

namespace Trendyol.Business.Service.Services.DeliveryCost
{
   public class DeliveryCost : IDeliveryCost
    {
        public double CostPerDelivery { get; set; }
        public double CostPerProduct { get; set; }
        private const double FixedCost = 2.99;
        public DeliveryCost(double _costperdelivery ,double _costperproduct)
        {
            this.CostPerDelivery = _costperdelivery;
            this.CostPerProduct = _costperproduct;
        }

        public double CalculateDeliveryCost(IShoppingCart shoppingCart)
        {
            if (shoppingCart == null) { throw new ArgumentNullException(); }
            int numberOfDeliveries = shoppingCart.NumberofDeliveries();
            int numberOfProducts = shoppingCart.NumberOfProducts();
            return (CostPerDelivery * numberOfDeliveries) + (CostPerProduct * numberOfProducts) + FixedCost;
        }
    }
}
