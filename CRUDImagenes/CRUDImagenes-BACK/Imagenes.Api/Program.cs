using Imagenes.Logic.Data;
using Imagenes.Logic.Interface;
using Imagenes.Logic.Repository;
using Imagenes.Logic.Service;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ImagenDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IObjetoRepository, ObjetoRepository>();
builder.Services.AddScoped<IObjetoService, ObjetoService>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var origenesPermitidos = builder.Configuration.GetValue<String>("OrigenesPermitidos")!.Split(",");

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        policy.WithOrigins(origenesPermitidos).AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseRouting();

// ** ESTA LÍNEA ES LA CLAVE PARA SERVIR ARCHIVOS ESTÁTICOS DESDE wwwroot **
app.UseStaticFiles();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
