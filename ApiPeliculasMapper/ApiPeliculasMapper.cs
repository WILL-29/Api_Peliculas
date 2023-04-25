using AutoMapper;
using Api_Peliculas.Model;
using Api_Peliculas.Model.Dtos;
namespace Api_Peliculas.ApiPeliculasMapper
{
    public class ApiPeliculasMapper : Profile
    {
        public ApiPeliculasMapper()
        {            
            //Aquí se crea los mapas desde el modelo al DTO, y se agregar el .Reverse() para que funcionar desde el DTO a al modelo (al contrario)
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<Categoria, CrearCategoriaDto>().ReverseMap();
        }
    }
}