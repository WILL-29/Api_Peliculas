using Microsoft.EntityFrameworkCore;
using Api_Peliculas.Model;
//using System.Data.Entity;

namespace Api_Peliculas.Data
{
    public class ApiPeliculasContext : DbContext
    {        
        public ApiPeliculasContext(DbContextOptions<ApiPeliculasContext> options) : base(options)
        {            
        }
        public DbSet<Categorias> Categorias { get; set; }
    }
}