using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;

IConexion conexion = new Conexion();


var lista_autores = conexion.Autores.ToList();
var lista_calendarioLecturas = conexion.CalendarioLecturas.ToList();
var lista_configuracionUsuarios = conexion.ConfiguracionUsuarios.ToList();
var lista_editoriales = conexion.Editoriales.ToList();
var lista_estadisticas = conexion.Estadisticas.ToList();
var lista_estadoLecturas = conexion.EstadoLecturas.ToList();
var lista_favoritos = conexion.Favoritos.ToList();
var lista_generos = conexion.Generos.ToList();
var lista_historialLecturas = conexion.HistorialLecturas.ToList();
var lista_lecturas = conexion.Lecturas.ToList();
var lista_libros = conexion.Libros.ToList();
var lista_logros = conexion.Logros.ToList();
var lista_metaLecturas = conexion.MetaLecturas.ToList();
var lista_notas = conexion.Notas.ToList();
var lista_notificaciones = conexion.Notificaciones.ToList();
var lista_progresoLecturas = conexion.ProgresoLecturas.ToList();
var lista_recomendaciones = conexion.Recomendaciones.ToList();
var lista_resenas = conexion.Resenas.ToList();
var lista_seccionLecturas = conexion.SeccionLecturas.ToList();
var lista_usuarios = conexion.Usuarios.ToList();

Console.WriteLine("Conexion exitosa!");
Console.WriteLine("Final");
