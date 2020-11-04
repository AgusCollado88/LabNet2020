using Entities;
using Logic;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_1_EF
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("A continuación se muestran las categorías:");
            //Console.WriteLine("");

            //CategoriesLogic categoriesLogic = new CategoriesLogic();
            //var categories = categoriesLogic.GetAll();

            //foreach (var item in categories)
            //{
            //    Console.WriteLine($"ID: {item.CategoryID.ToString()} , NOMBRE: {item.CategoryName.ToString()}, DESCRIPCIÓN: {item.Description.ToString()} ");
            //}

            //Console.ReadKey();
            //Console.Clear();

            //Console.WriteLine("Ingrese un número de ID de Producto o ingrese 0 para finalizar.");
            //Console.WriteLine("");
            //string paramProducto = Console.ReadLine();
            //while (paramProducto != "0")
            //{
            //    int i = 0;
            //    bool EsInt = int.TryParse(paramProducto, out i);

            //    ProductsLogic productsLogic = new ProductsLogic();
            //    var products = productsLogic.GetAll();
            //    var item = productsLogic.GetOne(i);

            //    if (EsInt && i < products.Count) 
            //        Console.WriteLine($" ID: {item.ProductID} , NOMBRE: {item.ProductName} , ID DE PROVEEDOR: {item.SupplierID} , CATEGORIA: {item.CategoryID}, {System.Environment.NewLine} " +
            //            $"CANTIDAD POR UNIDAD: {item.QuantityPerUnit} , PRECIO UNITARIO: {item.UnitPrice} ,  UNIDADES EN STOCK: {item.UnitsInStock}, {System.Environment.NewLine} UNIDADES ENCARGADAS: {item.UnitsOnOrder} , PUNTO DE PEDIDO: {item.ReorderLevel} , DESCONTINUADO: {item.Discontinued}");
            //    else
            //    {
            //        Console.WriteLine("");
            //        Console.WriteLine($"Ingrese un valor numérico válido menor que {products.Count}");
            //    }
            //    Console.WriteLine("");
            //    Console.WriteLine("Ingrese otro número de ID de Producto o ingrese 0 para finalizar.");
            //    Console.WriteLine("");
            //    paramProducto = Console.ReadLine();
            //}
            //Console.WriteLine("Finalizó la consulta.");
            //Console.ReadKey();

            try
            {
                Console.WriteLine("A continuación se muestran las categorías: ");

                CategoriesLogic categoriesLogic = new CategoriesLogic();

                var categorias = categoriesLogic.GetAll();
                Console.WriteLine("------------------------");
                foreach (var item in categorias)
                {
                    Console.WriteLine($"{item.CategoryID}, {item.CategoryName} , {item.Description}");
                }
                Console.WriteLine("------------------------");
                Console.WriteLine("INGRESO DE UNA NUEVA CATEGORIA");
                Console.WriteLine(" ");
                Console.WriteLine("INGRESE EL NOMBRE QUE VA A TENER:");
                var nuevoNombre = Console.ReadLine();
                Console.WriteLine("INGRESE LA DESCRIPCIÓN");
                var nuevaDescripcion = Console.ReadLine();

                categoriesLogic.Insert(new Categories
                {
                    CategoryName = nuevoNombre,
                    Description = nuevaDescripcion
                });

                Console.WriteLine("------------------------");

                Console.WriteLine($"EL INGRESO FUE EXITOSO, NUEVA CATEGORIA DE NOMBRE: {nuevoNombre} CON DESCRIPCIÓN: {nuevaDescripcion}" );

                Console.ReadKey();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
        
    }
}
