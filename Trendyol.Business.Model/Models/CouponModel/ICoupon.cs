using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trendyol.Business.Model.Models.CouponModel
{
   public interface  ICoupon
    {
         bool IsApplicable(double amount);
        double getDiscount(double totalAmount);

    }
}
