using CapaMVC.Models;
using Entities;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaMVC.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index()
        {
            var logic = new ProductsLogic();
            var productos = logic.GetAll();


            List<ProductsViewModel> productsViewModels = (from producto in productos
                                                          select new ProductsViewModel()
                                                          {
                                                              ID = producto.ProductID,
                                                              Nombre = producto.ProductName,
                                                              Proveedor = producto.SupplierID,
                                                              Categoria = producto.CategoryID,
                                                              Cantidad = producto.QuantityPerUnit,
                                                              PrecioUnitario = producto.UnitPrice,
                                                              UnidadesStock = producto.UnitsInStock,
                                                              UnidadesPedidas = producto.UnitsOnOrder,
                                                              Aprovisionamiento = producto.ReorderLevel,
                                                              Descontinuado = producto.Discontinued 
                                                          }).ToList();
            return View(productsViewModels);
        }
        public ActionResult InsertUpdate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertUpdate(ProductsViewModel products)
        {
            if (products.ID <= 0)
            {
                var logic = new ProductsLogic();
                var productosEntity = new Products() {
                    ProductName = products.Nombre,
                    SupplierID = products.Proveedor,
                    CategoryID = products.Categoria,
                    QuantityPerUnit = products.Cantidad,
                    UnitPrice = products.PrecioUnitario,
                    UnitsInStock = products.UnidadesStock,
                    UnitsOnOrder = products.UnidadesPedidas,
                    ReorderLevel = products.Aprovisionamiento,
                    Discontinued = products.Descontinuado
                };
                logic.Insert(productosEntity);
                if (Session["StartedSession"] == null)
                    Session["StartedSession"] = "Inicio la Sesión ingresando un dato en Productos. Puede poner en incógnito si quiere";
            }
            else
            {
                var logic = new ProductsLogic();
                var productosEntity = new Products() {
                    ProductID = products.ID,
                    ProductName = products.Nombre,
                    SupplierID = products.Proveedor,
                    CategoryID = products.Categoria,
                    QuantityPerUnit = products.Cantidad,
                    UnitPrice = products.PrecioUnitario,
                    UnitsInStock = products.UnidadesStock,
                    UnitsOnOrder = products.UnidadesPedidas,
                    ReorderLevel = products.Aprovisionamiento,
                    Discontinued = products.Descontinuado
                };
                logic.Update(productosEntity);
                if (HttpContext.Application["Started"] == null)
                {
                    HttpContext.Application["Started"] = "Application Asignado";
                    ViewBag.MensajeContexto = "Se asignó un Aplicación luego de Modificar un Producto";
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var logic = new ProductsLogic();
            logic.Delete(id);
            return RedirectToAction("index");
        }
    }
}