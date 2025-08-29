using Electronic.Logic.Data;
using Microsoft.EntityFrameworkCore;

// Define el nombre de la política de CORS. Usar una constante evita errores tipográficos.
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Añadir servicios para la conexión a la base de datos SQL Server y DbContext.
builder.Services.AddDbContext<ElectronicDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Agrega los servicios de CORS al contenedor de inyección de dependencias.
// Aquí se define la política de seguridad para el acceso de otras aplicaciones.
var origenesPermitidos = builder.Configuration.GetValue<String>("OrigenesPermitidos")!.Split(",");

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>{
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

// La llamada a UseRouting debe ir antes de UseCors para que funcione correctamente.
app.UseRouting();

// Se habilita el middleware de CORS y se le indica que use la política que definimos.
app.UseCors(MyAllowSpecificOrigins);

// La llamada a UseAuthorization debe ir después de UseCors.
app.UseAuthorization();

app.MapControllers();

app.Run();