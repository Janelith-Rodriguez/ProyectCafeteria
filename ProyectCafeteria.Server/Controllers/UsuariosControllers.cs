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
    [Route("api/Usuarios")]
    public class UsuariosControllers : ControllerBase
    {
        private readonly IUsuarioRepositorio repositorio;
        private readonly IMapper mapper;

        public UsuariosControllers(IUsuarioRepositorio repositorio,
                                    IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]   // Método para ver todos los usuarios
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")] //api/Usuarios/2------------ // Método para obtener un usuario por su ID
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            Usuario? c = await repositorio.SelectById(id);
            if (c == null)
            {
                return NotFound();
            }
            return c;
        }

        ////[HttpGet("{cod}")] //api/Usuarios/2------------ // Método para obtener un usuario por su ID
        ////public async Task<ActionResult<Usuario>> GetByCod(string cod)
        ////{
        ////    Usuario? c = await context.Usuarios
        ////              .FirstOrDefaultAsync(x => x.Codigo == cod);
        ////    if (c == null)
        ////    {
        ////        return NotFound();
        ////    }
        ////    return c;
        ////}

        [HttpGet("existe/{id:int}")] //api/Usuarios/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }

        [HttpPost]   // Método para crear un nuevo usuario
        public async Task<ActionResult<int>> Post(CrearUsuarioDTO entidadDTO)
        {
            try
            {
                //Usuario entidad = new Usuario();
                //entidad.Nombre= entidadDTO.Nombre;
                //entidad.Email= entidadDTO.Email;
                //entidad.Password= entidadDTO.Password;

                Usuario entidad = mapper.Map<Usuario>(entidadDTO);

                return await repositorio.Insert(entidad);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id:int}")]  //api/Usuarios/2----------// Método para actualizar un usuario existente
        public async Task<ActionResult> Put(int id, [FromBody] Usuario entidad)
        {
            try
            {
                if (id != entidad.Id)
                {
                    return BadRequest("Datos Incorrectos");
                }
                var c = await repositorio.Update(id, entidad);

                if (!c)
                {
                    return BadRequest("No se pudo actualizar el usuario");
                }
                return Ok();

                //c.Nombre = entidad.Nombre;
                //c.Email = entidad.Email;
                //c.Password = entidad.Password;
                //c.Activo = entidad.Activo;

                //try
                //{
                //    await repositorio.Update(id, c);
                //    return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            //var resp = await repositorio.Delete(id);
            //if (!resp)
            //{
            //    { return BadRequest("El usuario no se puede borrar."); }
            //    return Ok();
            //}
            var existe = await repositorio.Existe(id);
            if (!existe)
            {
                return NotFound($"El usuario {id} no existe.");
            }
            if (await repositorio.Delete(id)) 
            {
                return Ok();
            }
            else 
            {
                return BadRequest();
            }
        }
    }
}
