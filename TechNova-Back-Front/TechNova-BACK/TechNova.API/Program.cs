using Microsoft.EntityFrameworkCore;
using TechNova.Logic.Data;
using TechNova.Logic.Interfaces;
using TechNova.Logic.Repository;
using TechNova.Logic.Services;

//Definir nombre politica cors
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

//Configurar Servicio de DataBase
builder.Services.AddDbContext<TechNovaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//-----SE Me OLVIDARON ESTAS LINEAS
// Se agregan las interfaces para inyecci�n de dependencias
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IMarcaRepository,  MarcaRepository>();
builder.Services.AddScoped<IMarcaService,  MarcaService>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Leer origins permitidos
var origenesPermitidos = builder.Configuration.GetValue<String>("OrigenesPermitidos")!.Split(',');

//Add servicios Cors
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

//Enrruta las solicitudes a los controladores correctos
app.UseRouting();

//Habilita politica cors
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
