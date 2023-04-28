using Api_Peliculas.Model;

namespace Api_Peliculas.Repositorio.IRepositorio
{
    public interface IPeliculaRepositorio
    {
        ICollection<Pelicula> GetPeliculas();
        Pelicula GetPelicula(int id);
        bool ExistePelicula(string nombre);
        bool ExistePelicula(int  id);
        bool CrearPelicula(Pelicula pelicula);
        bool ActualizarPelicula(Pelicula pelicula);
        bool BorrarPelicula(Pelicula pelicula);
        //Mëtodos para buscar películas por categorías o nombres
        ICollection<Pelicula> GetPeliculasEnCategorias(int ID_Categoria);        
        ICollection<Pelicula> BuscarPeliculas(string Nombre_Pel);
        bool Guardar(); 
    }
}