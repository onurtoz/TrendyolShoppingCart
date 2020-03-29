using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Business.Model.Models.CategoryModel;

namespace Trendyol.Business.Model.Models.CampaignModel
{
    public class RateCampaign : ICampaign
    {
        
        private double minProductQuantity;
        private double rate;
        public Category category;

        public RateCampaign(double _minProductQuantity,double _rate,Category _category)
        {
            this.minProductQuantity = _minProductQuantity;
            this.rate = _rate;
            this.category = _category;
        }
        public  bool IsApplicable(double productQuantity)
        {
            return productQuantity >= minProductQuantity;
        }

        public  double getDiscount(double totalPrice)
        {
            return totalPrice * (rate * 0.1);
        }

        public Category getCategory()
        {
            return this.category;
        }
    }
}
