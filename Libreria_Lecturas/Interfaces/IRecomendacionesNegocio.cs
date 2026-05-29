using Libreria_Lecturas.Entidades;

namespace Libreria_Lecturas.Interfaces
{
    public interface IRecomendacionesNegocio
    {
        List<Recomendaciones> Consultar();
        Recomendaciones Guardar(Recomendaciones entidad);
        Recomendaciones Modificar(Recomendaciones entidad);
        bool Borrar(Recomendaciones entidad);
        List<Recomendaciones> GenerarRecomendaciones(int usuarioId); // para que un usuario pueda generar recomendaciones

    }
}
