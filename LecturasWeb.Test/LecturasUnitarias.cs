using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;

namespace LecturasWeb.Tests
{
    [TestClass]
    public class LecturasUnitarias
    {
        private Conexion _context;

        [TestInitialize]
        public void Setup()
        {
            _context = new Conexion();
        }

        [TestMethod]
        // Se colocan primero las entidades independientes con el fin de que cuando 
        public void Ejecutar()
        {
            // Primero entidades independientes
            Guardar_Autores(); Consultar_Autores(); Modificar_Autores();
            Guardar_Generos(); Consultar_Generos(); Modificar_Generos();
            Guardar_Editoriales(); Consultar_Editoriales(); Modificar_Editoriales();
            Guardar_EstadoLecturas(); Consultar_EstadoLecturas(); Modificar_EstadoLecturas();
            Guardar_Logros(); Consultar_Logros(); Modificar_Logros();
            Guardar_Usuarios(); Consultar_Usuarios(); Modificar_Usuarios();

            // Entidades que dependen de Autores, Generos
            Guardar_Libros(); Consultar_Libros(); Modificar_Libros();

            // Entidades que dependen de Usuarios
            Guardar_Estadisticas(); Consultar_Estadisticas(); Modificar_Estadisticas();
            Guardar_Notas(); Consultar_Notas(); Modificar_Notas();
            Guardar_ConfiguracionUsuarios(); Consultar_ConfiguracionUsuarios(); Modificar_ConfiguracionUsuarios();
            Guardar_Notificaciones(); Consultar_Notificaciones(); Modificar_Notificaciones();
            Guardar_MetaLecturas(); Consultar_MetaLecturas(); Modificar_MetaLecturas();
            Guardar_CalendarioLecturas(); Consultar_CalendarioLecturas(); Modificar_CalendarioLecturas();
            Guardar_Recomendaciones(); Consultar_Recomendaciones(); Modificar_Recomendaciones();
            Guardar_SeccionLecturas(); Consultar_SeccionLecturas(); Modificar_SeccionLecturas();

            // Entidades que dependen de Usuarios y Libros
            Guardar_Lecturas(); Consultar_Lecturas(); Modificar_Lecturas();
            Guardar_Favoritos(); Consultar_Favoritos(); Modificar_Favoritos();
            Guardar_Resenas(); Consultar_Resenas(); Modificar_Resenas();
            Guardar_HistorialLecturas(); Consultar_HistorialLecturas(); Modificar_HistorialLecturas();

            // Entidades que dependen de Lecturas
            Guardar_ProgresoLecturas(); Consultar_ProgresoLecturas(); Modificar_ProgresoLecturas();

            // Borrar en orden inverso
            Borrar_ProgresoLecturas();
            Borrar_Resenas();
            Borrar_Favoritos();
            Borrar_HistorialLecturas();
            Borrar_Lecturas();
            Borrar_Notas();
            Borrar_Estadisticas();
            Borrar_ConfiguracionUsuarios();
            Borrar_Notificaciones();
            Borrar_MetaLecturas();
            Borrar_CalendarioLecturas();
            Borrar_Recomendaciones();
            Borrar_SeccionLecturas();
            Borrar_Libros();
            Borrar_Usuarios();
            Borrar_Logros();
            Borrar_EstadoLecturas();
            Borrar_Editoriales();
            Borrar_Generos();
            Borrar_Autores();
        }

