using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Lecturas.Implementaciones
{
    public class LibrosNegocio : ILibrosNegocio
    {
        private readonly Conexion _context;

        public LibrosNegocio(Conexion context)
        {
            _context = context;
        }

        public List<Libros> Consultar()
            => _context.Libros.ToList();

        public Libros Guardar(Libros entidad)
        {
            _context.Libros.Add(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public Libros Modificar(Libros entidad)
        {
            _context.Libros.Update(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public bool Borrar(Libros entidad)
        {
            _context.Libros.Remove(entidad);
            _context.SaveChanges();
            return true;
        }

    }
}
