using Libreria_Lecturas.Entidades;

namespace Libreria_Lecturas.Interfaces
{
    public interface IResenasNegocio
    {
        List<Resenas> Consultar();
        Resenas Guardar(Resenas entidad);
        Resenas Modificar(Resenas entidad);
        bool Borrar(Resenas entidad);
    }
}
