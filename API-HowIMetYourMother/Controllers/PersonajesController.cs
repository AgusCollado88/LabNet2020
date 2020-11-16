using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_HowIMetYourMother.Controllers
{
    public class PersonajesController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Add()
        {
            using (Models.Entities personajes = new Models.Entities())

            {
                var oPersonaje = new Models.Personajes();
                oPersonaje.NombrePersonaje = "Lily Aldrin";
                oPersonaje.TrabajoPersonaje = 1;
                oPersonaje.EdadPrimeraTemporada = 27;
                personajes.Personajes.Add(oPersonaje);
                personajes.SaveChanges();
            }
            return Ok("Recibido");
        }
    }
}