        // ═══════════════════════════════════════════════════════
        // AUTORES
        // ═══════════════════════════════════════════════════════
        private Autores? entidad_autores;
        private void Guardar_Autores()
        {
            _context = new Conexion();
            entidad_autores = new Autores { Nombre = "UT-" + DateTime.Now, Nacionalidad = "Colombiana", FechaNacimiento = DateTime.Now, Activo = true };
            _context.Autores.Add(entidad_autores);
            _context.SaveChanges();
            if (entidad_autores.Id != 0) return;
            throw new Exception("Error al guardar Autores");
        }
        private void Consultar_Autores()
        {
            _context = new Conexion();
            var lista = _context.Autores.ToList();
            if (lista.Count > 0) return;
            throw new Exception("Error al consultar Autores");
        }
        private void Modificar_Autores()
        {
            _context = new Conexion();
            entidad_autores!.Activo = false;
            var entry = _context.Entry(entidad_autores);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            if (entidad_autores.Id != 0) return;
            throw new Exception("Error al modificar Autores");
        }
        private void Borrar_Autores()
        {
            _context = new Conexion();
            _context.Autores.Remove(entidad_autores!);
            _context.SaveChanges();
        }

        // ═══════════════════════════════════════════════════════
        // GENEROS
        // ═══════════════════════════════════════════════════════
        private Generos? entidad_generos;
        private void Guardar_Generos()
        {
            _context = new Conexion();
            entidad_generos = new Generos { Nombre = "UT-" + DateTime.Now };
            _context.Generos.Add(entidad_generos);
            _context.SaveChanges();
            if (entidad_generos.Id != 0) return;
            throw new Exception("Error al guardar Generos");
        }
        private void Consultar_Generos()
        {
            _context = new Conexion();
            var lista = _context.Generos.ToList();
            if (lista.Count > 0) return;
            throw new Exception("Error al consultar Generos");
        }
        private void Modificar_Generos()
        {
            _context = new Conexion();
            entidad_generos!.Nombre = "UT-Modificado";
            var entry = _context.Entry(entidad_generos);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            if (entidad_generos.Id != 0) return;
            throw new Exception("Error al modificar Generos");
        }
        private void Borrar_Generos()
        {
            _context = new Conexion();
            _context.Generos.Remove(entidad_generos!);
            _context.SaveChanges();
        }

        // ═══════════════════════════════════════════════════════
        // EDITORIALES
        // ═══════════════════════════════════════════════════════
        private Editoriales? entidad_editoriales;
        private void Guardar_Editoriales()
        {
            _context = new Conexion();
            entidad_editoriales = new Editoriales { Nombre = "UT-" + DateTime.Now, Pais = "Colombia", AnoFundacion = DateTime.Now, Activa = true };
            _context.Editoriales.Add(entidad_editoriales);
            _context.SaveChanges();
            if (entidad_editoriales.Id != 0) return;
            throw new Exception("Error al guardar Editoriales");
        }
        private void Consultar_Editoriales()
        {
            _context = new Conexion();
            var lista = _context.Editoriales.ToList();
            if (lista.Count > 0) return;
            throw new Exception("Error al consultar Editoriales");
        }
        private void Modificar_Editoriales()
        {
            _context = new Conexion();
            entidad_editoriales!.Activa = false;
            var entry = _context.Entry(entidad_editoriales);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            if (entidad_editoriales.Id != 0) return;
            throw new Exception("Error al modificar Editoriales");
        }
        private void Borrar_Editoriales()
        {
            _context = new Conexion();
            _context.Editoriales.Remove(entidad_editoriales!);
            _context.SaveChanges();
        }

        // ═══════════════════════════════════════════════════════
        // ESTADOLECTURAS
        // ═══════════════════════════════════════════════════════
        private EstadoLecturas? entidad_estadoLecturas;
        private void Guardar_EstadoLecturas()
        {
            _context = new Conexion();
            entidad_estadoLecturas = new EstadoLecturas { Nombre = "UT-" + DateTime.Now };
            _context.EstadoLecturas.Add(entidad_estadoLecturas);
            _context.SaveChanges();
            if (entidad_estadoLecturas.Id != 0) return;
            throw new Exception("Error al guardar EstadoLecturas");
        }
        private void Consultar_EstadoLecturas()
        {
            _context = new Conexion();
            var lista = _context.EstadoLecturas.ToList();
            if (lista.Count > 0) return;
            throw new Exception("Error al consultar EstadoLecturas");
        }
        private void Modificar_EstadoLecturas()
        {
            _context = new Conexion();
            entidad_estadoLecturas!.Nombre = "UT-Modificado";
            var entry = _context.Entry(entidad_estadoLecturas);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            if (entidad_estadoLecturas.Id != 0) return;
            throw new Exception("Error al modificar EstadoLecturas");
        }
        private void Borrar_EstadoLecturas()
        {
            _context = new Conexion();
            _context.EstadoLecturas.Remove(entidad_estadoLecturas!);
            _context.SaveChanges();
        }

