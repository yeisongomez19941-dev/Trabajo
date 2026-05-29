using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;

namespace Libreria_Lecturas.Implementaciones
{
    public class CalendarioLecturasNegocio : ICalendarioLecturasNegocio
    {
        private readonly Conexion _context;
        private readonly IAuditoriasNegocio _auditorias;

        public CalendarioLecturasNegocio(Conexion context, IAuditoriasNegocio auditorias)
        {
            _context = context;
            _auditorias = auditorias;
        }

        public List<CalendarioLecturas> Consultar()
            => _context.CalendarioLecturas.ToList();
        public List<CalendarioLecturas> Consultar(int usuarioId)
         => _context.CalendarioLecturas
        .Where(c => c.UsuarioId == usuarioId)
        .ToList();

        public CalendarioLecturas Guardar(CalendarioLecturas entidad)
        {
            _context.CalendarioLecturas.Add(entidad);
            _context.SaveChanges();
            _auditorias.Registrar("CalendarioLecturas", "Crear",
               "Sistema",
               $"CalendarioLecturas creado: {entidad.Id}");
            return entidad;
        }
        
        public CalendarioLecturas Modificar(CalendarioLecturas entidad)
        {
            _context.CalendarioLecturas.Update(entidad);
            _context.SaveChanges();
            _auditorias.Registrar("CalendarioLecturas", "Crear",
            "Sistema",
            $"CalendarioLecturas creado: {entidad.Id}");
            return entidad;
        }

        public bool Borrar(CalendarioLecturas entidad)
        {
            _context.CalendarioLecturas.Remove(entidad);
            _context.SaveChanges();
            _auditorias.Registrar("CalendarioLecturas", "Eliminar",
                entidad._UsuarioId?.Email ?? "Sistema",
                $"Calendario eliminado. Id: {entidad.Id} - Fecha: {entidad.Fecha:dd/MM/yyyy}");
            return true;
        }
    }
}