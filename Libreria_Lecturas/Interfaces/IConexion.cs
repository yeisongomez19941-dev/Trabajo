using Libreria_Lecturas.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Libreria_Lecturas.Interfaces
{
    public interface IConexion
    {
      

        DbSet<Autores> Autores { get; set; }
        DbSet<CalendarioLecturas> CalendarioLecturas { get; set; }
        DbSet<ConfiguracionUsuarios> ConfiguracionUsuarios { get; set; }
        DbSet<Editoriales> Editoriales { get; set; }
        DbSet<Estadisticas> Estadisticas { get; set; }
        DbSet<EstadoLecturas> EstadoLecturas { get; set; }
        DbSet<Favoritos> Favoritos { get; set; }
        DbSet<Generos> Generos { get; set; }
        DbSet<HistorialLecturas> HistorialLecturas { get; set; }
        DbSet<Lecturas> Lecturas { get; set; }
        DbSet<Libros> Libros { get; set; }
        DbSet<Logros> Logros { get; set; }
        DbSet<MetaLecturas> MetaLecturas { get; set; }
        DbSet<Notas> Notas { get; set; }
        DbSet<Notificaciones> Notificaciones { get; set; }
        DbSet<ProgresoLecturas> ProgresoLecturas { get; set; }
        DbSet<Recomendaciones> Recomendaciones { get; set; }
        DbSet<Resenas> Resenas { get; set; }
        DbSet<SeccionLecturas> SeccionLecturas { get; set; }
        DbSet<Usuarios> Usuarios { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}
