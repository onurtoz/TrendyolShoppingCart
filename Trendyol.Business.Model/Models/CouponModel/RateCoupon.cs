using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trendyol.Business.Model.Models.CouponModel
{
    public class RateCoupon : ICoupon
    {
        private double minumunAmount;
        private double rate;

        public RateCoupon(double _minumunAmount ,double _rate)
        {
            this.minumunAmount = _minumunAmount;
            this.rate = _rate;
        }

        public  bool IsApplicable(double amount)
        {
            return amount >= minumunAmount;
        }

        public  double getDiscount(double totalAmount)
        {
            return totalAmount * (rate * 0.01);
        }



    }
}
