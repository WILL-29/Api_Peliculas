using AutoMapper;
using Api_Peliculas.Model;
using Api_Peliculas.Model.Dtos;
namespace Api_Peliculas.PeliculasMapper
{
    public class PeliculasMapper : Profile
    {
        public PeliculasMapper()
        {
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<Categoria, CrearCategoriaDto>().ReverseMap();
        }
    }
}