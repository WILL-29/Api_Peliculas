using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Api_Peliculas.Model
{
    public class Usuario
    {   
        [Key]
        public int ID_Usuario { get; set; }
        public string Nombre_Usuario { get; set; }
        public string User_Usuario { get; set; }
        public string Password { get; set; }
        public string Role  { get; set;}
    }
}