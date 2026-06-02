using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;

namespace LecturasWeb.Tests
{
    [TestClass]
    public class ApiUnitarias
    {
        private Conexion _context;

        [TestInitialize]
        public void Setup()
        {
            _context = new Conexion();
        }

        [TestMethod]
        public void Ejecutar()
        {
            Prueba_Autores();
            Prueba_Generos();
            Prueba_Editoriales();
            Prueba_EstadoLecturas();
            Prueba_Logros();
            Prueba_Usuarios();
            Prueba_Libros();
            Prueba_Estadisticas();
            Prueba_Notas();
            Prueba_ConfiguracionUsuarios();
            Prueba_Notificaciones();
            Prueba_MetaLecturas();
            Prueba_CalendarioLecturas();
            Prueba_Recomendaciones();
            Prueba_SeccionLecturas();
            Prueba_Lecturas();
            Prueba_Favoritos();
            Prueba_Resenas();
            Prueba_HistorialLecturas();
            Prueba_ProgresoLecturas();
        }

        // ═══════════════════════════════════════════════════════
        // AUTORES
        // ═══════════════════════════════════════════════════════
        private Autores? entidad_autores;
        private void Prueba_Autores()
        {
            //cuando la entidad tambien contiene Auditorias debemos implementarla tambien en el constructor del negocio para que se registre la auditoria de cada acción realizada
            var controller = new AutoresController(new AutoresNegocio(_context, new AuditoriasNegocio(_context))); 

            entidad_autores = new Autores { Nombre = "UT-API-" + DateTime.Now, Nacionalidad = "Colombiana", FechaNacimiento = DateTime.Now, Activo = true };

            var guardar = controller.Guardar(entidad_autores) as OkObjectResult;
            if (guardar == null || guardar.StatusCode != 200) throw new Exception("Error al guardar Autores en API");
            entidad_autores = guardar.Value as Autores;

            var consultar = controller.Consultar() as OkObjectResult;
            if (consultar == null || consultar.StatusCode != 200) throw new Exception("Error al consultar Autores en API");

            entidad_autores!.Activo = false;
            var modificar = controller.Modificar(entidad_autores) as OkObjectResult;
            if (modificar == null || modificar.StatusCode != 200) throw new Exception("Error al modificar Autores en API");

            var borrar = controller.Borrar(entidad_autores) as OkObjectResult;
            if (borrar == null || borrar.StatusCode != 200) throw new Exception("Error al borrar Autores en API");
        }

        // ═══════════════════════════════════════════════════════
        // GENEROS
        // ═══════════════════════════════════════════════════════
        private Generos? entidad_generos;
        private void Prueba_Generos()
        {
            var controller = new GenerosController(new GenerosNegocio(_context));

            entidad_generos = new Generos { Nombre = "UT-API-" + DateTime.Now };

            var guardar = controller.Guardar(entidad_generos) as OkObjectResult;
            if (guardar == null || guardar.StatusCode != 200) throw new Exception("Error al guardar Generos en API");
            entidad_generos = guardar.Value as Generos;

            var consultar = controller.Consultar() as OkObjectResult;
            if (consultar == null || consultar.StatusCode != 200) throw new Exception("Error al consultar Generos en API");

            entidad_generos!.Nombre = "UT-API-Modificado";
            var modificar = controller.Modificar(entidad_generos) as OkObjectResult;
            if (modificar == null || modificar.StatusCode != 200) throw new Exception("Error al modificar Generos en API");

            var borrar = controller.Borrar(entidad_generos) as OkObjectResult;
            if (borrar == null || borrar.StatusCode != 200) throw new Exception("Error al borrar Generos en API");
        }

