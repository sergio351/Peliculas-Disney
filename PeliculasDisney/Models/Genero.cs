using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasDisney.Models
{
    public class Genero
    {
        public string Nombre { get; set; }
        public byte Imagen { get; set; }
        [Display(Name = "Peliculas Asociadas")]
        public string PeliculasAsociadas { get; set; }

    }
}
