using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Business.Model.Models.CategoryModel;

namespace Trendyol.Business.Model.Models.CampaignModel
{
   public interface ICampaign
    {
        
        bool IsApplicable(double productQuantity);
        double getDiscount(double totalPrice);
        Category getCategory();
    }
}