        // ═══════════════════════════════════════════════════════
        // EDITORIALES
        // ═══════════════════════════════════════════════════════
        private Editoriales? entidad_editoriales;
        private void Prueba_Editoriales()
        {
            var controller = new EditorialesController(new EditorialesNegocio(_context));

            entidad_editoriales = new Editoriales { Nombre = "UT-API-" + DateTime.Now, Pais = "Colombia", AnoFundacion = DateTime.Now, Activa = true };

            var guardar = controller.Guardar(entidad_editoriales) as OkObjectResult;
            if (guardar == null || guardar.StatusCode != 200) throw new Exception("Error al guardar Editoriales en API");
            entidad_editoriales = guardar.Value as Editoriales;

            var consultar = controller.Consultar() as OkObjectResult;
            if (consultar == null || consultar.StatusCode != 200) throw new Exception("Error al consultar Editoriales en API");

            entidad_editoriales!.Activa = false;
            var modificar = controller.Modificar(entidad_editoriales) as OkObjectResult;
            if (modificar == null || modificar.StatusCode != 200) throw new Exception("Error al modificar Editoriales en API");

            var borrar = controller.Borrar(entidad_editoriales) as OkObjectResult;
            if (borrar == null || borrar.StatusCode != 200) throw new Exception("Error al borrar Editoriales en API");
        }

        // ═══════════════════════════════════════════════════════
        // ESTADOLECTURAS
        // ═══════════════════════════════════════════════════════
        private EstadoLecturas? entidad_estadoLecturas;
        private void Prueba_EstadoLecturas()
        {
            var controller = new EstadoLecturasController(new EstadoLecturasNegocio(_context));

            entidad_estadoLecturas = new EstadoLecturas { Nombre = "UT-API-" + DateTime.Now };

            var guardar = controller.Guardar(entidad_estadoLecturas) as OkObjectResult;
            if (guardar == null || guardar.StatusCode != 200) throw new Exception("Error al guardar EstadoLecturas en API");
            entidad_estadoLecturas = guardar.Value as EstadoLecturas;

            var consultar = controller.Consultar() as OkObjectResult;
            if (consultar == null || consultar.StatusCode != 200) throw new Exception("Error al consultar EstadoLecturas en API");

            entidad_estadoLecturas!.Nombre = "UT-API-Modificado";
            var modificar = controller.Modificar(entidad_estadoLecturas) as OkObjectResult;
            if (modificar == null || modificar.StatusCode != 200) throw new Exception("Error al modificar EstadoLecturas en API");

            var borrar = controller.Borrar(entidad_estadoLecturas) as OkObjectResult;
            if (borrar == null || borrar.StatusCode != 200) throw new Exception("Error al borrar EstadoLecturas en API");
        }

        // ═══════════════════════════════════════════════════════
        // LOGROS
        // ═══════════════════════════════════════════════════════
        private Logros? entidad_logros;
        private void Prueba_Logros()
        {
            var controller = new LogrosController(new LogrosNegocio(_context));

            entidad_logros = new Logros { Nombre = "UT-API-" + DateTime.Now, Descripcion = "Logro de prueba", Puntos = 100, Activo = true };

            var guardar = controller.Guardar(entidad_logros) as OkObjectResult;
            if (guardar == null || guardar.StatusCode != 200) throw new Exception("Error al guardar Logros en API");
            entidad_logros = guardar.Value as Logros;

            var consultar = controller.Consultar() as OkObjectResult;
            if (consultar == null || consultar.StatusCode != 200) throw new Exception("Error al consultar Logros en API");

            entidad_logros!.Puntos = 200;
            var modificar = controller.Modificar(entidad_logros) as OkObjectResult;
            if (modificar == null || modificar.StatusCode != 200) throw new Exception("Error al modificar Logros en API");

            var borrar = controller.Borrar(entidad_logros) as OkObjectResult;
            if (borrar == null || borrar.StatusCode != 200) throw new Exception("Error al borrar Logros en API");
        }

