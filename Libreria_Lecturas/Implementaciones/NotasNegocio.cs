using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Libreria_Lecturas.Implementaciones
{
    public class NotasNegocio : INotasNegocio
    {
        private readonly Conexion _context;

        public NotasNegocio(Conexion context)
        {
            _context = context;
        }

        public List<Notas> Consultar()
            => _context.Notas.Include(n => n._LibroId).ToList();

        public List<Notas> Consultar(int usuarioId)
            => _context.Notas
                .Include(n => n._LibroId)
                .Where(n => n.UsuarioId == usuarioId)
                .OrderByDescending(n => n.Fecha)
                .ToList();

        public Notas Guardar(Notas entidad)
        {
            entidad.Fecha = DateTime.Now;
            _context.Notas.Add(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public Notas Modificar(Notas entidad)
        {
            _context.Notas.Update(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public bool Borrar(Notas entidad)
        {
            _context.Notas.Remove(entidad);
            _context.SaveChanges();
            return true;
        }
    }
}