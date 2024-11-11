using Microsoft.AspNetCore.Mvc;
using ProyectCafeteria.BD.Data.Entity;
using ProyectCafeteria.BD.Data;
using Microsoft.EntityFrameworkCore;

namespace ProyectCafeteria.Server.Controllers
{
    [ApiController]
    [Route("api/Productos")]
    public class ProductosControllers : ControllerBase
    {
        private readonly Context context;

        public ProductosControllers(Context context)
        {
            this.context = context;
        }
        [HttpGet]   // Método para ver todas las productos
        public async Task<ActionResult<List<Producto>>> Get()
        {
            return await context.Productos.ToListAsync();
        }

        [HttpPost]   // Método para crear un nuevo producto
        public async Task<ActionResult<int>> Post(Producto entidad)
        {
            try
            {
                context.Productos.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
