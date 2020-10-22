using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_1__Tarea
{
    public class Avion : Transporte
    {
        public override string Detenerse()
        {
            return "Frenar";
        }

        public Avion(int cantidadPasajeros): base(cantidadPasajeros) {}


        public override string Ocupantes()
        {
            return this.CantidadPasajeros + " pasajeros";
        }
    }
    
}
