using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_1__Tarea
{
    class Program
    {
        static void Main(string[] args)
        {
            Transporte avion1 = new Avion(100);
            Transporte avion2 = new Avion(30);
            Transporte avion3 = new Avion(10);
            Transporte avion4 = new Avion(50);
            Transporte avion5 = new Avion(88);

            Transporte auto1 = new Automovil(3);
            Transporte auto2 = new Automovil(2);
            Transporte auto3 = new Automovil(3);
            Transporte auto4 = new Automovil(5);
            Transporte auto5 = new Automovil(4);

            Console.WriteLine("*********AUTOS**********");
            Console.WriteLine("");
            Console.WriteLine("En el auto 1 hay: " +auto1.Ocupantes());
            Console.WriteLine("En el auto 2 hay: " +auto2.Ocupantes());
            Console.WriteLine("En el auto 3 hay: " +auto3.Ocupantes());
            Console.WriteLine("En el auto 4 hay: " +auto4.Ocupantes());
            Console.WriteLine("En el auto 5 hay: " +auto5.Ocupantes());

            Console.WriteLine("");
            Console.WriteLine("********AVIONES*********");
            Console.WriteLine("");
            Console.WriteLine("En el avion 1 hay: " +avion1.Ocupantes());
            Console.WriteLine("En el avion 2 hay: " +avion2.Ocupantes());
            Console.WriteLine("En el avion 3 hay: " +avion3.Ocupantes());
            Console.WriteLine("En el avion 4 hay: " +avion4.Ocupantes());
            Console.WriteLine("En el avion 5 hay: " +avion5.Ocupantes());
            Console.ReadKey();
        }
    }
}
