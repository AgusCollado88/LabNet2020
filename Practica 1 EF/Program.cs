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
                Console.WriteLine("Ingrese 1 para ingresar una nueva categoria, 2 para Modificar o 3 para Eliminar");
                int j = 0;
                string ingresoSwitch= Console.ReadLine();
                bool EsInt = int.TryParse(ingresoSwitch, out j);
                if (EsInt && j<4)
                    switch (j)
                    {
                        case 1:
                            Console.WriteLine("INGRESO DE UNA NUEVA CATEGORIA");
                            Console.WriteLine(" ");
                            Console.WriteLine("INGRESE EL NOMBRE:");
                            var nuevoNombreIns = Console.ReadLine();
                            Console.WriteLine("INGRESE LA DESCRIPCIÓN");
                            var nuevaDescripcionIns = Console.ReadLine();
                            categoriesLogic.Insert(new Categories
                            {
                                CategoryName = nuevoNombreIns,
                                Description = nuevaDescripcionIns
                            });
                            Console.WriteLine("------------------------");
                            Console.WriteLine($"EL INGRESO FUE EXITOSO, NUEVA CATEGORIA DE NOMBRE: {nuevoNombreIns} CON DESCRIPCIÓN: {nuevaDescripcionIns}");
                            break;
                        case 2:
                            Console.WriteLine("MODIFICACIÓN DE UNA NUEVA CATEGORIA");
                            Console.WriteLine(" ");
                            Console.WriteLine("INGRESE EL ID DE LA CATEGORIA A MODIFICAR");
                            int k = 0;
                            string updParam = Console.ReadLine();
                            bool EsInt2 = int.TryParse(updParam, out k);
                            var item = categoriesLogic.GetOne(k);
                            if (EsInt && k < categorias.Count)
                            {
                                Console.WriteLine("INGRESE EL NOMBRE:");
                                var nuevoNombreUpd = Console.ReadLine();
                                Console.WriteLine("INGRESE LA DESCRIPCIÓN");
                                var nuevaDescripcionUpd = Console.ReadLine();
                                categoriesLogic.Update(new Categories
                                {
                                    CategoryID = k,
                                    CategoryName = nuevoNombreUpd,
                                    Description = nuevaDescripcionUpd
                                });
                                Console.WriteLine("------------------------");
                                Console.WriteLine($"LA MODIFICACIÓN FUE EXITOSA: {System.Environment.NewLine} CATEGORIA {k}: {nuevoNombreUpd} CON DESCRIPCIÓN: {nuevaDescripcionUpd}");
                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine($"Ingrese un valor numérico válido menor que {categorias.Count}");
                            }

                            break;
                        case 3:
                            Console.WriteLine("ELIMINACIÓN DE UNA NUEVA CATEGORIA");
                            Console.WriteLine(" ");
                            Console.WriteLine("INGRESE EL ID DE LA CATEGORIA A ELIMINAR");
                            int m = 0;
                            string delParam = Console.ReadLine();
                            bool EsInt3 = int.TryParse(delParam, out m);
                            if (m <= categorias.Count)
                            {
                                Console.WriteLine("");
                                Console.WriteLine($"¿Está seguro que quiere eliminar la Categoria {m}? Escriba 'si' para confirmar");
                                string confirmacion = Console.ReadLine();
                                bool equal = String.Equals(confirmacion, "si");
                                if (equal)
                                {
                                    var item2 = categoriesLogic.GetOne(m);

                                    categoriesLogic.Update(new Categories
                                    {
                                        CategoryID = m
                                    });
                                    Console.WriteLine($"SE HA ELIMINADO LA CATEGORIA {m}");
                                }
                                else
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine($"SE CANCELÓ LA ELIMINACIÓN DE LA CATEGORIA {m}");
                                }
                            }
                            else
                            {
                            Console.WriteLine("");
                            Console.WriteLine($"Ingrese un valor numérico válido menor que {categorias.Count}");
                            }
                            break;
                    }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("El valor ingresado no es valido o no corresponde a las opciones.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Ingrese un número de ID de Producto o ingrese 0 para finalizar.");
            Console.WriteLine("");
            string paramProducto = Console.ReadLine();
            while (paramProducto != "0")
            {
                int i = 0;
                bool EsInt = int.TryParse(paramProducto, out i);

                ProductsLogic productsLogic = new ProductsLogic();
                var products = productsLogic.GetAll();
                var item = productsLogic.GetOne(i);

                if (EsInt && i < products.Count)
                    Console.WriteLine($" ID: {item.ProductID} , NOMBRE: {item.ProductName} , ID DE PROVEEDOR: {item.SupplierID} , CATEGORIA: {item.CategoryID}, {System.Environment.NewLine} " +
                        $"CANTIDAD POR UNIDAD: {item.QuantityPerUnit} , PRECIO UNITARIO: {item.UnitPrice} ,  UNIDADES EN STOCK: {item.UnitsInStock}, {System.Environment.NewLine} UNIDADES ENCARGADAS: {item.UnitsOnOrder} , PUNTO DE PEDIDO: {item.ReorderLevel} , DESCONTINUADO: {item.Discontinued}");
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine($"Ingrese un valor numérico válido menor que {products.Count}");
                }
                Console.WriteLine("");
                Console.WriteLine("Ingrese otro número de ID de Producto o ingrese 0 para finalizar.");
                Console.WriteLine("");
                paramProducto = Console.ReadLine();
            }
            Console.WriteLine("Finalizó el programa.");
            Console.ReadKey();
        }

    }
}
