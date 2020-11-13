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

    public class CategoriesController : Controller
    {
        public ActionResult Index()
        {
            var logic = new CategoriesLogic();
            var categorias = logic.GetAll();


            List<CategoriesViewModel> categoriesViewModels = (from categoria in categorias
                                                              select new CategoriesViewModel() {
                                                                  ID = categoria.CategoryID,
                                                                  Nombre = categoria.CategoryName,
                                                                  Descripcion = categoria.Description }
                                                              ).ToList();

            return View(categoriesViewModels);
        }

        public ActionResult InsertUpdate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertUpdate(CategoriesViewModel categories)
        {
            if (categories.ID <= 0)
            {
                var logic = new CategoriesLogic();
                var categoriasEntity = new Categories() { CategoryName = categories.Nombre, Description = categories.Descripcion };
                logic.Insert(categoriasEntity);
               if (Session["StartedSession"] == null)
                Session["StartedSession"] = "Inicio la Sesión ingresando un dato en Categorias";
            }
            else
            {
                var logic = new CategoriesLogic();
                var categoriasEntity = new Categories() { CategoryID = categories.ID, CategoryName = categories.Nombre, Description = categories.Descripcion };
                logic.Update(categoriasEntity);
                if (ViewBag.MensajeContexto == null)
                {
                    HttpContext.Application["Started"] = "Application Asignado";
                    ViewBag.MensajeContexto = "Se asignó un Aplicación luego de Modificar Categorias. Puede poner en incógnito si quiere";
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var logic = new CategoriesLogic();
            logic.Delete(id);
            return RedirectToAction("index");
        }
    }
}