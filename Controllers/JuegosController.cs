using MVCJuegos.Data;
using MVCJuegos.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCJuegos.Controllers
{
    public class JuegosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JuegosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Juegos> listaJuegos = _context.Juegos;
            return View(listaJuegos);
        }

        //http Get Create
        public IActionResult Create()
        {
            return View();
        }

        //Http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Juegos juegos)
        {
            if (ModelState.IsValid)
            {
                _context.Juegos.Add(juegos);
                _context.SaveChanges();

                TempData["mensaje"] = "¡Gracias por colaborar!";
                return RedirectToAction("Index");
            }

            return View();
        }

        //Http Get Edit
        public IActionResult Info(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //obtener Juego
            var juegos = _context.Juegos.Find(id);

            if (juegos == null)
            {
                return NotFound();
            }

            return View(juegos);
        }
        //Http Get Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //obtener juego
            var juego = _context.Juegos.Find(id);

            if (juego == null)
            {
                return NotFound();
            }

            return View(juego);
        }

        //Http Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Juegos juegos)
        {
            if (ModelState.IsValid)
            {
                _context.Juegos.Update(juegos);
                _context.SaveChanges();

                TempData["mensaje"] = "Los datos del Juego se han modificado con exito!";
                return RedirectToAction("Index");
            }

            return View();
        }

        //Http Get Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //obtener Juego
            var juegos = _context.Juegos.Find(id);

            if (juegos == null)
            {
                return NotFound();
            }

            return View(juegos);
        }

        //Http Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteJuego(int? id)
        {
            //obtener id del juego
            var juegos = _context.Juegos.Find(id);

            if (juegos == null)
            {
                return NotFound();
            }

            _context.Juegos.Remove(juegos);
            _context.SaveChanges();

            TempData["mensaje"] = "Los datos del Juego se han eliminado con exito!";
            return RedirectToAction("Index");


        }
    }
}
