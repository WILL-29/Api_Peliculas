using System;
using System.ComponentModel.DataAnnotations;
namespace Api_Peliculas.Model.Dtos
{
    public class CrearCategoriaDto
    {           
        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(60, ErrorMessage = "El número máximo de caracteres es 60")]
        public string Nombre_Cat { get; set; }
    }
}