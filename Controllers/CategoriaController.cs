using System;
using Microsoft.AspNetCore.Mvc;
using Api_Peliculas.Repositorio.IRepositorio;
using AutoMapper;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

namespace Api_Peliculas.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]  esta opción toma el nombre del controlador
    [Route("api/Categoria")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepositorio _ctRepo;
        private readonly IMapper _mapper;
        public CategoriaController(ICategoriaRepositorio ctRepo, IMapper mapper)
        {
            _ctRepo = ctRepo;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetCategorias()
        {
            var ListaCategorias = _ctRepo.GetCategorias();
            return Ok(ListaCategorias);
        }
        //public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    }
}