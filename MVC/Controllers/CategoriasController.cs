using Entities;
using Logic;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class CategoriasController : Controller
    {
        // GET: Categorias
        public ActionResult Index()
        {
            var logic = new CategoriesLogic();
            var categorias = logic.GetAll();

            List<CategoriesView> categoriesViews = (from categoria in categorias
                                                    select new CategoriesView() {
                                                        ID = categoria.CategoryID,
                                                        CategoriaNombre = categoria.CategoryName,
                                                        Descripcion = categoria.Description } 
                                                    ).ToList();
            return View(categoriesViews);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(CategoriesView categories)
        {
            var logic = new CategoriesLogic();
            var categoriaEntity = new Categories() { CategoryName = categories.CategoriaNombre, Description = categories.Descripcion };
            logic.Insert(categoriaEntity);
            return View();
        }

    }
}