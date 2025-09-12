using Concierto.Logic.Data;
using Concierto.Logic.Interfaces;
using Concierto.Logic.Repository;
using Concierto.Logic.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Concierto.Logic.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

//Definir nombre politica cors
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

//Configurar Servicio de DataBase
builder.Services.AddDbContext<ConciertoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ----- NUEVA CONFIGURACIÓN PARA AUTENTICACIÓN -----
// 1. Configurar Identity con la clase de usuario personalizada y el DbContext
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<ConciertoDbContext>()
.AddDefaultTokenProviders();

// 2. Configurar JWT Bearer Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
    };
});

// 3. Agregar el servicio de generación de JWT
builder.Services.AddScoped<JwtService>();

// Se agregan las interfaces para inyección de dependencias
//Admin
builder.Services.AddScoped<IAdministradorRepository, AdministradorRepository>();
builder.Services.AddScoped<IAdministradorService, AdministradorService>();
//Empleado
builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
//Cliente
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();
//Lugar
builder.Services.AddScoped<ILugarRepository, LugarRepository>();
builder.Services.AddScoped<ILugarService, ILugarService>();
//Cantante
builder.Services.AddScoped<ICantanteRepository, CantanteRepository>();
builder.Services.AddScoped<ICantanteService, CantanteService>();
//Evento
builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddScoped<IEventoService, EventoService>();
//Asiento
builder.Services.AddScoped<IAsientoRepository, AsientoRepository>();
builder.Services.AddScoped<IAsientoService, AsientoService>();
//Boleto
builder.Services.AddScoped<IBoletoRepository, BoletoRepository>();
builder.Services.AddScoped<IBoletoService, BoletoService>();

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

// Enrruta las solicitudes a los controladores correctos
app.UseRouting();

// ----- NUEVOS COMPONENTES DEL MIDDLEWARE -----
// 1. Habilitar el middleware de autenticación
app.UseAuthentication();
// 2. Habilitar el middleware de autorización
app.UseAuthorization();
// 3. Habilitar politica cors
app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
