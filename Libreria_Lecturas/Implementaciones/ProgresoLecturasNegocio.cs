using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Lecturas.Implementaciones
{
    public class ProgresoLecturasNegocio : IProgresoLecturasNegocio
    {
        private readonly Conexion _context;

        public ProgresoLecturasNegocio(Conexion context)
        {
            _context = context;
        }

        public List<ProgresoLecturas> Consultar()
            => _context.ProgresoLecturas.ToList();

        public ProgresoLecturas Guardar(ProgresoLecturas entidad)
        {
            _context.ProgresoLecturas.Add(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public ProgresoLecturas Modificar(ProgresoLecturas entidad)
        {
            _context.ProgresoLecturas.Update(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public bool Borrar(ProgresoLecturas entidad)
        {
            _context.ProgresoLecturas.Remove(entidad);
            _context.SaveChanges();
            return true;
        }

    }

}
