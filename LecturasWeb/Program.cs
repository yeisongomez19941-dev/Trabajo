using LecturasWeb.Data;
using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Infrastructure;



var builder = WebApplication.CreateBuilder(args);
//Proteger todas las ventanas excepto las /
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/");
    options.Conventions.AllowAnonymousToPage("/Index");
    options.Conventions.AllowAnonymousToPage("/Privacy");
    options.Conventions.AllowAnonymousToPage("/Account/Login"); // hace parte del Login
    options.Conventions.AllowAnonymousToPage("/Libros"); // dejara ver /Libros
    options.Conventions.AllowAnonymousToFolder("/Libros");//dejara ver todo lo que este dentro de /Libros
    options.Conventions.AllowAnonymousToPage("/CalendarioLecturas");
    options.Conventions.AllowAnonymousToPage("/Account/Registrar");//para que no pida inicio de seccion en el Register

});
// Identity
builder.Services.AddDbContext<AppIdentityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("string_conexion")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddDefaultTokenProviders();

// DbContext
builder.Services.AddDbContext<Conexion>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("string_conexion")));

// Interfaces
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
QuestPDF.Settings.License = LicenseType.Community;

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
/* Pipeline */
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapStaticAssets();
app.MapRazorPages().WithStaticAssets();
using (var scope = app.Services.CreateScope())
{
    await SeedData.InicializarAsync(scope.ServiceProvider);
}

app.Run();