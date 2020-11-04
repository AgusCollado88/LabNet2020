using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ProductsLogic : BaseLogic, ILogic<Products>
    {
        
        public List<Products> GetAll()
        {
           
           return context.Products.ToList();
          
        }
        public Products GetOne(int Id) 
        {
            return context.Products.FirstOrDefault(r => r.ProductID.Equals(Id));
        }
        public Products Insert(Products entity)
        {
            throw new NotImplementedException();
        }


        Products ILogic<Products>.Delete(Products entity)
        {
            throw new NotImplementedException();
        }

        public Products Update(Products entity)
        {
            throw new NotImplementedException();
        }

       
    }
}
