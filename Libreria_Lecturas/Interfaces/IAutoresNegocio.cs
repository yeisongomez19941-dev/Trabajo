using Libreria_Lecturas.Entidades;

namespace Libreria_Lecturas.Interfaces
{
    public interface IAutoresNegocio
    {
        List<Autores> Consultar();
        Autores Guardar(Autores entidad);
        Autores Modificar(Autores entidad);
        bool Borrar(Autores entidad);
    }
}
