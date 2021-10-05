using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasDisney.Models
{
    public class Personaje
    {   [Key]
        
        public int Id { get; set; }
       
        public string Nombre { get; set; }
        
        public int Edad { get; set; }
      
        public int  Peso { get; set; }
        public string Historia { get; set; }
        [Display(Name="Peliculas Asociadas")]
        public string PeliculasAsociadas { get; set; }
        public byte[] Imagen { get; set; }


    }
}
