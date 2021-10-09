using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApiCRUD.Data.Interfaces;
using WebApiCRUD.Models;

namespace WebApiCRUD.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class ProductosController : ControllerBase
    {

        private readonly IApiRepository _repo;

        public ProductosController(IApiRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var productos = await _repo.GetProductosAsync();
            return Ok(productos);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Producto producto)
        {
            producto.DateInsert = DateTime.Now;
            producto.Active = true;
            _repo.Add(producto);
            if (await _repo.SaveAll())
                return Ok(producto);

            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var producto = await _repo.GetProductoByIdAsync(id);

            if (producto != null)
                return Ok(producto);
            else
                return NotFound("Producto no encontrado");
        }

        [HttpPut]
        public async Task<ActionResult> Put(Producto producto)
        {
            var productoToUpdate = await _repo.GetProductoByIdAsync(producto.Id);

            if (productoToUpdate is null)
                return BadRequest();

            productoToUpdate.Name = producto.Name;
            productoToUpdate.Description = producto.Description;
            productoToUpdate.Price = producto.Price;

            if (!await _repo.SaveAll())
                return NoContent();

            return Ok(productoToUpdate);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var productoToDelete = await _repo.GetProductoByIdAsync(id);

            if (productoToDelete is null)
                return NotFound("Producto no encontrado");

            _repo.Delete(productoToDelete);

            if (!await _repo.SaveAll())
                return NoContent();

            return Ok("Producto Borrado");

        }
    }

  
}
