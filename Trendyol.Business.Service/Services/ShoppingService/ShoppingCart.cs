//using ConsoleTables;
using ConsoleTables;
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


namespace Trendyol.Business.Service.Services.ShoppingService
{
    public class ShoppingCart : IShoppingCart
    {
        public Dictionary<Product, int> Products { get; set; }
        public List<ICampaign> Campaigns { get; set; }
        public ICoupon coupon;
        public ICampaign campaign;
        private IDeliveryCost deliveryCost { get; set; }

        public ShoppingCart(IDeliveryCost _deliveryCost)
        {
           
            this.deliveryCost = _deliveryCost;
            Campaigns = new List<ICampaign>();
            Products = new Dictionary<Product, int>();
           
        }

        public double GetTotalAmount()
        {
            return Products.Sum(e => e.Key.ProductPrice * e.Value);
        }

        public void AddCoupon(ICoupon _coupon)
        {
            this.coupon = _coupon;
        }

        public void AddCampaign(List<ICampaign> _campaign)
        {
            Campaigns.AddRange(_campaign);
        }
        public void AddProduct(Product product, int amount)
        {
            if(amount <= 0){ throw new ArgumentNullException("invalid amount: " + amount); }
            if (product == null){ throw new ArgumentNullException("product is null: ");}
            if (Products.TryGetValue(product, out int value))
            {
                Products[product] = value + amount;
                return;
            }

            Products.Add(product, amount);

        }

        public double GetDeliveryCost()
        {
            return deliveryCost.CalculateDeliveryCost(this);
        }
        private double GetProductPrice(Product product)
        {
            if (Products.TryGetValue(product, out int quantity))
            {
                return product.ProductPrice * quantity;
            }
            throw new KeyNotFoundException(nameof(product));

        }

        private double ApplyCampaign(double amount)
        {
            double discountAmount = 0;
            double totalproductQuantity = 0;
            foreach (var campaign in Campaigns)
            {
               
                Dictionary<Product, int> product = GetProductsByCategory(campaign.getCategory());

                foreach (var productQuantity in product.Values)
                {
                    totalproductQuantity += productQuantity;
                }

                if (campaign.IsApplicable(totalproductQuantity))
                {
                    if (discountAmount == 0)
                    {
                        discountAmount = discountAmount + campaign.getDiscount(amount);
                    }
                    else
                    {
                        discountAmount = campaign.getDiscount(discountAmount);
                    }
              
                    totalproductQuantity = 0;
                }
            }

            return discountAmount;
        }


        private double ApplyCoupon(double amount)
        {
            double discountAmount = 0;

            if (coupon.IsApplicable(amount))
            {
                discountAmount = amount - coupon.getDiscount(amount);
               
            }
            return discountAmount;
        }


        private Dictionary<Product, int> GetProductsByCategory(Category category)
        {
            return Products.Where(e => e.Key.Category == category).ToDictionary(e => e.Key, e => e.Value);
        }

        public double GetTotalAmountAfterDiscounts()
        {
            double amount = GetTotalAmount();
            amount = GetCampaignDiscount(amount);
            amount = GetCouponDiscount(amount);
            return amount;
        }

        public int NumberofDeliveries()
        {
            return Products.Count();
        }

        public int NumberOfProducts()
        {
            return Products.GroupBy(x => x.Key.Title).Count();
        }

       
        private double GetTotalDiscount()
        {
            return GetTotalAmount() - GetTotalAmountAfterDiscounts();
        }

        public double GetCampaignDiscount(double amount)
        {
            return ApplyCampaign(amount);
        }

        public double GetCouponDiscount(double amount)
        {
            return ApplyCoupon(amount); 
        }

        public string Print()
        {
           
            var products = Products.GroupBy(p => p.Key.Category.Title).ToDictionary(e => e.Key, e => e.ToList());
            var table1 = new ConsoleTable("Category Name", "Product Name", "Quantity", "Unit Price", "Total Price");
            foreach (var product in products)
            {
                foreach (var p in product.Value)
                {
                    table1.AddRow(product.Key, p.Key.Title, p.Value, p.Key.ProductPrice, GetProductPrice(p.Key));
                   
                }
            }
            var table2  = new ConsoleTable("Total Amount", "Total Amount After Discounts", "Total Discount");
            table2.AddRow(GetTotalAmount(), GetTotalAmountAfterDiscounts(), GetTotalDiscount());

            return table1.ToString()+ table2.ToString();
        }
    }
}
