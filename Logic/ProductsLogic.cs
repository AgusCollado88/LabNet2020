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

        public Products GetOne(int id)
        {
            return context.Products.FirstOrDefault(r => r.ProductID.Equals(id));
        }

        public Products Insert(Products entity)
        {
            int ultimoId = (from pro in context.Products
                            orderby pro.ProductID descending
                            select pro.ProductID
                            ).FirstOrDefault();
            ultimoId = ultimoId + 1;

            Products nuevoProducto = context.Products.Add(entity);
            context.SaveChanges();
            return nuevoProducto;
        }
        public bool Update(Products entity)
        {
            var productoAEditar = this.GetOne(entity.ProductID);
            productoAEditar.ProductName = entity.ProductName;
            productoAEditar.SupplierID = entity.SupplierID;
            productoAEditar.CategoryID = entity.CategoryID;
            productoAEditar.QuantityPerUnit = entity.QuantityPerUnit;
            productoAEditar.UnitPrice = entity.UnitPrice;
            productoAEditar.UnitsInStock = entity.UnitsInStock;
            productoAEditar.UnitsOnOrder = entity.UnitsOnOrder;
            productoAEditar.ReorderLevel = entity.ReorderLevel;
            productoAEditar.Discontinued = entity.Discontinued;
            context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                var productoAEliminar = this.GetOne(id);

                context.Products.Remove(productoAEliminar);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al eliminar el producto");
            }
        }
    }
}
