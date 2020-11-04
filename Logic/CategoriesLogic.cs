using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
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
            context.Categories.FirstOrDefault(r => r.CategoryID.Equals(id));
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
            Categories categoriaAEditar = GetOne(entity.CategoryID);
            categoriaAEditar.CategoryName = entity.CategoryName;
            categoriaAEditar.Description = entity.Description;
            context.SaveChanges();
            Categories T = null;
            return T;
        }

        public Categories Delete(Categories entity)
        {
            Categories categoriaAEliminar = GetOne(entity.CategoryID);
            context.Categories.Remove(categoriaAEliminar);
            context.SaveChanges();
            Categories T = null;
            return T;
        }
    }
}