        // ═══════════════════════════════════════════════════════
        // USUARIOS
        // ═══════════════════════════════════════════════════════
        private Usuarios? entidad_usuarios;
        private void Prueba_Usuarios()
        {
            var controller = new UsuariosController(new UsuariosNegocio(_context));

            entidad_usuarios = new Usuarios { Nombre = "UT-API-" + DateTime.Now, Email = "ut-api@prueba.com", FechaRegistro = DateTime.Now, LibrosLeidos = 0, PaginasLeidas = 0 };

            var guardar = controller.Guardar(entidad_usuarios) as OkObjectResult;
            if (guardar == null || guardar.StatusCode != 200) throw new Exception("Error al guardar Usuarios en API");
            entidad_usuarios = guardar.Value as Usuarios;

            var consultar = controller.Consultar() as OkObjectResult;
            if (consultar == null || consultar.StatusCode != 200) throw new Exception("Error al consultar Usuarios en API");

            entidad_usuarios!.LibrosLeidos = 10;
            var modificar = controller.Modificar(entidad_usuarios) as OkObjectResult;
            if (modificar == null || modificar.StatusCode != 200) throw new Exception("Error al modificar Usuarios en API");
        }

        // ═══════════════════════════════════════════════════════
        // LIBROS
        // ═══════════════════════════════════════════════════════
        private Libros? entidad_libros;
        private void Prueba_Libros()
        {
            var controller = new LibrosController(new LibrosNegocio(_context));

            entidad_libros = new Libros { Titulo = "UT-API-" + DateTime.Now, Autor = "UT-Autor", PaginasTotales = 300, AnoPublicacion = DateTime.Now, AutorId = entidad_autores!.Id, GeneroId = entidad_generos!.Id };

            var guardar = controller.Guardar(entidad_libros) as OkObjectResult;
            if (guardar == null || guardar.StatusCode != 200) throw new Exception("Error al guardar Libros en API");
            entidad_libros = guardar.Value as Libros;

            var consultar = controller.Consultar() as OkObjectResult;
            if (consultar == null || consultar.StatusCode != 200) throw new Exception("Error al consultar Libros en API");

            entidad_libros!.PaginasTotales = 400;
            var modificar = controller.Modificar(entidad_libros) as OkObjectResult;
            if (modificar == null || modificar.StatusCode != 200) throw new Exception("Error al modificar Libros en API");
        }

        // ═══════════════════════════════════════════════════════
        // ESTADISTICAS
        // ═══════════════════════════════════════════════════════
        private Estadisticas? entidad_estadisticas;
        private void Prueba_Estadisticas()
        {
            var controller = new EstadisticasController(new EstadisticasNegocio(_context));

            entidad_estadisticas = new Estadisticas { LibrosLeidos = 5, PaginasTotales = 1200, PromedioPaginas = 240, UsuarioId = entidad_usuarios!.Id };

            var guardar = controller.Guardar(entidad_estadisticas) as OkObjectResult;
            if (guardar == null || guardar.StatusCode != 200) throw new Exception("Error al guardar Estadisticas en API");
            entidad_estadisticas = guardar.Value as Estadisticas;

            var consultar = controller.Consultar() as OkObjectResult;
            if (consultar == null || consultar.StatusCode != 200) throw new Exception("Error al consultar Estadisticas en API");

            entidad_estadisticas!.LibrosLeidos = 10;
            var modificar = controller.Modificar(entidad_estadisticas) as OkObjectResult;
            if (modificar == null || modificar.StatusCode != 200) throw new Exception("Error al modificar Estadisticas en API");

            var borrar = controller.Borrar(entidad_estadisticas) as OkObjectResult;
            if (borrar == null || borrar.StatusCode != 200) throw new Exception("Error al borrar Estadisticas en API");
        }

