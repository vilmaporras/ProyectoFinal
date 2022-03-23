using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WEB_Core_Conv2.Data;
using WEB_Core_Conv2.Models;

namespace WEB_Core_Conv2.Controllers
{
    public class HomeController : Controller
    {
        List<Producto> productos = new List<Producto>();
        private readonly ILogger<HomeController> _logger;

        private readonly MyDbContext _context;//MyDBContext es la clase que orquesta el acceso a la base de datos
        public HomeController(ILogger<HomeController> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //Simular los datos como que estoy usando base de datos

            List<Paciente> pacientes = new List<Paciente>();
            List<Categoria> categorias = new List<Categoria>();


            pacientes.Add(new Paciente()
            {
                Nombre = "Jorge Urbina",
                Direccion = "Alguna direccion",
                Edad = 33,
                Telefono = "12345678"
            });

            pacientes.Add(new Paciente()
            {
                Nombre = "Otro Nombre",
                Direccion = "Otra direccion",
                Edad = 20,
                Telefono = "454545454"
            });

            return View(pacientes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Prueba()
        {
            return View();
        }

        public IActionResult Categoria()
        {
            return View();
        }

        public IActionResult CrearCategoria(Categoria categoria)
        {
            if (string.IsNullOrEmpty(categoria.Nombre))
            {
                return Json(new
                {
                    Success = false,
                Message = "El nombre de la categorìa esta vacìa"
                }); 
            }
            else
            { 
            categoria.FechaCreacion = System.DateTime.Now; // Enviando fecha del servidor
            //categoria.Nombre = "Probando";
            _context.Categoria.Add(categoria);
            _context.SaveChanges();
                //return RedirectToAction("ListaCategoria");
                return Json(new
                {
                    Success = true,

                    Message = "Categorìa guardada correctamente"
                }); 
            }

        }
        public IActionResult CrearProducto(Producto productos)
        {
            if(string.IsNullOrEmpty(productos.Nombre))
            {
                return Json(new
                {
                    Success = false,
                    Message = "El nombre del producto está vacío"
                });
            }
            else
            {
                productos.FechaCreacion = System.DateTime.Now;
                productos.IdCategoria = 1;
                _context.Producto.Add(productos);
                _context.SaveChanges();
                return Json(new
                {
                    Success = true,
                    Message = "Producto guardado satisfactoriamente"
                });
            }
        }
        public IActionResult Producto()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult EditarValorCategoria(Categoria categoria)
        {
            Categoria categoriaActual = _context.Categoria.Where(uni => uni.IdCategoria == categoria.IdCategoria).FirstOrDefault();

            categoriaActual.Nombre = categoria.Nombre;
            categoriaActual.Descripcion = categoria.Descripcion;
            _context.SaveChanges();

            List<Categoria> categorias = _context.Categoria.ToList();

            return View("ListaCategoria", categorias);
        }

        public IActionResult ListaCategoria()
        {
            List<Categoria> categorias = _context.Categoria.ToList();
            return View(categorias);
        }

        public IActionResult EditarCategoria(int IdCategoria)
        {
            Categoria modelo = _context.Categoria.Where(c => c.IdCategoria == IdCategoria).FirstOrDefault();
            return View("EditarCategoria", modelo);
        }

        public IActionResult EliminarCategoria(int IdCategoria)
        {
            List<Producto> productos = _context.Producto.Where(a => a.IdCategoria == IdCategoria).ToList();
           
            if (productos != null)
                _context.RemoveRange(productos);

            //Con EntityFramework eliminar el valor.
            Categoria categoria = _context.Categoria.Where(a => a.IdCategoria == IdCategoria).FirstOrDefault();
            
            if (categoria != null)
                _context.Remove(categoria);
            _context.SaveChanges();

            List<Categoria> categorias = _context.Categoria.ToList();
            return View(categorias);
        }
        // El Json recibido será serializado automáticamente al objeto nuevo cocche teniendo en cuenta que las propiedades han de tener el mismo nombre
        public bool GuardarCategoria(Categoria categoria)
        {
            categoria.FechaCreacion = System.DateTime.Now; // Enviando fecha del servidor
            //categoria.Nombre = "Probando";
            _context.Categoria.Add(categoria);
            _context.SaveChanges();

            return true;
           
        }
    }
}
