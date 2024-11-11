using AutoMapper;
using ProyectCafeteria.BD.Data.Entity;
using ProyectCafeteria.Shared.DTO;

namespace ProyectCafeteria.Server.Util
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CrearOrdenDTO, Orden>();
            //CreateMap<Orden, CrearOrdenDTO>();
        }
    }
}