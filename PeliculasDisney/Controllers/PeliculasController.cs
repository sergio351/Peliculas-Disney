using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasDisney.Data;
using PeliculasDisney.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasDisney.Controllers
{
    public class PeliculasController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PeliculasController(ApplicationDbContext context)
        {
            _context = context;
        }
        //HTTP GEt index 

        public IActionResult Index()
        {
            IEnumerable<Pelicula> listPeliculas = _context.Pelicula;
            return View(listPeliculas);
        }
        //HTTP GEt Create 
        public IActionResult Create()
        {
            return View();
        }
        //HTTP Post Create 
        [HttpPost]
        public IActionResult Create(Pelicula pelicula)
        {

            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Count > 0)
                {
                    IFormFile file = Request.Form.Files[0];
                    using (var dataStream = new MemoryStream())
                    {
                        file.CopyTo(dataStream);
                        pelicula.Imagen = dataStream.ToArray();
                    }

                }
                _context.Pelicula.Add(pelicula);
                _context.SaveChanges();
                TempData["mensaje"] = "Se guardo una pelicula";
                return RedirectToAction("Index");
            }
            return View();
        }

        //HTTP GEt Edit 
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var pelicula = _context.Pelicula.Find(id);
            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        //HTTP Post Edit 
        [HttpPost]
        public IActionResult Edit(Pelicula pelicula)
        {

            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Count > 0)
                {
                    IFormFile file = Request.Form.Files[0];
                    using (var dataStream = new MemoryStream())
                    {
                        file.CopyTo(dataStream);
                        pelicula.Imagen = dataStream.ToArray();
                    }

                }
                _context.Pelicula.Update(pelicula);
                _context.SaveChanges();
                TempData["mensaje"] = "Se actualizo una pelicula";
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

            var pelicula = _context.Pelicula.Find(id);
            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        //HTTP Post Delete 
        [HttpPost]
        public IActionResult DeletePelicula(int? id)
        {

            var pelicua = _context.Pelicula.Find(id);

            if (pelicua == null)
            {
                return NotFound();
            }


            _context.Pelicula.Remove(pelicua);
            _context.SaveChanges();
            TempData["mensaje"] = "Se borró una pelicula";
            return RedirectToAction("Index");


        }

        //HTTP GEt Edit 
        public IActionResult Detalle(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var pelicula = _context.Pelicula.Find(id);
            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        //HTTP Post Edit 
        [HttpPost]
        public IActionResult Detalle(Pelicula pelicula)
        {

            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Count > 0)
                {
                    IFormFile file = Request.Form.Files[0];
                    using (var dataStream = new MemoryStream())
                    {
                        file.CopyTo(dataStream);
                        pelicula.Imagen = dataStream.ToArray();
                    }

                }
                _context.Pelicula.Update(pelicula);
                _context.SaveChanges();
                TempData["mensaje"] = "Se actualizo una pelicula";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult ListaPeliculas()
        {
            IEnumerable<Pelicula> listPelicula = _context.Pelicula;
            return View(listPelicula);
        }

        public async Task<IActionResult> Buscar(string filtrotitulo)
        {
            return View("Index", await _context.Pelicula.Where(a => a.Titulo.Contains(filtrotitulo)).ToListAsync());

        }

    }

}


