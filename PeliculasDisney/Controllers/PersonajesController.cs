using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeliculasDisney.Data;
using PeliculasDisney.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        //HTTP Post Create 
        [HttpPost]
        public IActionResult Create(Personaje personaje)
        {

            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Count > 0)
                {
                    IFormFile file = Request.Form.Files[0];
                    using (var dataStream = new MemoryStream())
                    {
                        file.CopyTo(dataStream);
                        personaje.Imagen = dataStream.ToArray();
                    }

                }
                _context.Personaje.Add(personaje);
                _context.SaveChanges();
                TempData["mensaje"] = "Se guardo un personaje";
                return RedirectToAction("Index");
            }
            return View();
        }

        //HTTP GEt Edit 
        public IActionResult Edit(int? id)
        {
            if(id==null|| id==0)
            {
                return NotFound();
            }

            var personaje = _context.Personaje.Find(id);
            if (personaje==null)
            {
                return NotFound();
            }

            return View(personaje);
        }

        //HTTP Post Edit 
        [HttpPost]
        public IActionResult Edit(Personaje personaje)
        {

            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Count > 0)
                {
                    IFormFile file = Request.Form.Files[0];
                    using (var dataStream = new MemoryStream())
                    {
                        file.CopyTo(dataStream);
                        personaje.Imagen = dataStream.ToArray();
                    }

                }
                _context.Personaje.Update(personaje);
                _context.SaveChanges();
                TempData["mensaje"] = "Se actualizo un personaje";
                return RedirectToAction("Index");
            }
            return View();
        }

        //HTTP GEt Delete 
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var personaje = _context.Personaje.Find(id);
            if (personaje == null)
            {
                return NotFound();
            }

            return View(personaje);
        }

        //HTTP Post Delete 
        [HttpPost]
        public IActionResult DeletePersonaje(int? id)
        {

            var personaje = _context.Personaje.Find(id);

            if (personaje == null)
            {
                return NotFound();
            }


                _context.Personaje.Remove(personaje);
                _context.SaveChanges();
                TempData["mensaje"] = "Se borró un personaje";
                return RedirectToAction("Index");
            
            
        }
    }
}