        // ═══════════════════════════════════════════════════════
        // LOGROS
        // ═══════════════════════════════════════════════════════
        private Logros? entidad_logros;
        private void Guardar_Logros()
        {
            _context = new Conexion();
            entidad_logros = new Logros { Nombre = "UT-" + DateTime.Now, Descripcion = "Logro de prueba", Puntos = 100, Activo = true };
            _context.Logros.Add(entidad_logros);
            _context.SaveChanges();
            if (entidad_logros.Id != 0) return;
            throw new Exception("Error al guardar Logros");
        }
        private void Consultar_Logros()
        {
            _context = new Conexion();
            var lista = _context.Logros.ToList();
            if (lista.Count > 0) return;
            throw new Exception("Error al consultar Logros");
        }
        private void Modificar_Logros()
        {
            _context = new Conexion();
            entidad_logros!.Puntos = 200;
            var entry = _context.Entry(entidad_logros);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            if (entidad_logros.Id != 0) return;
            throw new Exception("Error al modificar Logros");
        }
        private void Borrar_Logros()
        {
            _context = new Conexion();
            _context.Logros.Remove(entidad_logros!);
            _context.SaveChanges();
        }

        // ═══════════════════════════════════════════════════════
        // USUARIOS
        // ═══════════════════════════════════════════════════════
        private Usuarios? entidad_usuarios;
        private void Guardar_Usuarios()
        {
            _context = new Conexion();
            entidad_usuarios = new Usuarios { Nombre = "UT-" + DateTime.Now, Email = "ut@prueba.com", FechaRegistro = DateTime.Now, LibrosLeidos = 5, PaginasLeidas = 1000 };
            _context.Usuarios.Add(entidad_usuarios);
            _context.SaveChanges();
            if (entidad_usuarios.Id != 0) return;
            throw new Exception("Error al guardar Usuarios");
        }
        private void Consultar_Usuarios()
        {
            _context = new Conexion();
            var lista = _context.Usuarios.ToList();
            if (lista.Count > 0) return;
            throw new Exception("Error al consultar Usuarios");
        }
        private void Modificar_Usuarios()
        {
            _context = new Conexion();
            entidad_usuarios!.LibrosLeidos = 10;
            var entry = _context.Entry(entidad_usuarios);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            if (entidad_usuarios.Id != 0) return;
            throw new Exception("Error al modificar Usuarios");
        }
        private void Borrar_Usuarios()
        {
            _context = new Conexion();
            _context.Usuarios.Remove(entidad_usuarios!);
            _context.SaveChanges();
        }

