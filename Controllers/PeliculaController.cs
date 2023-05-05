using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api_Peliculas.Repositorio.IRepositorio;
using AutoMapper;
using Api_Peliculas.Model.Dtos;
using Api_Peliculas.Model;
  
namespace Api_Peliculas.Controllers
{
    [ApiController]
    [Route("api/pelicula")]
    public class PeliculaController : ControllerBase
    {
        private readonly IPeliculaRepositorio _pelRepo;
        private readonly IMapper _mapper;
        public PeliculaController(IPeliculaRepositorio pelRepo, IMapper mapper)
        {
            _pelRepo = pelRepo;
            _mapper = mapper;
        }   
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPeliculas()
        {
            var ListaPeliculas = _pelRepo.GetPeliculas();
            //return Ok(ListaPeliculas);

            var ListaPeliculasDto = new List<PeliculaDto>();
            foreach (var pelicula in ListaPeliculas)
            {
                ListaPeliculasDto.Add(_mapper.Map<PeliculaDto>(pelicula));
            }
            return Ok(ListaPeliculasDto);
        }
        [HttpGet("{id:int}", Name = "GetPelicula")]          
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPelicula(int id)
        {                           
            if (!_pelRepo.ExistePelicula(id))
            {
                return NotFound();
            }
            var pelicula = _mapper.Map<PeliculaDto>(_pelRepo.GetPelicula(id));
            return Ok(pelicula);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(PeliculaDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]        
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CrearPelicula([FromBody] PeliculaDto peliculaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (peliculaDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_pelRepo.ExistePelicula(peliculaDto.Nombre_Pel))
            {
                ModelState.AddModelError("","La película existe");
                return StatusCode(400, ModelState);
            } 
            Pelicula pelicula = _mapper.Map<Pelicula>(peliculaDto);
            if (!_pelRepo.CrearPelicula(pelicula))
            {
                ModelState.AddModelError("","Algo salió mal creando la película " + peliculaDto.Nombre_Pel);
                return StatusCode(500, ModelState);                
            }
            //return Ok();  
            return CreatedAtAction("GetPelicula", new { id = pelicula.ID_Pelicula }, pelicula);            
        }

        [HttpPatch("{id:int}", Name="ActualizarPeliculaPath")]
        [ProducesResponseType(201, Type = typeof(PeliculaDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarPeliculaPath(int id, [FromBody] PeliculaDto peliculaDto)
        {
             if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (peliculaDto == null  || id != peliculaDto.ID_Pelicula)
            {
                return BadRequest(ModelState);
            }
            Pelicula pelicula = _mapper.Map<Pelicula>(peliculaDto);
            if (!_pelRepo.ActualizarPelicula(pelicula))
            {
                ModelState.AddModelError("","Algo salió mal actualizando la película " + pelicula.Nombre_Pel);
                return StatusCode(500, ModelState);                
            }        
            return NoContent();            
        }


        [HttpDelete("{id:int}", Name = "BorrarPelicula")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BorrarPelicula(int id)
        {   
            if (!_pelRepo.ExistePelicula(id))
            {
                return NotFound();
            }        
            var pelicula = _pelRepo.GetPelicula(id);            
            if (id != pelicula.ID_Pelicula)
            {
                return BadRequest(ModelState);
            }
            if (!_pelRepo.BorrarPelicula(pelicula))
            {
                ModelState.AddModelError("","Algo salió mal eliminando la categoría");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        
        [HttpGet("{ID_Categoria:int}", Name = "GetPeliculEnCategorias")]   
        //[HttpGet("GetPeliculasEnCategorias/{id:int}")]   
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPeliculasEnCategorias(int ID_Categoria)
        {
            var ListaPeliculas = _pelRepo.GetPeliculasEnCategorias(ID_Categoria);
            //return Ok(ListaPeliculas);
            if (ListaPeliculas == null)
            {
                return NotFound();
            }

            var ListaPeliculasDto = new List<PeliculaDto>();
            foreach (var pelicula in ListaPeliculas)
            {
                ListaPeliculasDto.Add(_mapper.Map<PeliculaDto>(pelicula));
            }
            return Ok(ListaPeliculasDto);
        }        
        [HttpGet("BuscarPeliculas")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult BuscarPeliculas(string Nombre_Pel)
        {
            var ListaPeliculas = _pelRepo.BuscarPeliculas(Nombre_Pel.Trim());
            //return Ok(ListaPeliculas);
            if (ListaPeliculas == null)
            {
                return NotFound();
            }
            
            var ListaPeliculasDto = new List<PeliculaDto>();
            foreach (var pelicula in ListaPeliculas)
            {
                ListaPeliculasDto.Add(_mapper.Map<PeliculaDto>(pelicula));
            }
            return Ok(ListaPeliculasDto);
        }

    }
}