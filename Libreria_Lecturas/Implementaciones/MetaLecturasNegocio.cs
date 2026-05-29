using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Lecturas.Implementaciones
{
    public class MetaLecturasNegocio : IMetaLecturasNegocio
    {
        private readonly Conexion _context;

        public MetaLecturasNegocio(Conexion context)
        {
            _context = context;
        }

        public List<MetaLecturas> Consultar()
            => _context.MetaLecturas.ToList();

        public MetaLecturas Guardar(MetaLecturas entidad)
        {
            _context.MetaLecturas.Add(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public MetaLecturas Modificar(MetaLecturas entidad)
        {
            _context.MetaLecturas.Update(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public bool Borrar(MetaLecturas entidad)
        {
            _context.MetaLecturas.Remove(entidad);
            _context.SaveChanges();
            return true;
        }

    }
}
