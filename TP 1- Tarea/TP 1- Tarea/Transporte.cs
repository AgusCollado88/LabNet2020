using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_1__Tarea
{
    public abstract class Transporte: IAvanzar //Clases en PascalCase
    {
        #region Atributos

        private int cantidadPasajeros; //Atributos en camelCase


        #endregion

        #region Constructor

        public Transporte(int cantidadPasajeros) 
        {
            this.cantidadPasajeros = cantidadPasajeros;
        }

        #endregion

        #region Metodos

        public int CantidadPasajeros //Metodos en PascalCase
        {
            get { return this.cantidadPasajeros;}

        }

        //public int CantidadPasajeros { get; set; } alternativa del codigo de arriba

        public virtual string Ocupantes()
        {
            return "";
        }

        public virtual string Detenerse() 
        {
            return "Detenerse";        
        }

        public virtual string Avanzar()
        {
            return "Avanzar";
        }
        #endregion

    }
}
