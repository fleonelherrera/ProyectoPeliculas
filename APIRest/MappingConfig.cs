using APIRest.Model;
using APIRest.Model.Dto;
using AutoMapper;

namespace APIRest
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Pelicula, PeliculaDto>().ReverseMap();
            CreateMap<Pelicula, PeliculaCreacionDto>().ReverseMap();
            CreateMap<Pelicula, PeliculaModificacionDto>().ReverseMap();
        }
    }
}