        // ═══════════════════════════════════════════════════════
        // NOTAS
        // ═══════════════════════════════════════════════════════
        private Notas? entidad_notas;
        private void Prueba_Notas()
        {
            var controller = new NotasController(new NotasNegocio(_context));

            entidad_notas = new Notas { Pagina = 10, Contenido = "UT-API-Nota", Fecha = DateTime.Now, UsuarioId = entidad_usuarios!.Id };

            var guardar = controller.Guardar(entidad_notas) as OkObjectResult;
            if (guardar == null || guardar.StatusCode != 200) throw new Exception("Error al guardar Notas en API");
            entidad_notas = guardar.Value as Notas;

            var consultar = controller.Consultar() as OkObjectResult;
            if (consultar == null || consultar.StatusCode != 200) throw new Exception("Error al consultar Notas en API");

            entidad_notas!.Contenido = "UT-API-Modificado";
            var modificar = controller.Modificar(entidad_notas) as OkObjectResult;
            if (modificar == null || modificar.StatusCode != 200) throw new Exception("Error al modificar Notas en API");

            var borrar = controller.Borrar(entidad_notas) as OkObjectResult;
            if (borrar == null || borrar.StatusCode != 200) throw new Exception("Error al borrar Notas en API");
        }

        // ═══════════════════════════════════════════════════════
        // CONFIGURACIONUSUARIOS
        // ═══════════════════════════════════════════════════════
        private ConfiguracionUsuarios? entidad_configuracion;
        private void Prueba_ConfiguracionUsuarios()
        {
            var controller = new ConfiguracionUsuariosController(new ConfiguracionUsuariosNegocio(_context, new AuditoriasNegocio(_context)));

            entidad_configuracion = new ConfiguracionUsuarios { NotificacionesActivas = true, TemaOscuro = false, UsuarioId = entidad_usuarios!.Id };

            var guardar = controller.Guardar(entidad_configuracion) as OkObjectResult;
            if (guardar == null || guardar.StatusCode != 200) throw new Exception("Error al guardar ConfiguracionUsuarios en API");
            entidad_configuracion = guardar.Value as ConfiguracionUsuarios;

            var consultar = controller.Consultar() as OkObjectResult;
            if (consultar == null || consultar.StatusCode != 200) throw new Exception("Error al consultar ConfiguracionUsuarios en API");

            entidad_configuracion!.TemaOscuro = true;
            var modificar = controller.Modificar(entidad_configuracion) as OkObjectResult;
            if (modificar == null || modificar.StatusCode != 200) throw new Exception("Error al modificar ConfiguracionUsuarios en API");

            var borrar = controller.Borrar(entidad_configuracion) as OkObjectResult;
            if (borrar == null || borrar.StatusCode != 200) throw new Exception("Error al borrar ConfiguracionUsuarios en API");
        }

        // ═══════════════════════════════════════════════════════
        // NOTIFICACIONES
        // ═══════════════════════════════════════════════════════
        private Notificaciones? entidad_notificaciones;
        private void Prueba_Notificaciones()
        {
            var controller = new NotificacionesController(new NotificacionesNegocio(_context));

            entidad_notificaciones = new Notificaciones { Mensaje = "UT-API-Mensaje", FechaEnvio = DateTime.Now, Leida = false, UsuarioId = entidad_usuarios!.Id };

            var guardar = controller.Guardar(entidad_notificaciones) as OkObjectResult;
            if (guardar == null || guardar.StatusCode != 200) throw new Exception("Error al guardar Notificaciones en API");
            entidad_notificaciones = guardar.Value as Notificaciones;

            var consultar = controller.Consultar() as OkObjectResult;
            if (consultar == null || consultar.StatusCode != 200) throw new Exception("Error al consultar Notificaciones en API");

            entidad_notificaciones!.Leida = true;
            var modificar = controller.Modificar(entidad_notificaciones) as OkObjectResult;
            if (modificar == null || modificar.StatusCode != 200) throw new Exception("Error al modificar Notificaciones en API");

            var borrar = controller.Borrar(entidad_notificaciones) as OkObjectResult;
            if (borrar == null || borrar.StatusCode != 200) throw new Exception("Error al borrar Notificaciones en API");
        }

