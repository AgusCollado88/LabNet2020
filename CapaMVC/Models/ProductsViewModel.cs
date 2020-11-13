using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CapaMVC.Models
{
    public class ProductsViewModel
    {
        public int ID { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Proveedor")]
        public Nullable<int> Proveedor { get; set; }

        [Display(Name = "Categoria")]
        public Nullable<int> Categoria { get; set; }

        [StringLength(20)]
        [Display(Name = "Cantidad por Unidad")]
        public string Cantidad { get; set; }

        [Required]
        
        [Display(Name = "Precio por Unidad")]
        public Nullable<decimal> PrecioUnitario { get; set; }

        [Required]
        [Display(Name = "Unidades en Stock")]
        public Nullable<short> UnidadesStock { get; set; }

        [Display(Name = "Unidades Pedidas")]
        public Nullable<short> UnidadesPedidas { get; set; }

        [Display(Name = "Nivel de Aprovisionamiento")]
        public Nullable<short> Aprovisionamiento { get; set; }

        [Required]
        [Display(Name = "Está discontinuado?")]
        public bool Descontinuado { get; set; }
    }
}