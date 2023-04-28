using System.ComponentModel.DataAnnotations;

namespace Api_Peliculas.Model.Dtos
{
    public class PeliculaDto
    {
        
        public int ID_Pelicula { get; set; }
        [Required(ErrorMessage="El nombre es obligatorio")]
        public string Nombre_Pel { get; set; }
        public string RutaImagen { get; set; }
        [Required(ErrorMessage ="La descripcion es obligatoria")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage="La Duración es obligatoria")]
        public int Duracion { get; set; }
        public enum TipoClasificacion 
        { Siente, Trece, Dieciseis, Diecioshos }
        public TipoClasificacion Clasificacion { get; set; }
        public DateTime Fecha_Creacion { get; set; }               
        public int ID_Categoria { get; set; }
        
    }
}