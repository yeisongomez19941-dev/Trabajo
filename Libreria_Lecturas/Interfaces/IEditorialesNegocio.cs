using Libreria_Lecturas.Entidades;

namespace Libreria_Lecturas.Interfaces
{
    public interface IEditorialesNegocio
    {
        List<Editoriales> Consultar();
        Editoriales Guardar(Editoriales entidad);
        Editoriales Modificar(Editoriales entidad);
        bool Borrar(Editoriales entidad);
    }
}

