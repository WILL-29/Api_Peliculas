using System;
using Api_Peliculas.Model;
using Api_Peliculas.Repositorio.IRepositorio;
using Api_Peliculas.Data;
using System.Linq;


namespace Api_Peliculas.Repositorio
{
    public class PeliculaRepositorio : IPeliculaRepositorio
    {
        private readonly ApiPeliculasContext _db;

        public PeliculaRepositorio(ApiPeliculasContext db)
        {
            _db = db;
        }
        public bool ActualizarPelicula(Pelicula pelicula)
        {
            pelicula.Fecha_Creacion = DateTime.Now;
            _db.Pelicula.Update(pelicula);
            return Guardar();
        }
        public bool BorrarPelicula(Pelicula pelicula)
        {
            _db.Pelicula.Remove(pelicula);
            return Guardar();
        }
        public bool CrearPelicula(Pelicula pelicula)
        {
            pelicula.Fecha_Creacion = DateTime.Now;
            _db.Pelicula.Add(pelicula);
            return Guardar();
        }
        public bool ExistePelicula(string nombre)
        {
            bool valor = _db.Pelicula.Any(c => c.Nombre_Pel.ToLower().Trim() == nombre.ToLower().Trim());
            return valor;
        }
        public bool ExistePelicula(int  id)
        {
            bool valor = _db.Pelicula.Any(c => c.ID_Pelicula == id);
            return valor;
        }
        public Pelicula GetPelicula(int id)
        {
            return _db.Pelicula.FirstOrDefault(c => c.ID_Pelicula == id);
        }
        public ICollection<Pelicula> GetPeliculas()
        {
            return _db.Pelicula.OrderBy(c => c.ID_Pelicula).ToList();
        }          
        public ICollection<Pelicula> GetPeliculasEnCategorias(int ID_Categoria)
        {
            return _db.Pelicula.Where(p => p.ID_Categoria == ID_Categoria).ToList();
            //return _db.Pelicula.(p => p.ID_Categoria == ID_Categoria).ToList();
        }
        public ICollection<Pelicula> GetPeliculas(string nombre)      
        {
            return _db.Pelicula.Where(p => p.Nombre_Pel.Contains(nombre)).ToList();
        }
        public bool Guardar()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }        
    }

}