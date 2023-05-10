using Api_Peliculas.Model;
using Api_Peliculas.Model.Dtos;

namespace Api_Peliculas.Repositorio.IRepositorio
{
    public interface IUsuarioRepositorio
    {
        ICollection<Usuario> GetUsuarios();
        Usuario GetUsuario(int id);
        bool IsUnique(string usuario);
        Task<UsuarioLoginRespuestaDto> Login(UsuarioLoginDto usuarioLogin);
        Task<UsuarioRegistroDto> Registro(UsuarioRegistroDto usuarioRegistro);
    }
}