        // ═══════════════════════════════════════════════════════
        // METALECTURAS
        // ═══════════════════════════════════════════════════════
        private MetaLecturas? entidad_meta;
        private void Prueba_MetaLecturas()
        {
            var controller = new MetaLecturasController(new MetaLecturasNegocio(_context));

            entidad_meta = new MetaLecturas { Ano = DateTime.Now.Year, CantidadObjetivo = 12, LibrosCompletos = 3, UsuarioId = entidad_usuarios!.Id };

            var guardar = controller.Guardar(entidad_meta) as OkObjectResult;
            if (guardar == null || guardar.StatusCode != 200) throw new Exception("Error al guardar MetaLecturas en API");
            entidad_meta = guardar.Value as MetaLecturas;

            var consultar = controller.Consultar() as OkObjectResult;
            if (consultar == null || consultar.StatusCode != 200) throw new Exception("Error al consultar MetaLecturas en API");

            entidad_meta!.LibrosCompletos = 6;
            var modificar = controller.Modificar(entidad_meta) as OkObjectResult;
            if (modificar == null || modificar.StatusCode != 200) throw new Exception("Error al modificar MetaLecturas en API");

            var borrar = controller.Borrar(entidad_meta) as OkObjectResult;
            if (borrar == null || borrar.StatusCode != 200) throw new Exception("Error al borrar MetaLecturas en API");
        }

        // ═══════════════════════════════════════════════════════
        // CALENDARIOLECTURAS
        // ═══════════════════════════════════════════════════════
        private CalendarioLecturas? entidad_calendario;
        private void Prueba_CalendarioLecturas()
        {
            var controller = new CalendarioLecturasController(new CalendarioLecturasNegocio(_context));

            entidad_calendario = new CalendarioLecturas { Fecha = DateTime.Now, PaginasLeidas = 50, TiempoMinutos = 60, UsuarioId = entidad_usuarios!.Id };

            var guardar = controller.Guardar(entidad_calendario) as OkObjectResult;
            if (guardar == null || guardar.StatusCode != 200) throw new Exception("Error al guardar CalendarioLecturas en API");
            entidad_calendario = guardar.Value as CalendarioLecturas;

            var consultar = controller.Consultar() as OkObjectResult;
            if (consultar == null || consultar.StatusCode != 200) throw new Exception("Error al consultar CalendarioLecturas en API");

            entidad_calendario!.PaginasLeidas = 100;
            var modificar = controller.Modificar(entidad_calendario) as OkObjectResult;
            if (modificar == null || modificar.StatusCode != 200) throw new Exception("Error al modificar CalendarioLecturas en API");

            var borrar = controller.Borrar(entidad_calendario) as OkObjectResult;
            if (borrar == null || borrar.StatusCode != 200) throw new Exception("Error al borrar CalendarioLecturas en API");
        }

        // ═══════════════════════════════════════════════════════
        // RECOMENDACIONES
        // ═══════════════════════════════════════════════════════
        private Recomendaciones? entidad_recomendaciones;
        private void Prueba_Recomendaciones()
        {
            var controller = new RecomendacionesController(new RecomendacionesNegocio(_context));

            entidad_recomendaciones = new Recomendaciones { Motivo = "UT-API-Motivo", Fecha = DateTime.Now };

            var guardar = controller.Guardar(entidad_recomendaciones) as OkObjectResult;
            if (guardar == null || guardar.StatusCode != 200) throw new Exception("Error al guardar Recomendaciones en API");
            entidad_recomendaciones = guardar.Value as Recomendaciones;

            var consultar = controller.Consultar() as OkObjectResult;
            if (consultar == null || consultar.StatusCode != 200) throw new Exception("Error al consultar Recomendaciones en API");

            entidad_recomendaciones!.Motivo = "UT-API-Modificado";
            var modificar = controller.Modificar(entidad_recomendaciones) as OkObjectResult;
            if (modificar == null || modificar.StatusCode != 200) throw new Exception("Error al modificar Recomendaciones en API");

            var borrar = controller.Borrar(entidad_recomendaciones) as OkObjectResult;
            if (borrar == null || borrar.StatusCode != 200) throw new Exception("Error al borrar Recomendaciones en API");
        }

