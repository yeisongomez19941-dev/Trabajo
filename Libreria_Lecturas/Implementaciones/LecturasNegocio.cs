using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Lecturas.Implementaciones
{
    public class LecturasNegocio : ILecturasNegocio
    {
        private readonly Conexion _context;

        public LecturasNegocio(Conexion context)
        {
            _context = context;
        }

        public List<Lecturas> Consultar()
            => _context.Lecturas.ToList();

        public Lecturas Guardar(Lecturas entidad)
        {
            _context.Lecturas.Add(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public Lecturas Modificar(Lecturas entidad)
        {
            _context.Lecturas.Update(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public bool Borrar(Lecturas entidad)
        {
            _context.Lecturas.Remove(entidad);
            _context.SaveChanges();
            return true;
        }

    }
}