        // ═══════════════════════════════════════════════════════
        // ESTADISTICAS
        // ═══════════════════════════════════════════════════════
        private Estadisticas? entidad_estadisticas;
        private void Guardar_Estadisticas()
        {
            _context = new Conexion();
            entidad_estadisticas = new Estadisticas { LibrosLeidos = 5, PaginasTotales = 1200, PromedioPaginas = 240, UsuarioId = entidad_usuarios!.Id };
            _context.Estadisticas.Add(entidad_estadisticas);
            _context.SaveChanges();
            if (entidad_estadisticas.Id != 0) return;
            throw new Exception("Error al guardar Estadisticas");
        }
        private void Consultar_Estadisticas()
        {
            _context = new Conexion();
            var lista = _context.Estadisticas.ToList();
            if (lista.Count > 0) return;
            throw new Exception("Error al consultar Estadisticas");
        }
        private void Modificar_Estadisticas()
        {
            _context = new Conexion();
            entidad_estadisticas!.LibrosLeidos = 10;
            var entry = _context.Entry(entidad_estadisticas);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            if (entidad_estadisticas.Id != 0) return;
            throw new Exception("Error al modificar Estadisticas");
        }
        private void Borrar_Estadisticas()
        {
            _context = new Conexion();
            _context.Estadisticas.Remove(entidad_estadisticas!);
            _context.SaveChanges();
        }

        // ═══════════════════════════════════════════════════════
        // NOTAS
        // ═══════════════════════════════════════════════════════
        private Notas? entidad_notas;
        private void Guardar_Notas()
        {
            _context = new Conexion();
            entidad_notas = new Notas { Pagina = 10, Contenido = "UT-Nota de prueba", Fecha = DateTime.Now, UsuarioId = entidad_usuarios!.Id };
            _context.Notas.Add(entidad_notas);
            _context.SaveChanges();
            if (entidad_notas.Id != 0) return;
            throw new Exception("Error al guardar Notas");
        }
        private void Consultar_Notas()
        {
            _context = new Conexion();
            var lista = _context.Notas.ToList();
            if (lista.Count > 0) return;
            throw new Exception("Error al consultar Notas");
        }
        private void Modificar_Notas()
        {
            _context = new Conexion();
            entidad_notas!.Contenido = "UT-Modificado";
            var entry = _context.Entry(entidad_notas);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            if (entidad_notas.Id != 0) return;
            throw new Exception("Error al modificar Notas");
        }
        private void Borrar_Notas()
        {
            _context = new Conexion();
            _context.Notas.Remove(entidad_notas!);
            _context.SaveChanges();
        }

        // ═══════════════════════════════════════════════════════
        // CONFIGURACIONUSUARIOS
        // ═══════════════════════════════════════════════════════
        private ConfiguracionUsuarios? entidad_configuracionUsuarios;
        private void Guardar_ConfiguracionUsuarios()
        {
            _context = new Conexion();
            entidad_configuracionUsuarios = new ConfiguracionUsuarios { NotificacionesActivas = true, TemaOscuro = false, UsuarioId = entidad_usuarios!.Id };
            _context.ConfiguracionUsuarios.Add(entidad_configuracionUsuarios);
            _context.SaveChanges();
            if (entidad_configuracionUsuarios.Id != 0) return;
            throw new Exception("Error al guardar ConfiguracionUsuarios");
        }
        private void Consultar_ConfiguracionUsuarios()
        {
            _context = new Conexion();
            var lista = _context.ConfiguracionUsuarios.ToList();
            if (lista.Count > 0) return;
            throw new Exception("Error al consultar ConfiguracionUsuarios");
        }
        private void Modificar_ConfiguracionUsuarios()
        {
            _context = new Conexion();
            entidad_configuracionUsuarios!.TemaOscuro = true;
            var entry = _context.Entry(entidad_configuracionUsuarios);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            if (entidad_configuracionUsuarios.Id != 0) return;
            throw new Exception("Error al modificar ConfiguracionUsuarios");
        }
        private void Borrar_ConfiguracionUsuarios()
        {
            _context = new Conexion();
            _context.ConfiguracionUsuarios.Remove(entidad_configuracionUsuarios!);
            _context.SaveChanges();
        }

