using Microsoft.EntityFrameworkCore;

namespace ApiPeliculas.Data
{
    public class ApiPeliculasContext : DbContext
    {        
        public ApiPeliculasContext(DbContextOptions<ApiPeliculasContext> options) : base(options)
        {            
        }
        public DbSet<Categorias> Categorias { get; set; }
    }
}