using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Libreria_Lecturas.Implementaciones
{
    public class RecomendacionesNegocio : IRecomendacionesNegocio
    {
        private readonly Conexion _context;

        public RecomendacionesNegocio(Conexion context)
        {
            _context = context;
        }

        public List<Recomendaciones> Consultar()
            => _context.Recomendaciones.ToList();

        public Recomendaciones Guardar(Recomendaciones entidad)
        {
            _context.Recomendaciones.Add(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public Recomendaciones Modificar(Recomendaciones entidad)
        {
            _context.Recomendaciones.Update(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public bool Borrar(Recomendaciones entidad)
        {
            _context.Recomendaciones.Remove(entidad);
            _context.SaveChanges();
            return true;
        }

        public List<Recomendaciones> GenerarRecomendaciones(int usuarioId)
        {
            // Libros que ya leyó el usuario
            var librosLeidos = _context.HistorialLecturas
                .Where(h => h.UsuarioId == usuarioId)
                .Select(h => h.LibroId)
                .ToList();

            // Géneros de esos libros
            var generosLeidos = _context.Libros
                .Where(l => librosLeidos.Contains(l.Id))
                .Select(l => new { l.Id, l.GeneroId, l.Titulo })
                .ToList();

            var recomendaciones = new List<Recomendaciones>();

            foreach (var libroLeido in generosLeidos)
            {
                // Buscar libros del mismo género que no haya leído
                var libroSugerido = _context.Libros
                    .Where(l => l.GeneroId == libroLeido.GeneroId
                                && !librosLeidos.Contains(l.Id))
                    .OrderBy(l => Guid.NewGuid()) // al azar
                    .FirstOrDefault();

                if (libroSugerido != null)
                {
                    recomendaciones.Add(new Recomendaciones
                    {
                        LibroId = libroSugerido.Id,
                        UsuarioId = usuarioId,
                        Motivo = $"Como leíste '{libroLeido.Titulo}' te puede gustar este libro",
                        Fecha = DateTime.Now,
                        _LibroId = libroSugerido
                    });
                }
            }

            return recomendaciones;
        }
    }
}