        // ═══════════════════════════════════════════════════════
        // NOTIFICACIONES
        // ═══════════════════════════════════════════════════════
        private Notificaciones? entidad_notificaciones;
        private void Guardar_Notificaciones()
        {
            _context = new Conexion();
            entidad_notificaciones = new Notificaciones { Mensaje = "UT-Mensaje de prueba", FechaEnvio = DateTime.Now, Leida = false, UsuarioId = entidad_usuarios!.Id };
            _context.Notificaciones.Add(entidad_notificaciones);
            _context.SaveChanges();
            if (entidad_notificaciones.Id != 0) return;
            throw new Exception("Error al guardar Notificaciones");
        }
        private void Consultar_Notificaciones()
        {
            _context = new Conexion();
            var lista = _context.Notificaciones.ToList();
            if (lista.Count > 0) return;
            throw new Exception("Error al consultar Notificaciones");
        }
        private void Modificar_Notificaciones()
        {
            _context = new Conexion();
            entidad_notificaciones!.Leida = true;
            var entry = _context.Entry(entidad_notificaciones);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            if (entidad_notificaciones.Id != 0) return;
            throw new Exception("Error al modificar Notificaciones");
        }
        private void Borrar_Notificaciones()
        {
            _context = new Conexion();
            _context.Notificaciones.Remove(entidad_notificaciones!);
            _context.SaveChanges();
        }

        // ═══════════════════════════════════════════════════════
        // METALECTURAS
        // ═══════════════════════════════════════════════════════
        private MetaLecturas? entidad_metaLecturas;
        private void Guardar_MetaLecturas()
        {
            _context = new Conexion();
            entidad_metaLecturas = new MetaLecturas { Ano = DateTime.Now.Year, CantidadObjetivo = 12, LibrosCompletos = 3, UsuarioId = entidad_usuarios!.Id };
            _context.MetaLecturas.Add(entidad_metaLecturas);
            _context.SaveChanges();
            if (entidad_metaLecturas.Id != 0) return;
            throw new Exception("Error al guardar MetaLecturas");
        }
        private void Consultar_MetaLecturas()
        {
            _context = new Conexion();
            var lista = _context.MetaLecturas.ToList();
            if (lista.Count > 0) return;
            throw new Exception("Error al consultar MetaLecturas");
        }
        private void Modificar_MetaLecturas()
        {
            _context = new Conexion();
            entidad_metaLecturas!.LibrosCompletos = 6;
            var entry = _context.Entry(entidad_metaLecturas);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            if (entidad_metaLecturas.Id != 0) return;
            throw new Exception("Error al modificar MetaLecturas");
        }
        private void Borrar_MetaLecturas()
        {
            _context = new Conexion();
            _context.MetaLecturas.Remove(entidad_metaLecturas!);
            _context.SaveChanges();
        }

        // ═══════════════════════════════════════════════════════
        // CALENDARIOLECTURAS
        // ═══════════════════════════════════════════════════════
        private CalendarioLecturas? entidad_calendarioLecturas;
        private void Guardar_CalendarioLecturas()
        {
            _context = new Conexion();
            entidad_calendarioLecturas = new CalendarioLecturas { Fecha = DateTime.Now, PaginasLeidas = 50, TiempoMinutos = 60, UsuarioId = entidad_usuarios!.Id };
            _context.CalendarioLecturas.Add(entidad_calendarioLecturas);
            _context.SaveChanges();
            if (entidad_calendarioLecturas.Id != 0) return;
            throw new Exception("Error al guardar CalendarioLecturas");
        }
        private void Consultar_CalendarioLecturas()
        {
            _context = new Conexion();
            var lista = _context.CalendarioLecturas.ToList();
            if (lista.Count > 0) return;
            throw new Exception("Error al consultar CalendarioLecturas");
        }
        private void Modificar_CalendarioLecturas()
        {
            _context = new Conexion();
            entidad_calendarioLecturas!.PaginasLeidas = 100;
            var entry = _context.Entry(entidad_calendarioLecturas);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            if (entidad_calendarioLecturas.Id != 0) return;
            throw new Exception("Error al modificar CalendarioLecturas");
        }
        private void Borrar_CalendarioLecturas()
        {
            _context = new Conexion();
            _context.CalendarioLecturas.Remove(entidad_calendarioLecturas!);
            _context.SaveChanges();
        }

