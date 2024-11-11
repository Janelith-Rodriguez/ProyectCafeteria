using Microsoft.EntityFrameworkCore;
using ProyectCafeteria.BD.Data;
using ProyectCafeteria.Server.Repositorio;
using System.Text.Json.Serialization;

//----------------------------------------------------------------------------------------------------------
//Configuracion de los servicios en el constructor de la aplicación
var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddControllersWithViews().AddJsonOptions(
   x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(op => op.UseSqlServer("name=conn"));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IOrdenRepositorio, OrdenRepositorio>();
builder.Services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
builder.Services.AddScoped<ICarritoRepositorio, CarritoRepositorio>();

//----------------------------------------------------------------------------------------------------------
//Construcción de la aplicación
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
