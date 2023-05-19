using Api_Peliculas.Model;
using Api_Peliculas.Model.Dtos;

namespace Api_Peliculas.Repositorio.IRepositorio
{
    public interface IUsuarioRepositorio
    {
        ICollection<Usuario> GetUsuarios();
        Usuario GetUsuario(int id);
        bool IsUnique(string usuario);
        Task<Usuario> Registro(UsuarioRegistroDto usuarioRegistro);
        Task<UsuarioLoginRespuestaDto> Login(UsuarioLoginDto usuarioLoginDto);
        
    }
}