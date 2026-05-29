using Libreria_Lecturas.Entidades;

namespace Libreria_Lecturas.Interfaces
{
    public interface IProgresoLecturasNegocio
    {
        List<ProgresoLecturas> Consultar();
        ProgresoLecturas Guardar(ProgresoLecturas entidad);
        ProgresoLecturas Modificar(ProgresoLecturas entidad);
        bool Borrar(ProgresoLecturas entidad);
    }
}
