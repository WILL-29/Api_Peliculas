using Microsoft.EntityFrameworkCore;
using Api_Peliculas.Model;
using System.Data;

namespace Api_Peliculas.Data
{
    public class ApiPeliculasContext : DbContext
    {        
        public ApiPeliculasContext(DbContextOptions<ApiPeliculasContext> options) : base(options)
        {            
        }
        public DbSet<Categoria> Categoria {get; set;}
        public DbSet<Pelicula> Pelicula {get; set;}
        public DbSet<Usuario> Usuario {get; set;}
    }    
}