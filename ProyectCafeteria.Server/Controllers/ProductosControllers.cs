using Microsoft.AspNetCore.Mvc;
using ProyectCafeteria.BD.Data.Entity;
using ProyectCafeteria.BD.Data;
using Microsoft.EntityFrameworkCore;
using ProyectCafeteria.Shared.DTO;
using AutoMapper;
using ProyectCafeteria.Server.Repositorio;

namespace ProyectCafeteria.Server.Controllers
{
    [ApiController]
    [Route("api/Productos")]
    public class ProductosControllers : ControllerBase
    {
        private readonly IProductoRepositorio repositorio;
        private readonly IMapper mapper;

        public ProductosControllers(IProductoRepositorio repositorio,
                                    IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }
        [HttpGet]   // Método para ver todas las productos
        public async Task<ActionResult<List<Producto>>> Get()
        {
            return await repositorio.Select();
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

                return await repositorio.Insert(entidad);
            }
            catch (Exception err)
            {
                return BadRequest(err.InnerException.Message);
            }
        }
    }
}
