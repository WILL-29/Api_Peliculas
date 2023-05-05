using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Peliculas.Model
{
    public class Pelicula
    {
        //[Required]
        [Key]
        public int ID_Pelicula { get; set; }
        //[Requiered("Error Message")]
        public string Nombre_Pel { get; set; }
        public string RutaImagen { get; set; }
        public string Descripcion { get; set; }
        public int Duracion { get; set; }
        public enum TipoClasificacion 
        { Siente, Trece, Dieciseis, Diecioshos }
        public TipoClasificacion Clasificacion { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        
        [ForeignKey("ID_Categoria")]        
        public int ID_Categoria { get; set; }
    }
}