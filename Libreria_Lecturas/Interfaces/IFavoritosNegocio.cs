using Libreria_Lecturas.Entidades;

namespace Libreria_Lecturas.Interfaces
{
    public interface IFavoritosNegocio
    {
        List<Favoritos> Consultar();
        List<Favoritos> Consultar(int usuarioId); // Cambio realizado para que consulte por usuarioId, osea muestre los favoritos de un usuario en específico
        Favoritos Guardar(Favoritos entidad);
        Favoritos Modificar(Favoritos entidad);
        bool Borrar(Favoritos entidad);
    }
}

