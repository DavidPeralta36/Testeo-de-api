using ApiTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiTest.Controllers
{
    public class PruebaController : ApiController
    {
        private List<Producto> _productos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Producto 1", Precio = 10.99m },
            new Producto { Id = 2, Nombre = "Producto 2", Precio = 19.99m },
            new Producto { Id = 3, Nombre = "Producto 3", Precio = 29.99m },
        };

        [AllowAnonymous]
        // GET: api/Prueba
        public IEnumerable<Producto> Get()
        {
            return _productos;
        }

        // GET: api/Prueba/5
        public IHttpActionResult Get(int id)
        {
            var producto = _productos.FirstOrDefault(p => p.Id == id);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        [AllowAnonymous]
        // POST: api/Prueba
        public IHttpActionResult Post([FromBody] Producto producto)
        {
            if (producto == null)
            {
                return BadRequest("Producto no puede ser nulo");
            }

            _productos.Add(producto);

            return Ok("Creadop");
        }

        // PUT: api/Prueba/5
        public IHttpActionResult Put(int id, [FromBody] Producto producto)
        {
            if (producto == null)
            {
                return BadRequest("Producto no puede ser nulo");
            }

            var productoExistente = _productos.FirstOrDefault(p => p.Id == id);

            if (productoExistente == null)
            {
                return NotFound();
            }

            productoExistente.Nombre = producto.Nombre;
            productoExistente.Precio = producto.Precio;

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Prueba/5
        public IHttpActionResult Delete(int id)
        {
            var producto = _productos.FirstOrDefault(p => p.Id == id);

            if (producto == null)
            {
                return NotFound();
            }

            _productos.Remove(producto);

            return Ok(producto);
        }
    }
}
