namespace Api_Peliculas.Repositorio.IRepositorio
{
    public interface ICategoriaRepositorio
    {
         ICollection<Categorias> GetCategorias();
         Categorias GetCategorias(int id);
         bool ExisteCategoria(string nombre);
         bool ExisteCategoria(int  id);
         bool CrearCategoria(Categorias categoria);
         bool ActualizarCategoria(Categorias categoria);
         bool BorrarCategoria(Categorias categoria);
         bool Guardar();

    }
}