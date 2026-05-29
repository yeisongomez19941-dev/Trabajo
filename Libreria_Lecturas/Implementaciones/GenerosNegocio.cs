using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Lecturas.Implementaciones
{
    public class GenerosNegocio : IGenerosNegocio
    {
        private readonly Conexion _context;

        public GenerosNegocio(Conexion context)
        {
            _context = context;
        }

        public List<Generos> Consultar()
            => _context.Generos.ToList();

        public Generos Guardar(Generos entidad)
        {
            _context.Generos.Add(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public Generos Modificar(Generos entidad)
        {
            _context.Generos.Update(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public bool Borrar(Generos entidad)
        {
            _context.Generos.Remove(entidad);
            _context.SaveChanges();
            return true;
        }

    }
}
