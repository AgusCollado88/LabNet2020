using Entities;
using Logic;
using Practica_1_EF.Extensions;
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

            Console.WriteLine("A continuación se muestran las categorías: ");
            CategoriesLogic categoriesLogic = new CategoriesLogic();
            var categorias = categoriesLogic.GetAll();
            Console.WriteLine("------------------------");
            foreach (var item in categorias)
            {
                Console.WriteLine($"{item.CategoryID}, {item.CategoryName} , {item.Description}");
            }
            Console.WriteLine("------------------------");
            Console.WriteLine("");
            Console.WriteLine("Ingrese 1 para ingresar una nueva categoria, 2 para Modificar o 3 para Eliminar o 0 para salir.");
            string ingresoSwitch = Console.ReadLine();
            while(ingresoSwitch != "0")
            {
                int j = 0;
                bool EsInt = int.TryParse(ingresoSwitch, out j);
                if (EsInt && j < 4)
                {
                    switch (j)
                    {
                        case 1:
                            Console.WriteLine("INGRESO DE UNA NUEVA CATEGORIA");
                            Console.WriteLine(" ");
                            Console.WriteLine("INGRESE EL NOMBRE:");
                            try
                            {
                                string nuevoNombreIns = Console.ReadLine();
                                Console.WriteLine("INGRESE LA DESCRIPCIÓN");
                                var nuevaDescripcionIns = Console.ReadLine();
                                categoriesLogic.Insert(new Categories
                                {
                                    CategoryName = nuevoNombreIns,
                                    Description = nuevaDescripcionIns
                                });
                                Console.WriteLine("------------------------");
                                Console.WriteLine($"EL INGRESO FUE EXITOSO, NUEVA CATEGORIA DE NOMBRE: {nuevoNombreIns} CON DESCRIPCIÓN: {nuevaDescripcionIns}. LA DESCRIPCIÓN AGREGADA ES DE {nuevaDescripcionIns.ContarPalabras()} PALABRAS.");             
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("No se pudo realizar la operación solicitada.");
                            }
                            finally
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine("Finalizó el apartado de ingreso.");
                                Console.WriteLine("");
                                Console.WriteLine("Ingrese 1 para ingresar una nueva categoria, 2 para Modificar, 3 para Eliminar o 0 para salir.");
                            }
                            break;
                        case 2:
                            Console.WriteLine("");
                            Console.WriteLine("MODIFICACIÓN DE UNA NUEVA CATEGORIA");
                            Console.WriteLine(" ");
                            Console.WriteLine("INGRESE EL ID DE LA CATEGORIA A MODIFICAR");
                            int k = 0;
                            try
                            {
                                string updParam = Console.ReadLine();
                                EsInt = int.TryParse(updParam, out k);
                                if (EsInt)
                                {
                                    Console.WriteLine("INGRESE EL NOMBRE:");
                                    var nuevoNombreUpd = Console.ReadLine();
                                    Console.WriteLine("INGRESE LA DESCRIPCIÓN:");
                                    var nuevaDescripcionUpd = Console.ReadLine();
                                    categoriesLogic.Update(new Categories
                                    {
                                        CategoryID = k,
                                        CategoryName = nuevoNombreUpd,
                                        Description = nuevaDescripcionUpd
                                    });
                                    Console.WriteLine("------------------------");
                                }
                                else
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("Ingrese un valor numérico válido dentro de las categorías mostradas");
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("No se pudo realizar la operación solicitada.");
                            }
                            finally
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine("Finalizó el apartado de modificación.");
                                Console.WriteLine("");
                                Console.WriteLine("Ingrese 1 para ingresar una nueva categoria, 2 para Modificar, 3 para Eliminar o 0 para salir.");
                            }
                            break;
                        case 3:
                            Console.WriteLine("ELIMINACIÓN DE UNA NUEVA CATEGORIA");
                            Console.WriteLine(" ");
                            Console.WriteLine("INGRESE EL ID DE LA CATEGORIA A ELIMINAR");
                            int m = 0;
                            try
                            {
                                string delParam = Console.ReadLine();
                                EsInt = int.TryParse(delParam, out m);
                                if (EsInt)
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine($"¿Está seguro que quiere eliminar la Categoria {m}? Escriba 'si' para confirmar");
                                    string confirmacion = Console.ReadLine();
                                    bool equal = String.Equals(confirmacion, "si");
                                    if (equal)
                                    {
                                        var item2 = categoriesLogic.GetOne(m);

                                        categoriesLogic.Delete(new Categories
                                        {
                                            CategoryID = m
                                        });
                                    }
                                    else
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine($"SE CANCELÓ LA ELIMINACIÓN DE LA CATEGORIA {m}");
                                    }
                                }
                                else 
                                {
                                    Console.WriteLine("Ingrese un valor numérico válido dentro de las categorías mostradas");
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("No se pudo realizar la operación solicitada.");
                            }
                            finally
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine("Finalizó el apartado de eliminación.");
                                Console.WriteLine("");
                                Console.WriteLine("Ingrese 1 para ingresar una nueva categoria, 2 para Modificar, 3 para Eliminar o 0 para salir.");
                            }
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("El valor ingresado no es valido o no corresponde a las opciones.");
                    Console.WriteLine(" ");
                    Console.WriteLine("Ingrese 1 para ingresar una nueva categoria, 2 para Modificar, 3 para Eliminar o 0 para salir.");
                }
                ingresoSwitch = Console.ReadLine();
            }
            Console.Clear();
            Console.WriteLine("Ingrese un número de ID de Producto o ingrese 0 para finalizar.");
            Console.WriteLine("");
            string paramProducto = Console.ReadLine();
            while (paramProducto != "0")
            {
                int i = 0;
                bool EsInt2 = int.TryParse(paramProducto, out i);

                ProductsLogic productsLogic = new ProductsLogic();
                var products = productsLogic.GetAll();
                var item = productsLogic.GetOne(i);

                if (EsInt2 && i < products.Count)
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
