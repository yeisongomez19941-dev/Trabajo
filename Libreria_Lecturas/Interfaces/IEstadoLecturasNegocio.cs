using Libreria_Lecturas.Entidades;

namespace Libreria_Lecturas.Interfaces
{
    public interface IEstadoLecturasNegocio
    {
        List<EstadoLecturas> Consultar();
        EstadoLecturas Guardar(EstadoLecturas entidad);
        EstadoLecturas Modificar(EstadoLecturas entidad);
        bool Borrar(EstadoLecturas entidad);
    }
}

