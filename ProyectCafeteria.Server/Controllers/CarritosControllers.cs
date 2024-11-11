using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectCafeteria.BD.Data;
using ProyectCafeteria.BD.Data.Entity;

namespace ProyectCafeteria.Server.Controllers
{
    [ApiController]
    [Route("api/Carritos")]
    public class CarritosControllers : ControllerBase
    {
        private readonly Context context;

        public CarritosControllers(Context context)
        {
            this.context = context;
        }
        [HttpGet]   // Método para ver el carrito
        public async Task<ActionResult<List<Carrito>>> Get()
        {
            return await context.Carritos.ToListAsync();
        }

        [HttpPost]   // Método para crear un nuevo producto al carrito
        public async Task<ActionResult<int>> Post(Carrito entidad)
        {
            try
            {
                context.Carritos.Add(entidad);
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
