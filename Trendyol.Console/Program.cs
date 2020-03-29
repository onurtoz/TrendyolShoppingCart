using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Business.Model.Models.CampaignModel;
using Trendyol.Business.Model.Models.CategoryModel;
using Trendyol.Business.Model.Models.CouponModel;
using Trendyol.Business.Model.Models.ProductModel;
using Trendyol.Business.Service.Services.DeliveryCost;
using Trendyol.Business.Service.Services.ShoppingService;

namespace Trendyol.Console
{
    class Program
    {
        static void Main(string[] args)
        {
          
            Category category1 = new Category("category1");
            Category category2 = new Category("category2");
         

            Product product1 = new Product("Product1", 100, category1);
            Product product2 = new Product("Product2", 50, category1);
            Product product3 = new Product("Product3", 40, category2);
        


            ICampaign rateCampaign = new RateCampaign(20.0, 5, category1);
            ICampaign amountCampaing = new AmountCampaign(10.0, category2);

            IShoppingCart shoppingcart = new ShoppingCart(new DeliveryCost(1.5, 10));

            shoppingcart.AddProduct(product1, 12);
            shoppingcart.AddProduct(product2, 10); 
            shoppingcart.AddProduct(product3, 11); 
  
            List<ICampaign> campaigns = new List<ICampaign>();
            campaigns.Add(rateCampaign);
            campaigns.Add(amountCampaing);
            ICoupon rateCoupon = new RateCoupon(5.0, 3);
            shoppingcart.AddCampaign(campaigns);
            shoppingcart.AddCoupon(rateCoupon);
            double totalAmount = shoppingcart.GetTotalAmountAfterDiscounts();

            System.Console.WriteLine(shoppingcart.Print());
            System.Console.ReadLine();


        }
    }
}
