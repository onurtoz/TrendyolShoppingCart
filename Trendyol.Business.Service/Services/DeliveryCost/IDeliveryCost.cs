using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Business.Service.Services.ShoppingService;

namespace Trendyol.Business.Service.Services.DeliveryCost
{
    public interface IDeliveryCost
    {
        double CalculateDeliveryCost(IShoppingCart shoppingCart);
    }
}
