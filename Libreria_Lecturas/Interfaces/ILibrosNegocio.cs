using Libreria_Lecturas.Entidades;

namespace Libreria_Lecturas.Interfaces
{
    public interface ILibrosNegocio
    {
        List<Libros> Consultar();
        Libros Guardar(Libros entidad);
        Libros Modificar(Libros entidad);
        bool Borrar(Libros entidad);
    }
}

