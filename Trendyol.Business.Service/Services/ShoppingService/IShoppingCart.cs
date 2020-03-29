using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Business.Model.Models.CampaignModel;
using Trendyol.Business.Model.Models.CouponModel;
using Trendyol.Business.Model.Models.ProductModel;

namespace Trendyol.Business.Service.Services.ShoppingService
{
    public interface IShoppingCart
    {
        double GetTotalAmountAfterDiscounts();
        double GetCouponDiscount(double totalamount);
        double GetCampaignDiscount(double totalamount);
        double GetDeliveryCost();
        int NumberOfProducts();
        int NumberofDeliveries();
        void AddProduct(Product product, int amaount);
        void AddCoupon(ICoupon coupon);
        void AddCampaign(List<ICampaign> campaign);
        double GetTotalAmount();
        string Print();
     


    }
}
