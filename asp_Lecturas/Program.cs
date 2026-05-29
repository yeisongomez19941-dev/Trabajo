using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// DbContext
builder.Services.AddDbContext<Conexion>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("string_conexion")));


// Registro de todas las interfaces con sus implementaciones
builder.Services.AddScoped<IAutoresNegocio, AutoresNegocio>();
builder.Services.AddScoped<ICalendarioLecturasNegocio, CalendarioLecturasNegocio>();
builder.Services.AddScoped<IConfiguracionUsuariosNegocio, ConfiguracionUsuariosNegocio>();
builder.Services.AddScoped<IEditorialesNegocio, EditorialesNegocio>();
builder.Services.AddScoped<IEstadisticasNegocio, EstadisticasNegocio>();
builder.Services.AddScoped<IEstadoLecturasNegocio, EstadoLecturasNegocio>();
builder.Services.AddScoped<IFavoritosNegocio, FavoritosNegocio>();
builder.Services.AddScoped<IGenerosNegocio, GenerosNegocio>();
builder.Services.AddScoped<IHistorialLecturasNegocio, HistorialLecturasNegocio>();
builder.Services.AddScoped<ILecturasNegocio, LecturasNegocio>();
builder.Services.AddScoped<ILibrosNegocio, LibrosNegocio>();
builder.Services.AddScoped<ILogrosNegocio, LogrosNegocio>();
builder.Services.AddScoped<IMetaLecturasNegocio, MetaLecturasNegocio>();
builder.Services.AddScoped<INotasNegocio, NotasNegocio>();
builder.Services.AddScoped<INotificacionesNegocio, NotificacionesNegocio>();
builder.Services.AddScoped<IProgresoLecturasNegocio, ProgresoLecturasNegocio>();
builder.Services.AddScoped<IRecomendacionesNegocio, RecomendacionesNegocio>();
builder.Services.AddScoped<IResenasNegocio, ResenasNegocio>();
builder.Services.AddScoped<ISeccionLecturasNegocio, SeccionLecturasNegocio>();
builder.Services.AddScoped<IUsuariosNegocio, UsuariosNegocio>();
builder.Services.AddScoped<IAuditoriasNegocio, AuditoriasNegocio>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