        // ═══════════════════════════════════════════════════════
        // SECCIONLECTURAS
        // ═══════════════════════════════════════════════════════
        private SeccionLecturas? entidad_seccionLecturas;
        private void Guardar_SeccionLecturas()
        {
            _context = new Conexion();
            entidad_seccionLecturas = new SeccionLecturas { PaginasLeidas = 30, MinutosLeidos = 45, Fecha = DateTime.Now };
            _context.SeccionLecturas.Add(entidad_seccionLecturas);
            _context.SaveChanges();
            if (entidad_seccionLecturas.Id != 0) return;
            throw new Exception("Error al guardar SeccionLecturas");
        }
        private void Consultar_SeccionLecturas()
        {
            _context = new Conexion();
            var lista = _context.SeccionLecturas.ToList();
            if (lista.Count > 0) return;
            throw new Exception("Error al consultar SeccionLecturas");
        }
        private void Modificar_SeccionLecturas()
        {
            _context = new Conexion();
            entidad_seccionLecturas!.PaginasLeidas = 60;
            var entry = _context.Entry(entidad_seccionLecturas);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            if (entidad_seccionLecturas.Id != 0) return;
            throw new Exception("Error al modificar SeccionLecturas");
        }
        private void Borrar_SeccionLecturas()
        {
            _context = new Conexion();
            _context.SeccionLecturas.Remove(entidad_seccionLecturas!);
            _context.SaveChanges();
        }

        // ═══════════════════════════════════════════════════════
        // RECOMENDACIONES
        // ═══════════════════════════════════════════════════════
        private Recomendaciones? entidad_recomendaciones;
        private void Guardar_Recomendaciones()
        {
            _context = new Conexion();
            entidad_recomendaciones = new Recomendaciones { Motivo = "UT-Motivo de prueba", Fecha = DateTime.Now };
            _context.Recomendaciones.Add(entidad_recomendaciones);
            _context.SaveChanges();
            if (entidad_recomendaciones.Id != 0) return;
            throw new Exception("Error al guardar Recomendaciones");
        }
        private void Consultar_Recomendaciones()
        {
            _context = new Conexion();
            var lista = _context.Recomendaciones.ToList();
            if (lista.Count > 0) return;
            throw new Exception("Error al consultar Recomendaciones");
        }
        private void Modificar_Recomendaciones()
        {
            _context = new Conexion();
            entidad_recomendaciones!.Motivo = "UT-Modificado";
            var entry = _context.Entry(entidad_recomendaciones);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            if (entidad_recomendaciones.Id != 0) return;
            throw new Exception("Error al modificar Recomendaciones");
        }
        private void Borrar_Recomendaciones()
        {
            _context = new Conexion();
            _context.Recomendaciones.Remove(entidad_recomendaciones!);
            _context.SaveChanges();
        }

        // ═══════════════════════════════════════════════════════
        // LIBROS
        // ═══════════════════════════════════════════════════════
        private Libros? entidad_libros;
        private void Guardar_Libros()
        {
            _context = new Conexion();
            // Verificar que el autor existe en la BD
            var autorExiste = _context.Autores.Find(entidad_autores!.Id);
            if (autorExiste == null) throw new Exception("Autor no encontrado en BD");

            var generoExiste = _context.Generos.Find(entidad_generos!.Id);
            if (generoExiste == null) throw new Exception("Genero no encontrado en BD");

            entidad_libros = new Libros
            {
                Titulo = "UT-" + DateTime.Now,
                Autor = "UT-Autor",
                PaginasTotales = 300,
                AnoPublicacion = DateTime.Now,
                AutorId = autorExiste.Id,
                GeneroId = generoExiste.Id
            };
            _context.Libros.Add(entidad_libros);
            _context.SaveChanges();
            if (entidad_libros.Id != 0) return;
            throw new Exception("Error al guardar Libros");
        }
        private void Consultar_Libros()
        {
            _context = new Conexion();
            var lista = _context.Libros.ToList();
            if (lista.Count > 0) return;
            throw new Exception("Error al consultar Libros");
        }
        private void Modificar_Libros()
        {
            _context = new Conexion();
            entidad_libros!.PaginasTotales = 400;
            var entry = _context.Entry(entidad_libros);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            if (entidad_libros.Id != 0) return;
            throw new Exception("Error al modificar Libros");
        }
        private void Borrar_Libros()
        {
            _context = new Conexion();
            _context.Libros.Remove(entidad_libros!);
            _context.SaveChanges();
        }

