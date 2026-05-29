using Libreria_Lecturas.Entidades;

namespace Libreria_Lecturas.Interfaces
{
    public interface IEstadisticasNegocio
    {
        List<Estadisticas> Consultar();
        List<Estadisticas> Consultar(int UsuarioId);
        Estadisticas Guardar(Estadisticas entidad);
        Estadisticas Modificar(Estadisticas entidad);
        bool Borrar(Estadisticas entidad);
    }
}

