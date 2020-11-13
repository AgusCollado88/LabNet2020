using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CapaMVC.Models
{
    public class CategoriesViewModel
    {
        public int ID { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }
}