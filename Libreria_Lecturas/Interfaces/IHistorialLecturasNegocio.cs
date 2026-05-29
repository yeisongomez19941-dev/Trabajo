using Libreria_Lecturas.Entidades;

namespace Libreria_Lecturas.Interfaces
{
    public interface IHistorialLecturasNegocio
    {
        List<HistorialLecturas> Consultar();
        HistorialLecturas Guardar(HistorialLecturas entidad);
        HistorialLecturas Modificar(HistorialLecturas entidad);
        bool Borrar(HistorialLecturas entidad);
    }
}

