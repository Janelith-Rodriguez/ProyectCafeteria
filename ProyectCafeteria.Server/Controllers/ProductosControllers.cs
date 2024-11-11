using Microsoft.AspNetCore.Mvc;
using ProyectCafeteria.BD.Data.Entity;
using ProyectCafeteria.BD.Data;
using Microsoft.EntityFrameworkCore;
using ProyectCafeteria.Shared.DTO;
using AutoMapper;

namespace ProyectCafeteria.Server.Controllers
{
    [ApiController]
    [Route("api/Productos")]
    public class ProductosControllers : ControllerBase
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public ProductosControllers(Context context,
                                    IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]   // Método para ver todas las productos
        public async Task<ActionResult<List<Producto>>> Get()
        {
            return await context.Productos.ToListAsync();
        }

        [HttpPost]   // Método para crear un nuevo producto
        public async Task<ActionResult<int>> Post(CrearProductoDTO entidadDTO)
        {
            try
            {
                //Producto entidad = new Producto();
                //entidad.Nombre = entidadDTO.Nombre;
                //entidad.Descripcion = entidadDTO.Descripcion;
                //entidad.Precio = entidadDTO.Precio;
                //entidad.Stock = entidadDTO.Stock;
                //entidad.CarritoId = entidadDTO.CarritoId;

                Producto entidad = mapper.Map<Producto>(entidadDTO);

                context.Productos.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception err)
            {
                return BadRequest(err.InnerException.Message);
            }
        }
    }
}
