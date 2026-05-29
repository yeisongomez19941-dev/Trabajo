using Libreria_Lecturas.Entidades;

namespace Libreria_Lecturas.Interfaces
{
    public interface IConfiguracionUsuariosNegocio
    {
        List<ConfiguracionUsuarios> Consultar();
        ConfiguracionUsuarios Guardar(ConfiguracionUsuarios entidad);
        ConfiguracionUsuarios Modificar(ConfiguracionUsuarios entidad);
        bool Borrar(ConfiguracionUsuarios entidad);
    }
}

