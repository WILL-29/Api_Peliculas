using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Peliculas.Repositorio.IRepositorio;
using Api_Peliculas.Data;
using Api_Peliculas.Model;
using Api_Peliculas.Model.Dtos;
using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using System.IdentityModel.Tokens;
using System.IdentityModel;
using System.Text;


namespace Api_Peliculas.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ApiPeliculasContext _db;
        private string claveSecreta;
        public UsuarioRepositorio(ApiPeliculasContext bd, IConfiguration config)
        {
            _db = bd;
            claveSecreta = config.GetValue<string>("ApiSettings:Secreta");
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
        public async Task<Usuario> Registro(UsuarioRegistroDto usuarioRegistroDto)
        {
            var PasswordEncriptado = ObtenerMd5(usuarioRegistroDto.Password);
            var usuario = new Usuario()
            {
                User_Usuario = usuarioRegistroDto.User_Usuario,
                Nombre_Usuario = usuarioRegistroDto.Nombre_Usuario,
                Password = PasswordEncriptado,            
                Role = usuarioRegistroDto.Role
            };     

            _db.Usuario.Add(usuario);
            await _db.SaveChangesAsync();
            usuario.Password = PasswordEncriptado;
            return (usuario);
        }
        public async Task<UsuarioLoginRespuestaDto> Login(UsuarioLoginDto usuarioLogin)
        {
            var PasswordEncriptado = ObtenerMd5(usuarioLogin.Password);

            var usuario = _db.Usuario.FirstOrDefault(u => u.User_Usuario.ToLower() == usuarioLogin.User_Usuario.ToLower() && u.Password == usuarioLogin.Password);

            if (usuario == null)
            {
                return new UsuarioLoginRespuestaDto()
                {
                  Token = "",
                  Usuario = null
                };
            }
            
            var manejadorToken = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(claveSecreta);

            var tokenDescriptor = new SecurityTokenDescriptor
            {

            };

            throw new NotImplementedException();
            //Esto se hará mañana
        }

        public static string ObtenerMd5 (string PalabraEncriptar)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(PalabraEncriptar);
            data = x.ComputeHash(data);
            string resp = "";
            for (int i = 0; i < data.Length; i++)            
                resp += data[i].ToString("x2").ToLower();
            return resp;
        }
        
    }
}