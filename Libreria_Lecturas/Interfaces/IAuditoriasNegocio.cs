using Libreria_Lecturas.Entidades;

namespace Libreria_Lecturas.Interfaces
{
    public interface IAuditoriasNegocio
    {
        void Registrar(string tabla, string accion, string usuarioEmail, string detalle);
        List<Auditorias> Consultar();
    }
}