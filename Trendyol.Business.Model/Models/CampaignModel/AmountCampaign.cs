using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Business.Model.Models.CategoryModel;

namespace Trendyol.Business.Model.Models.CampaignModel
{
    public class AmountCampaign : ICampaign
    {

        private double minProductQuantity;
        public Category category;

        public AmountCampaign(double _minProductQuantity,Category _category)
        {
            this.minProductQuantity = _minProductQuantity;
            this.category = _category;
           
        }
       
        public  bool IsApplicable(double productQuantity)
        {
            return productQuantity >= minProductQuantity;
        }

        public  double getDiscount(double totalPrice)
        {
            return totalPrice - 5;
        }

        public Category getCategory()
        {
            return this.category;
        }
    }
}
