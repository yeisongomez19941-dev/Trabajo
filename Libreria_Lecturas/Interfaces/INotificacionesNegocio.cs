using Libreria_Lecturas.Entidades;

namespace Libreria_Lecturas.Interfaces
{
    public interface INotificacionesNegocio
    {
        List<Notificaciones> Consultar();
        Notificaciones Guardar(Notificaciones entidad);
        Notificaciones Modificar(Notificaciones entidad);
        bool Borrar(Notificaciones entidad);
    }
}