        // ═══════════════════════════════════════════════════════
        // LECTURAS
        // ═══════════════════════════════════════════════════════
        private Lecturas? entidad_lecturas;
        private void Guardar_Lecturas()
        {
            _context = new Conexion();
            entidad_lecturas = new Lecturas { FechaInicio = DateTime.Now, FechaFin = DateTime.Now.AddDays(14), Estado = true, UsuarioId = entidad_usuarios!.Id, LibroId = entidad_libros!.Id };
            _context.Lecturas.Add(entidad_lecturas);
            _context.SaveChanges();
            if (entidad_lecturas.Id != 0) return;
            throw new Exception("Error al guardar Lecturas");
        }
        private void Consultar_Lecturas()
        {
            _context = new Conexion();
            var lista = _context.Lecturas.ToList();
            if (lista.Count > 0) return;
            throw new Exception("Error al consultar Lecturas");
        }
        private void Modificar_Lecturas()
        {
            _context = new Conexion();
            entidad_lecturas!.Estado = false;
            var entry = _context.Entry(entidad_lecturas);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            if (entidad_lecturas.Id != 0) return;
            throw new Exception("Error al modificar Lecturas");
        }
        private void Borrar_Lecturas()
        {
            _context = new Conexion();
            _context.Lecturas.Remove(entidad_lecturas!);
            _context.SaveChanges();
        }

        // ═══════════════════════════════════════════════════════
        // HISTORIALLECTURAS
        // ═══════════════════════════════════════════════════════
        private HistorialLecturas? entidad_historialLecturas;
        private void Guardar_HistorialLecturas()
        {
            _context = new Conexion();
            entidad_historialLecturas = new HistorialLecturas { FechaInicio = DateTime.Now, FechaFin = DateTime.Now.AddDays(7) };
            _context.HistorialLecturas.Add(entidad_historialLecturas);
            _context.SaveChanges();
            if (entidad_historialLecturas.Id != 0) return;
            throw new Exception("Error al guardar HistorialLecturas");
        }
        private void Consultar_HistorialLecturas()
        {
            _context = new Conexion();
            var lista = _context.HistorialLecturas.ToList();
            if (lista.Count > 0) return;
            throw new Exception("Error al consultar HistorialLecturas");
        }
        private void Modificar_HistorialLecturas()
        {
            _context = new Conexion();
            entidad_historialLecturas!.FechaFin = DateTime.Now.AddDays(14);
            var entry = _context.Entry(entidad_historialLecturas);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            if (entidad_historialLecturas.Id != 0) return;
            throw new Exception("Error al modificar HistorialLecturas");
        }
        private void Borrar_HistorialLecturas()
        {
            _context = new Conexion();
            _context.HistorialLecturas.Remove(entidad_historialLecturas!);
            _context.SaveChanges();
        }

