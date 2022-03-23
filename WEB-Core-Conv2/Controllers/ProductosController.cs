using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WEB_Core_Conv2.Data;
using WEB_Core_Conv2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WEB_Core_Conv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly MyDbContext _context;
        public ProductosController(MyDbContext context)
        {
            _context = context;
        }
        // GET: api/<ProductosController>
        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            IEnumerable<Producto> productos = _context.Producto.ToList();
            return productos;
        }

        // GET api/<ProductosController>/5
        [HttpGet("{id}")]
        public Producto Get(int IdProducto)
        {
            Producto productos = _context.Producto.Where(a => a.IdProducto == IdProducto).FirstOrDefault();
            if (productos == null)
                return new Producto();
            return productos;
        }

        // POST api/<ProductosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
