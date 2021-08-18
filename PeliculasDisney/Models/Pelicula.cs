using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasDisney.Models
{
    public class Pelicula
    {
        [Display(Name = "Personajes Asociadas")]
        public string PersonajesAsociados { get; set; }
        public string Titulo { get; set; }
        [Display(Name = "Fecha de Creación")]
        public DateTime FechaCreacion { get; set; }
        public int Calificacion { get; set; }
        public byte Imagen { get; set; }

    }
}
