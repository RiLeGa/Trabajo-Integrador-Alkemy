using AutoMapper;

namespace TechOil.Models.Dtos
{
    public class ProfileUsuarios: Profile
    {
        public ProfileUsuarios()
        {
            CreateMap<Usuario, UsuariosDto>();
        }
    }
}

