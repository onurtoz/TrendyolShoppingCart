using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Business.Model.Models.BaseModel;

namespace Trendyol.Business.Model.Models.CategoryModel
{
    public class Category:Base
    {
        public Category ParentCategory { get; set; }

        public Category(string title)
        {
            this.Title = title;
        }
        
        public Category(string title,Category parentCategory)
        {
            this.Title = title;
            this.ParentCategory = parentCategory;
        }
    }
}
