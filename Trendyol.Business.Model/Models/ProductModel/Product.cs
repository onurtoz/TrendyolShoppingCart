using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Business.Model.Models.BaseModel;
using Trendyol.Business.Model.Models.CategoryModel;

namespace Trendyol.Business.Model.Models.ProductModel
{
    public class Product:Base
    {
        public double ProductPrice { get; set; }
        public Category Category { get; set; }

        public Product(string title,double price,Category category)
        {
            this.Title = title;
            this.ProductPrice = price;
            this.Category = category;
        }
    }
}
