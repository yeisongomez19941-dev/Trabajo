using Libreria_Lecturas.Entidades;

namespace Libreria_Lecturas.Interfaces
{
    public interface INotasNegocio
    {
        List<Notas> Consultar();
        List<Notas> Consultar(int usuarioId);
        Notas Guardar(Notas entidad);
        Notas Modificar(Notas entidad);
        bool Borrar(Notas entidad);
    }
}