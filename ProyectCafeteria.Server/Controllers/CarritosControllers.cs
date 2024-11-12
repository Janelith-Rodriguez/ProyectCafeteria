using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectCafeteria.BD.Data;
using ProyectCafeteria.BD.Data.Entity;
using ProyectCafeteria.Server.Repositorio;
using ProyectCafeteria.Shared.DTO;

namespace ProyectCafeteria.Server.Controllers
{
    [ApiController]
    [Route("api/Carritos")]
    public class CarritosControllers : ControllerBase
    {
        private readonly ICarritoRepositorio repositorio;
        private readonly IMapper mapper;

        public CarritosControllers(ICarritoRepositorio repositorio,
                                    IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }
        [HttpGet]   // Método para ver el carrito
        public async Task<ActionResult<List<Carrito>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpPost]   // Método para crear un nuevo producto al carrito
        public async Task<ActionResult<int>> Post(CrearCarritoDTO entidadDTO)
        {
            try
            {
                //Carrito entidad = new Carrito();             
                //entidad.UsuarioId = entidadDTO.UsuarioId;
                //entidad.OrdenId = entidadDTO.OrdenId;
                //entidad.Cantidad = entidadDTO.Cantidad;

                Carrito entidad = mapper.Map<Carrito>(entidadDTO);

                return await repositorio.Insert(entidad);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
