using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_1__Tarea
{
    class Automovil : Transporte
    {
        public override string Detenerse()
        {
            return "Detenerse";
        }

        public Automovil(int cantidadPasajeros) : base(cantidadPasajeros) { }


        public override string Ocupantes()
        {
            return this.CantidadPasajeros + " pasajeros";
        }
    }
}
