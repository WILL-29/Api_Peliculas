using System;
using Microsoft.AspNetCore.Mvc;
using Api_Peliculas.Repositorio.IRepositorio;
using AutoMapper;
using Api_Peliculas.Model.Dtos;
using Api_Peliculas.Model;
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
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetCategorias()
        {
            var ListaCategorias = _ctRepo.GetCategorias();
            //return Ok(ListaCategorias);

            var ListaCategoriasDto = new List<CategoriaDto>();
            foreach (var categoria in ListaCategorias)
            {
                ListaCategoriasDto.Add(_mapper.Map<CategoriaDto>(categoria));
            }
            return Ok(ListaCategoriasDto);
        }
        [HttpGet("{id:int}", Name = "GetCategoria")]          
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetCategoria(int id)
        {                           
            if (!_ctRepo.ExisteCategoria(id))
            {
                return NotFound();
            }
            var categoria = _mapper.Map<CategoriaDto>(_ctRepo.GetCategoria(id));
            return Ok(categoria);
        }
        [HttpPost]
        public IActionResult CrearCategoria([FromBody] CrearCategoriaDto categoriaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (categoriaDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_ctRepo.ExisteCategoria(categoriaDto.Nombre_Cat))
            {
                ModelState.AddModelError("","La categoría existe");
                return StatusCode(404, ModelState);
            } 
            Categoria categoria = _mapper.Map<Categoria>(categoriaDto);
            if (!_ctRepo.CrearCategoria(categoria))
            {
                ModelState.AddModelError("","Algo salió mal creando la categoría");
                return StatusCode(500, ModelState);                
            }
            //return Ok();  
            return CreatedAtAction("GetCategoria", new { id = categoria.ID_Categoria }, categoria);            
        }
        //public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}