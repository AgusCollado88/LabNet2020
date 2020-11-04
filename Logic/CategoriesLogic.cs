using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{

    public class CategoriesLogic : BaseLogic, ILogic<Categories>
    {

        public List<Categories> GetAll()
        {
            NorthwindContext context = new NorthwindContext();
            return context.Categories.ToList();
        }
        public Categories GetOne(int id) 
        {
            return context.Categories.FirstOrDefault(r => r.CategoryID.Equals(id));
        }

        public Categories Insert(Categories entity)
        {
            int ultimoId = (from cat in context.Categories
                            orderby cat.CategoryID descending
                            select cat.CategoryID
                            ).FirstOrDefault();
            ultimoId = ultimoId + 1;

            Categories nuevaCategoria = context.Categories.Add(entity);
            context.SaveChanges();
            return nuevaCategoria;
        }

        public Categories Update(Categories entity)
        {
            throw new NotImplementedException();
        }
        public Categories Delete(Categories entity)
        {
            throw new NotImplementedException();
        }
    }
}
