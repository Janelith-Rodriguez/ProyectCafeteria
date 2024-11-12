using AutoMapper;
using ProyectCafeteria.BD.Data.Entity;
using ProyectCafeteria.Shared.DTO;

namespace ProyectCafeteria.Server.Util
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CrearUsuarioDTO, Usuario>();
            CreateMap<CrearOrdenDTO, Orden>();
            CreateMap<CrearProductoDTO, Producto>();
            CreateMap<CrearCarritoDTO, Carrito>();


            //CreateMap<Orden, CrearOrdenDTO>();
        }
    }
}