using AutoMapper;

namespace TechOil.Models.Dtos
{
    public class ProfileProyectos : Profile
    {
        public ProfileProyectos()
        {
            CreateMap<Proyecto, ProyectosDto>();
        }
    }
}