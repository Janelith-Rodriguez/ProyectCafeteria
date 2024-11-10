using Microsoft.AspNetCore.Mvc;
using ProyectCafeteria.BD.Data.Entity;
using ProyectCafeteria.BD.Data;
using Microsoft.EntityFrameworkCore;

namespace ProyectCafeteria.Server.Controllers
{
    [ApiController]
    [Route("api/Usuarios")]
    public class UsuariosControllers : ControllerBase
    {
        private readonly Context context;

        public UsuariosControllers(Context context)
        {
            this.context = context;
        }

        [HttpGet]   // Método para ver todos los usuarios
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            return await context.Usuarios.ToListAsync();
        }

        //[HttpGet("{id:int}")] //api/Usuarios/2------------ // Método para obtener un usuario por su ID
        //public async Task<ActionResult<Usuario>> Get(int id)
        //{
        //    Usuario? c = await context.Usuarios
        //              .FirstOrDefaultAsync(x => x.Id == id);
        //    if (c == null)
        //    {
        //        return NotFound();
        //    }
        //    return c;
        //}

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

        //[HttpGet("existe/{id:int}")] //api/Usuarios/existe/2
        //public async Task<ActionResult<bool>> Existe(int id)
        //{
        //    var existe = await context.Usuarios.AnyAsync(x => x.Id == id);
        //    return existe;
        //}

        [HttpPost]   // Método para crear un nuevo usuario
        public async Task<ActionResult<int>> Post(Usuario entidad)
        {
            try
            {
                context.Usuarios.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id:int}")]  //api/Usuarios/2----------// Método para actualizar un usuario existente
        public async Task<ActionResult> Put(int id, [FromBody] Usuario entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos Incorrectos");
            }
            var c = await context.Usuarios
                          .Where(reg => reg.Id == id)
                          .FirstOrDefaultAsync();
            if (c == null)
            {
                return NotFound("No existe el usuario buscado.");
            }

            c.Nombre = entidad.Nombre;
            c.Email = entidad.Email;
            c.Password = entidad.Password;
            c.Activo = entidad.Activo;

            try
            {
                context.Usuarios.Update(c);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //[HttpDelete("{id:int}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    var existe = await context.Usuarios.AnyAsync(x => x.Id == id);
        //    if (!existe)
        //    {
        //        return NotFound($"El usuario {id} no existe.");
        //    }
        //    Usuario EntidadABorrar = new Usuario();
        //    EntidadABorrar.Id = id;

        //    context.Remove(EntidadABorrar);
        //    await context.SaveChangesAsync();
        //    return Ok();
        //}
    }
}