        // ═══════════════════════════════════════════════════════
        // SECCIONLECTURAS
        // ═══════════════════════════════════════════════════════
        private SeccionLecturas? entidad_seccion;
        private void Prueba_SeccionLecturas()
        {
            var controller = new SeccionLecturasController(new SeccionLecturasNegocio(_context));

            entidad_seccion = new SeccionLecturas { PaginasLeidas = 30, MinutosLeidos = 45, Fecha = DateTime.Now };

            var guardar = controller.Guardar(entidad_seccion) as OkObjectResult;
            if (guardar == null || guardar.StatusCode != 200) throw new Exception("Error al guardar SeccionLecturas en API");
            entidad_seccion = guardar.Value as SeccionLecturas;

            var consultar = controller.Consultar() as OkObjectResult;
            if (consultar == null || consultar.StatusCode != 200) throw new Exception("Error al consultar SeccionLecturas en API");

            entidad_seccion!.PaginasLeidas = 60;
            var modificar = controller.Modificar(entidad_seccion) as OkObjectResult;
            if (modificar == null || modificar.StatusCode != 200) throw new Exception("Error al modificar SeccionLecturas en API");

            var borrar = controller.Borrar(entidad_seccion) as OkObjectResult;
            if (borrar == null || borrar.StatusCode != 200) throw new Exception("Error al borrar SeccionLecturas en API");
        }

        // ═══════════════════════════════════════════════════════
        // LECTURAS
        // ═══════════════════════════════════════════════════════
        private Lecturas? entidad_lecturas;
        private void Prueba_Lecturas()
        {
            var controller = new LecturasController(new LecturasNegocio(_context));

            entidad_lecturas = new Lecturas { FechaInicio = DateTime.Now, FechaFin = DateTime.Now.AddDays(14), Estado = true, UsuarioId = entidad_usuarios!.Id, LibroId = entidad_libros!.Id };

            var guardar = controller.Guardar(entidad_lecturas) as OkObjectResult;
            if (guardar == null || guardar.StatusCode != 200) throw new Exception("Error al guardar Lecturas en API");
            entidad_lecturas = guardar.Value as Lecturas;

            var consultar = controller.Consultar() as OkObjectResult;
            if (consultar == null || consultar.StatusCode != 200) throw new Exception("Error al consultar Lecturas en API");

            entidad_lecturas!.Estado = false;
            var modificar = controller.Modificar(entidad_lecturas) as OkObjectResult;
            if (modificar == null || modificar.StatusCode != 200) throw new Exception("Error al modificar Lecturas en API");
        }

        // ═══════════════════════════════════════════════════════
        // FAVORITOS
        // ═══════════════════════════════════════════════════════
        private Favoritos? entidad_favoritos;
        private void Prueba_Favoritos()
        {
            var controller = new FavoritosController(new FavoritosNegocio(_context));

            entidad_favoritos = new Favoritos { FechaMarcado = DateTime.Now, Activo = true, UsuarioId = entidad_usuarios!.Id, LibroId = entidad_libros!.Id };

            var guardar = controller.Guardar(entidad_favoritos) as OkObjectResult;
            if (guardar == null || guardar.StatusCode != 200) throw new Exception("Error al guardar Favoritos en API");
            entidad_favoritos = guardar.Value as Favoritos;

            var consultar = controller.Consultar() as OkObjectResult;
            if (consultar == null || consultar.StatusCode != 200) throw new Exception("Error al consultar Favoritos en API");

            entidad_favoritos!.Activo = false;
            var modificar = controller.Modificar(entidad_favoritos) as OkObjectResult;
            if (modificar == null || modificar.StatusCode != 200) throw new Exception("Error al modificar Favoritos en API");

            var borrar = controller.Borrar(entidad_favoritos) as OkObjectResult;
            if (borrar == null || borrar.StatusCode != 200) throw new Exception("Error al borrar Favoritos en API");
        }

