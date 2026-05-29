using Libreria_Lecturas.Entidades;

namespace Libreria_Lecturas.Interfaces
{
    public interface IMetaLecturasNegocio
    {
        List<MetaLecturas> Consultar();
        MetaLecturas Guardar(MetaLecturas entidad);
        MetaLecturas Modificar(MetaLecturas entidad);
        bool Borrar(MetaLecturas entidad);
    }
}

