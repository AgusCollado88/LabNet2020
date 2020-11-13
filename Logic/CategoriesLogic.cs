using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;



namespace Logic
{

    public class CategoriesLogic : BaseLogic, ILogic<Categories>
    {

        public List<Categories> GetAll()
        {
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


        public bool Update(Categories entity)
        {
            var categoriaAEditar = this.GetOne(entity.CategoryID);
            categoriaAEditar.CategoryName = entity.CategoryName;
            categoriaAEditar.Description = entity.Description;
            context.SaveChanges();
            return true;

        }

        public bool Delete(int id)
        {
            try
            {
                var categoriaAEliminar = this.GetOne(id);

                context.Categories.Remove(categoriaAEliminar);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al eliminar la región");
            }
        }
    }
}
