using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Lecturas.Implementaciones
{
    public class EstadoLecturasNegocio : IEstadoLecturasNegocio
    {
        private readonly Conexion _context;

        public EstadoLecturasNegocio(Conexion context)
        {
            _context = context;
        }

        public List<EstadoLecturas> Consultar()
            => _context.EstadoLecturas.ToList();

        public EstadoLecturas Guardar(EstadoLecturas entidad)
        {
            _context.EstadoLecturas.Add(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public EstadoLecturas Modificar(EstadoLecturas entidad)
        {
            _context.EstadoLecturas.Update(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public bool Borrar(EstadoLecturas entidad)
        {
            _context.EstadoLecturas.Remove(entidad);
            _context.SaveChanges();
            return true;
        }

    }

}
