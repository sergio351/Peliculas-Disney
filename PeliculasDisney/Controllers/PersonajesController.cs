using Microsoft.AspNetCore.Mvc;
using PeliculasDisney.Data;
using PeliculasDisney.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasDisney.Controllers
{
    public class PersonajesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PersonajesController(ApplicationDbContext context)
        {
            _context = context;
        }
        //HTTP GEt index 

        public IActionResult Index()
        {
            IEnumerable<Personaje> listPersonajes = _context.Personaje;
            return View(listPersonajes);
        }
        //HTTP GEt Create 
        public IActionResult Create()
        {
            return View();
        }
    }
}
