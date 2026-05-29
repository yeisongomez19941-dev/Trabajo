using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
            => _context.Notas.ToList();

        public Notas Guardar(Notas entidad)
        {
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
