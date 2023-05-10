using System;
using Api_Peliculas.Model;
using Api_Peliculas.Repositorio.IRepositorio;
using Api_Peliculas.Data;

namespace Api_Peliculas.Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly ApiPeliculasContext _db;

        public CategoriaRepositorio(ApiPeliculasContext db)
        {
            _db = db;
        }
        public bool ActualizarCategoria(Categoria categoria)
        {
            categoria.Fecha_Creacion = DateTime.Now;
            _db.Categoria.Update(categoria);
            return Guardar();
        }
        public bool BorrarCategoria(Categoria categoria)
        {
            _db.Categoria.Remove(categoria);
            return Guardar();
        }
        public bool CrearCategoria(Categoria categoria)
        {
            categoria.Fecha_Creacion = DateTime.Now;
            _db.Categoria.Add(categoria);
            return Guardar();
        }
        public bool ExisteCategoria(string nombre)
        {
            bool valor = _db.Categoria.Any(c => c.Nombre_Cat.ToLower().Trim() == nombre.ToLower().Trim());
            return valor;
        }
        public bool ExisteCategoria(int  id)
        {
            bool valor = _db.Categoria.Any(c => c.ID_Categoria == id);
            return valor;
        }
        public Categoria GetCategoria(int id)
        {
            return _db.Categoria.FirstOrDefault(c => c.ID_Categoria == id);
        }
        public ICollection<Categoria> GetCategorias()
        {
            return _db.Categoria.OrderBy(c => c.ID_Categoria).ToList();
        }        
        public bool Guardar()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }        
    }

}