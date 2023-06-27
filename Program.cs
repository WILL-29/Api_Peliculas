using Microsoft.EntityFrameworkCore;
using Api_Peliculas.Model;
using Api_Peliculas.Data;
using Api_Peliculas.Repositorio;
using Api_Peliculas.Repositorio.IRepositorio;
using AutoMapper;
using Api_Peliculas.ApiPeliculasMapper;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

//Configuramos el dbcontext que se usará para conectarse a SQL
builder.Services.AddDbContext<ApiPeliculasContext>(opciones => 
{
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSql"));
});

//Agregamos los repositorios  -- todos los repositorios deben ser agregados aquí
builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
builder.Services.AddScoped<IPeliculaRepositorio, PeliculaRepositorio>();
 builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

//Agregamos el AutoMapper, para que esto funcione debemos tener instalado el paquete AutoMapper.Extensions.Microsoft.DependencyInjections
builder.Services.AddAutoMapper(typeof(ApiPeliculasMapper));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Agregando Cors
builder.Services.AddCors(p => p.AddPolicy("PolicyCors", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Agregando el Cors a nuestr APP
app.UseCors("PolicyCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
