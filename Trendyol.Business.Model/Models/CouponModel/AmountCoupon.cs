using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trendyol.Business.Model.Models.CouponModel
{
    public class AmountCoupon : ICoupon
    {
        private double minumunAmount;
        private double discountAmount;

        public AmountCoupon(double _minumunAmount,double _discountAmount)
        {
            this.minumunAmount = _minumunAmount;
            this.discountAmount = _discountAmount;
        }

        public  bool IsApplicable(double amount)
        {
            return amount >= minumunAmount;
        }

        public  double getDiscount(double totalAmount)
        {
            return discountAmount;
        }

       
    }
}
