using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Api_Peliculas.Model.Dtos
{
    public class UsuarioRegistroDto
    {    
        [Required(ErrorMessage ="El nombre es requerido")]
        public string Nombre_Usuario { get; set; }
        [Required(ErrorMessage = "El usuario es requerido")]
        public string User_Usuario { get; set; }
        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Password { get; set; }
        public string Role  { get; set;}
    }
}