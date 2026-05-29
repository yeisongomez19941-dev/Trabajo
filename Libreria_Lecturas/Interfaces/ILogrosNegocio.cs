using Libreria_Lecturas.Entidades;

namespace Libreria_Lecturas.Interfaces
{
    public interface ILogrosNegocio
    {
        List<Logros> Consultar();
        List<Logros> Consultar(int UsuarioId);
        Logros Guardar(Logros entidad);
        Logros Modificar(Logros entidad);
        bool Borrar(Logros entidad);
    }
}

