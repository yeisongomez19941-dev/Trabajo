using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Lecturas.Implementaciones
{
    public class HistorialLecturasNegocio : IHistorialLecturasNegocio
    {
        private readonly Conexion _context;

        public HistorialLecturasNegocio(Conexion context)
        {
            _context = context;
        }

        public List<HistorialLecturas> Consultar()
            => _context.HistorialLecturas.ToList();

        public HistorialLecturas Guardar(HistorialLecturas entidad)
        {
            _context.HistorialLecturas.Add(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public HistorialLecturas Modificar(HistorialLecturas entidad)
        {
            _context.HistorialLecturas.Update(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public bool Borrar(HistorialLecturas entidad)
        {
            _context.HistorialLecturas.Remove(entidad);
            _context.SaveChanges();
            return true;
        }

    }
}
