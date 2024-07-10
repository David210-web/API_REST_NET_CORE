using API_REST.DTOs;
using API_REST.Models;
using API_REST.Repository;
using API_REST.Services;
using FluentValidation;
using FluentValidation.Validators;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BibliotecaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyeccion de dependencias
//usuarios
builder.Services.AddScoped<IUsuarioRepository,UsuarioServices>();
builder.Services.AddScoped<IValidator<Usuario>,UsuarioValidator>();
//categorias
builder.Services.AddScoped<ICategoryRepository,CategoriaServices>();
builder.Services.AddScoped<IValidator<Categoria>, CategoriaValidator>();
//autores
builder.Services.AddScoped<IAutoresRepository, AutoresServices>();
builder.Services.AddScoped<IValidator<Autore>, AutoresValidator>();
//libros
builder.Services.AddScoped<ILibroRepository, LibroServices>();
builder.Services.AddScoped<IValidator<Libro>, LibroValidator>();
//prestamos
builder.Services.AddScoped<IPrestamoRepository, PrestamosServices>();
builder.Services.AddScoped<IValidator<Prestamo>, PrestamosValidator>();


//dto's
builder.Services.AddScoped<IValidator<LibroCreateDTO>,LibroDTOValidator>();
builder.Services.AddScoped<IValidator<PrestamoCreateDTO>,PrestamoDTOValidator>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
