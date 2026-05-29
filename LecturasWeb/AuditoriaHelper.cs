using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;

namespace LecturasWeb
{
    public static class AuditoriaHelper
    {
        public static void Registrar(Conexion context, string tabla, string accion, string usuarioEmail, string detalle)
        {
            context.Auditorias.Add(new Auditorias
            {
                Tabla = tabla,
                Accion = accion,
                UsuarioEmail = usuarioEmail,
                Fecha = DateTime.UtcNow,
                Detalle = detalle
            });
            context.SaveChanges();
        }
    }
}