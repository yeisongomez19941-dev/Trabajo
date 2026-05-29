using Libreria_Lecturas.Entidades;

namespace Libreria_Lecturas.Interfaces
{
    public interface IGenerosNegocio
    {
        List<Generos> Consultar();
        Generos Guardar(Generos entidad);
        Generos Modificar(Generos entidad);
        bool Borrar(Generos entidad);
    }
}

