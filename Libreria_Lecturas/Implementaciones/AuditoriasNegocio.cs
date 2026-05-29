using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;



namespace Libreria_Lecturas.Implementaciones
{
    public class AuditoriasNegocio : IAuditoriasNegocio
    {
        private readonly Conexion _context;

        public AuditoriasNegocio(Conexion context)
        {
            _context = context;
        }

        public void Registrar(string tabla, string accion, string usuarioEmail, string detalle)
        {
            var auditoria = new Auditorias
            {
                Tabla = tabla,
                Accion = accion,
                UsuarioEmail = usuarioEmail,
                Fecha = DateTime.Now,
                Detalle = detalle
            };

            _context.Auditorias.Add(auditoria);
            _context.SaveChanges();
        }

        public List<Auditorias> Consultar()
            => _context.Auditorias.OrderByDescending(a => a.Fecha).ToList();
    }
}