        // ═══════════════════════════════════════════════════════
        // FAVORITOS
        // ═══════════════════════════════════════════════════════
        private Favoritos? entidad_favoritos;
        private void Guardar_Favoritos()
        {
            _context = new Conexion();
            entidad_favoritos = new Favoritos { FechaMarcado = DateTime.Now, Activo = true, UsuarioId = entidad_usuarios!.Id, LibroId = entidad_libros!.Id };
            _context.Favoritos.Add(entidad_favoritos);
            _context.SaveChanges();
            if (entidad_favoritos.Id != 0) return;
            throw new Exception("Error al guardar Favoritos");
        }
        private void Consultar_Favoritos()
        {
            _context = new Conexion();
            var lista = _context.Favoritos.ToList();
            if (lista.Count > 0) return;
            throw new Exception("Error al consultar Favoritos");
        }
        private void Modificar_Favoritos()
        {
            _context = new Conexion();
            entidad_favoritos!.Activo = false;
            var entry = _context.Entry(entidad_favoritos);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            if (entidad_favoritos.Id != 0) return;
            throw new Exception("Error al modificar Favoritos");
        }
        private void Borrar_Favoritos()
        {
            _context = new Conexion();
            _context.Favoritos.Remove(entidad_favoritos!);
            _context.SaveChanges();
        }

        // ═══════════════════════════════════════════════════════
        // RESENAS
        // ═══════════════════════════════════════════════════════
        private Resenas? entidad_resenas;
        private void Guardar_Resenas()
        {
            _context = new Conexion();
            entidad_resenas = new Resenas { Calificacion = 4.5m, Comentario = "UT-Comentario de prueba", UsuarioId = entidad_usuarios!.Id, LibroId = entidad_libros!.Id };
            _context.Resenas.Add(entidad_resenas);
            _context.SaveChanges();
            if (entidad_resenas.Id != 0) return;
            throw new Exception("Error al guardar Resenas");
        }
        private void Consultar_Resenas()
        {
            _context = new Conexion();
            var lista = _context.Resenas.ToList();
            if (lista.Count > 0) return;
            throw new Exception("Error al consultar Resenas");
        }
        private void Modificar_Resenas()
        {
            _context = new Conexion();
            entidad_resenas!.Calificacion = 3.0m;
            var entry = _context.Entry(entidad_resenas);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            if (entidad_resenas.Id != 0) return;
            throw new Exception("Error al modificar Resenas");
        }
        private void Borrar_Resenas()
        {
            _context = new Conexion();
            _context.Resenas.Remove(entidad_resenas!);
            _context.SaveChanges();
        }

        // ═══════════════════════════════════════════════════════
        // PROGRESOLECTURAS
        // ═══════════════════════════════════════════════════════
        private ProgresoLecturas? entidad_progresoLecturas;
        private void Guardar_ProgresoLecturas()
        {
            _context = new Conexion();
            entidad_progresoLecturas = new ProgresoLecturas { PaginasLeidas = 150, Porcentaje = 50, FechaActualizacion = DateTime.Now, LecturaId = entidad_lecturas!.Id };
            _context.ProgresoLecturas.Add(entidad_progresoLecturas);
            _context.SaveChanges();
            if (entidad_progresoLecturas.Id != 0) return;
            throw new Exception("Error al guardar ProgresoLecturas");
        }
        private void Consultar_ProgresoLecturas()
        {
            _context = new Conexion();
            var lista = _context.ProgresoLecturas.ToList();
            if (lista.Count > 0) return;
            throw new Exception("Error al consultar ProgresoLecturas");
        }
        private void Modificar_ProgresoLecturas()
        {
            _context = new Conexion();
            entidad_progresoLecturas!.PaginasLeidas = 200;
            var entry = _context.Entry(entidad_progresoLecturas);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            if (entidad_progresoLecturas.Id != 0) return;
            throw new Exception("Error al modificar ProgresoLecturas");
        }
        private void Borrar_ProgresoLecturas()
        {
            _context = new Conexion();
            _context.ProgresoLecturas.Remove(entidad_progresoLecturas!);
            _context.SaveChanges();
        }
    }
}