        // ═══════════════════════════════════════════════════════
        // RESENAS
        // ═══════════════════════════════════════════════════════
        private Resenas? entidad_resenas;
        private void Prueba_Resenas()
        {
            var controller = new ResenasController(new ResenasNegocio(_context));

            entidad_resenas = new Resenas { Calificacion = 4.5m, Comentario = "UT-API-Comentario", UsuarioId = entidad_usuarios!.Id, LibroId = entidad_libros!.Id };

            var guardar = controller.Guardar(entidad_resenas) as OkObjectResult;
            if (guardar == null || guardar.StatusCode != 200) throw new Exception("Error al guardar Resenas en API");
            entidad_resenas = guardar.Value as Resenas;

            var consultar = controller.Consultar() as OkObjectResult;
            if (consultar == null || consultar.StatusCode != 200) throw new Exception("Error al consultar Resenas en API");

            entidad_resenas!.Calificacion = 3.0m;
            var modificar = controller.Modificar(entidad_resenas) as OkObjectResult;
            if (modificar == null || modificar.StatusCode != 200) throw new Exception("Error al modificar Resenas en API");

            var borrar = controller.Borrar(entidad_resenas) as OkObjectResult;
            if (borrar == null || borrar.StatusCode != 200) throw new Exception("Error al borrar Resenas en API");
        }

        // ═══════════════════════════════════════════════════════
        // HISTORIALLECTURAS
        // ═══════════════════════════════════════════════════════
        private HistorialLecturas? entidad_historial;
        private void Prueba_HistorialLecturas()
        {
            var controller = new HistorialLecturasController(new HistorialLecturasNegocio(_context));

            entidad_historial = new HistorialLecturas { FechaInicio = DateTime.Now, FechaFin = DateTime.Now.AddDays(7) };

            var guardar = controller.Guardar(entidad_historial) as OkObjectResult;
            if (guardar == null || guardar.StatusCode != 200) throw new Exception("Error al guardar HistorialLecturas en API");
            entidad_historial = guardar.Value as HistorialLecturas;

            var consultar = controller.Consultar() as OkObjectResult;
            if (consultar == null || consultar.StatusCode != 200) throw new Exception("Error al consultar HistorialLecturas en API");

            entidad_historial!.FechaFin = DateTime.Now.AddDays(14);
            var modificar = controller.Modificar(entidad_historial) as OkObjectResult;
            if (modificar == null || modificar.StatusCode != 200) throw new Exception("Error al modificar HistorialLecturas en API");

            var borrar = controller.Borrar(entidad_historial) as OkObjectResult;
            if (borrar == null || borrar.StatusCode != 200) throw new Exception("Error al borrar HistorialLecturas en API");
        }

        // ═══════════════════════════════════════════════════════
        // PROGRESOLECTURAS
        // ═══════════════════════════════════════════════════════
        private ProgresoLecturas? entidad_progreso;
        private void Prueba_ProgresoLecturas()
        {
            var controller = new ProgresoLecturasController(new ProgresoLecturasNegocio(_context));

            entidad_progreso = new ProgresoLecturas { PaginasLeidas = 150, Porcentaje = 50, FechaActualizacion = DateTime.Now, LecturaId = entidad_lecturas!.Id };

            var guardar = controller.Guardar(entidad_progreso) as OkObjectResult;
            if (guardar == null || guardar.StatusCode != 200) throw new Exception("Error al guardar ProgresoLecturas en API");
            entidad_progreso = guardar.Value as ProgresoLecturas;

            var consultar = controller.Consultar() as OkObjectResult;
            if (consultar == null || consultar.StatusCode != 200) throw new Exception("Error al consultar ProgresoLecturas en API");

            entidad_progreso!.PaginasLeidas = 200;
            var modificar = controller.Modificar(entidad_progreso) as OkObjectResult;
            if (modificar == null || modificar.StatusCode != 200) throw new Exception("Error al modificar ProgresoLecturas en API");

            var borrar = controller.Borrar(entidad_progreso) as OkObjectResult;
            if (borrar == null || borrar.StatusCode != 200) throw new Exception("Error al borrar ProgresoLecturas en API");
        }
    }
}