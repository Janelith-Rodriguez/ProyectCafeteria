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
    [Route("api/Ordenes")]
    public class OrdenesControllers : ControllerBase
    {
        private readonly IOrdenRepositorio repositorio;
        private readonly IMapper mapper;

        public OrdenesControllers(IOrdenRepositorio repositorio,
                                  IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }
        [HttpGet]   // Método para ver todas las ordenes
        public async Task<ActionResult<List<Orden>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpPost]   // Método para crear un nuevo usuario
        public async Task<ActionResult<int>> Post(CrearOrdenDTO entidadDTO)
        {
            try
            {
                //Orden entidad = new Orden();
                //entidad.Fecha_Orden= entidadDTO.Fecha_Orden;
                //entidad.Total= entidadDTO.Total;
                //entidad.Estado= entidadDTO.Estado;
                //entidad.UsuarioId= entidadDTO.UsuarioId;

                Orden entidad = mapper.Map<Orden>(entidadDTO);

                return await repositorio.Insert(entidad);
            }
            catch (Exception err)
            {
                return BadRequest(err.InnerException.Message);
            }
        }
    }
}
