using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Lecturas.Implementaciones
{
    public class EstadisticasNegocio : IEstadisticasNegocio
    {
        private readonly Conexion _context;

        public EstadisticasNegocio(Conexion context)
        {
            _context = context;
        }

        public List<Estadisticas> Consultar()
            => _context.Estadisticas.ToList();
        //consultar por id
        public List<Estadisticas> Consultar(int usuarioId)
            => _context.Estadisticas
                .Where(f => f.UsuarioId == usuarioId)
                .ToList();

        public Estadisticas Guardar(Estadisticas entidad)
        {
            _context.Estadisticas.Add(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public Estadisticas Modificar(Estadisticas entidad)
        {
            _context.Estadisticas.Update(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public bool Borrar(Estadisticas entidad)
        {
            _context.Estadisticas.Remove(entidad);
            _context.SaveChanges();
            return true;
        }
    
    }
}
