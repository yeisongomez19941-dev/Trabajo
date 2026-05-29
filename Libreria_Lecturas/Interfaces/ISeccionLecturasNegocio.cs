using Libreria_Lecturas.Entidades;

namespace Libreria_Lecturas.Interfaces
{
    public interface ISeccionLecturasNegocio
    {
        List<SeccionLecturas> Consultar();
        SeccionLecturas Guardar(SeccionLecturas entidad);
        SeccionLecturas Modificar(SeccionLecturas entidad);
        bool Borrar(SeccionLecturas entidad);
    }
}
