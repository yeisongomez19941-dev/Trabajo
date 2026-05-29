using Libreria_Lecturas.Entidades;

namespace Libreria_Lecturas.Interfaces
{
    public interface ILecturasNegocio
    {
        List<Lecturas> Consultar();
        Lecturas Guardar(Lecturas entidad);
        Lecturas Modificar(Lecturas entidad);
        bool Borrar(Lecturas entidad);
    }
}

