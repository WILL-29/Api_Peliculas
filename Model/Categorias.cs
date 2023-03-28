using Api_Peliculas.Data;
using System.ComponentModel.DataAnnotations;

namespace Api_Peliculas.Model
{
    public class Categorias
    {       
        [Key]
        public int ID_Categoria { get; set; }
        [Required]
        public string Nombre_Cat { get; set; }
        public DateTime Fecha_Creacion { get; set; }
    }
    public List<Categorias> obtenerCategorias()
    {
        ApiPeliculasContext db = new ApiPeliculasContext();
        var Categorias = db.Categorias.ToList();
        return Categorias;
        //test
    }
}
