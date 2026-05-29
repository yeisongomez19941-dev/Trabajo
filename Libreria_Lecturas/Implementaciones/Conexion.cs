using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Libreria_Lecturas.Implementaciones
{
    public class Conexion : DbContext, IConexion
    {

        public Conexion() { } // Constructor sin parámetros para permitir la creación de instancias sin necesidad de pasar opciones
        public Conexion(DbContextOptions<Conexion> options) : base(options) { }

        // Cambios
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=db_lectura;Integrated Security=True;TrustServerCertificate=true;");
            }
        }
        // hasta aca

        public DbSet<Autores> Autores { get; set; }
        public DbSet<CalendarioLecturas> CalendarioLecturas { get; set; }
        public DbSet<ConfiguracionUsuarios> ConfiguracionUsuarios { get; set; }
        public DbSet<Editoriales> Editoriales { get; set; }
        public DbSet<Estadisticas> Estadisticas { get; set; }
        public DbSet<EstadoLecturas> EstadoLecturas { get; set; }
        public DbSet<Favoritos> Favoritos { get; set; }
        public DbSet<Generos> Generos { get; set; }
        public DbSet<HistorialLecturas> HistorialLecturas { get; set; }
        public DbSet<Lecturas> Lecturas { get; set; }
        public DbSet<Libros> Libros { get; set; }
        public DbSet<Logros> Logros { get; set; }
        public DbSet<MetaLecturas> MetaLecturas { get; set; }
        public DbSet<Notas> Notas { get; set; }
        public DbSet<Notificaciones> Notificaciones { get; set; }
        public DbSet<ProgresoLecturas> ProgresoLecturas { get; set; }
        public DbSet<Recomendaciones> Recomendaciones { get; set; }
        public DbSet<Resenas> Resenas { get; set; }
        public DbSet<SeccionLecturas> SeccionLecturas { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        // Implementación explícita de los métodos de la interfaz
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public new EntityEntry<T> Entry<T>(T entity) where T : class
        {
            return base.Entry(entity);
        }
    }
}
