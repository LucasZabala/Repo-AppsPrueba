using AuthApp.Logic.Data;
using AuthApp.Logic.Interfaces;
using AuthApp.Logic.Models;
using AuthApp.Logic.Repository;
using AuthApp.Logic.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// 1. Configuración del DbContext
builder.Services.AddDbContext<AuthAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Configuración de Identity
builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<AuthAppDbContext>()
    .AddDefaultTokenProviders();

// 3. Configuración de JWT
var jwtSettings = builder.Configuration.GetSection("Jwt");
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"])),
    };
});

// 4. Inyección de Dependencias
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();

// 5. Configuración de los servicios de la API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Cambiado a AddEndpointsApiExplorer
builder.Services.AddSwaggerGen(); // Agregado para usar Swagger

// 6. Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        // Se utiliza la configuración de la app, corrigiendo posibles errores de Split
        var origenesPermitidos = builder.Configuration.GetValue<string>("OrigenesPermitidos")?.Split(',') ?? Array.Empty<string>();
        policy.WithOrigins(origenesPermitidos)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// 7. Configuración del pipeline de solicitudes
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

// El middleware de CORS debe ir después de UseRouting y antes de UseAuthentication y UseAuthorization.
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();