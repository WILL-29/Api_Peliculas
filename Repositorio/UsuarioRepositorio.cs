using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Peliculas.Repositorio.IRepositorio;
using Api_Peliculas.Data;
using Api_Peliculas.Model;
using Api_Peliculas.Model.Dtos;

namespace Api_Peliculas.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ApiPeliculasContext _db;
        public UsuarioRepositorio(ApiPeliculasContext bd)
        {
            _db = bd;
        }
        
        public ICollection<Usuario> GetUsuarios()
        {
            return _db.Usuario.OrderBy(u => u.Nombre_Usuario).ToList();
        }
        public Usuario GetUsuario(int id)
        {
            return _db.Usuario.FirstOrDefault(u => u.ID_Usuario == id);
        }

        public bool IsUnique(string usuario)
        {
            return _db.Usuario.Any(u => u.User_Usuario == usuario);
        }
        public Task<UsuarioLoginRespuestaDto> Login(UsuarioLoginDto usuarioLogin)
        {
            
        }
        public Task<UsuarioRegistroDto> Registro(UsuarioRegistroDto usuarioRegistro)
        {

        }

    }
}