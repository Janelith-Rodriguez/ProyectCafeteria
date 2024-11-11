using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectCafeteria.BD.Data;
using ProyectCafeteria.BD.Data.Entity;

namespace ProyectCafeteria.Server.Controllers
{
    [ApiController]
    [Route("api/Ordenes")]
    public class OrdenesControllers : ControllerBase
    {
        private readonly Context context;

        public OrdenesControllers(Context context)
        {
            this.context = context;
        }
        [HttpGet]   // Método para ver todas las ordenes
        public async Task<ActionResult<List<Orden>>> Get()
        {
            return await context.Ordenes.ToListAsync();
        }

        [HttpPost]   // Método para crear un nuevo usuario
        public async Task<ActionResult<int>> Post(Orden entidad)
        {
            try
            {
                context.Ordenes.Add(entidad);
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
