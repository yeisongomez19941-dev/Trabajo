using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;

namespace Libreria_Lecturas.Implementaciones
{
    public class CalendarioLecturasNegocio : ICalendarioLecturasNegocio
    {
        private readonly Conexion _context;
    

        public CalendarioLecturasNegocio(Conexion context)
        {
            _context = context;
          
        }

        public List<CalendarioLecturas> Consultar()
            => _context.CalendarioLecturas.ToList();
        public List<CalendarioLecturas> Consultar(int usuarioId)
         => _context.CalendarioLecturas.Where(c => c.UsuarioId == usuarioId).ToList();

        public CalendarioLecturas Guardar(CalendarioLecturas entidad)
        {
            _context.CalendarioLecturas.Add(entidad);
            _context.SaveChanges();
       
            return entidad;
        }
        
        public CalendarioLecturas Modificar(CalendarioLecturas entidad)
        {
            _context.CalendarioLecturas.Update(entidad);
            _context.SaveChanges();
     
            return entidad;
        }

        public bool Borrar(CalendarioLecturas entidad)
        {
            _context.CalendarioLecturas.Remove(entidad);
            _context.SaveChanges();
          
            return true;
        }
    }
}