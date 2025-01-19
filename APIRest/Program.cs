using APIRest;
using APIRest.Data;
using APIRest.Repositorio;
using APIRest.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(); // MODIFIQUE PARA USAR PATCH

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SERVICIO PARA DB
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// SERVICIO PARA AUTOMAP
builder.Services.AddAutoMapper(typeof(MappingConfig));

// SERVICIO PARA INTERFAZ
builder.Services.AddScoped<IPeliculaRepositorio, PeliculaRepositorio>();

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
