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


        public Categories Update(Categories entity)
        {
            try
            {
                Categories categoriaAEditar = GetOne(entity.CategoryID);
                if (categoriaAEditar == null)
                {
                    Console.WriteLine("El número de ID ingresado no es válido.");
                    return categoriaAEditar;

                }
                else
                {
                    categoriaAEditar.CategoryName = entity.CategoryName;
                    categoriaAEditar.Description = entity.Description;
                    context.SaveChanges();
                    Console.WriteLine("");
                    Console.WriteLine($"LA MODIFICACIÓN FUE EXITOSA: {System.Environment.NewLine} CATEGORIA {entity.CategoryID}: {entity.CategoryID} CON DESCRIPCIÓN: {entity.Description}. {System.Environment.NewLine}");
                    return categoriaAEditar;
                }
            }
            catch
            {
                throw 
            }
        }

        public Categories Delete(Categories entity)
        {
            Categories categoriaAEliminar = GetOne(entity.CategoryID);
            if (categoriaAEliminar != null)
            {
                context.Categories.Remove(categoriaAEliminar);
                context.SaveChanges();
                Console.WriteLine("");
                Console.WriteLine("SE HA ELIMINADO LA CATEGORIA");
                return categoriaAEliminar;
            }
            else
            {
                Console.WriteLine("El número de ID ingresado no es válido.");
                return categoriaAEliminar;
            }
        }
    }
}
