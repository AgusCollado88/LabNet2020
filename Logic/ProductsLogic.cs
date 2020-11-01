using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ProductsLogic
    {

        private readonly NorthwindContext context;

        public ProductsLogic()
        {
            this.context = new NorthwindContext();
        }
        public List<Products> Products()
       {
 
           return context.Products.ToList();
       }

        public Products Products(int Id) 
        {
            return context.Products.FirstOrDefault(r => r.ProductID.Equals(Id));
        }

    }
}
