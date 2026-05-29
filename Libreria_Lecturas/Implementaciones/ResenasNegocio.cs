using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Lecturas.Implementaciones
{
    public class ResenasNegocio : IResenasNegocio
    {
        private readonly Conexion _context;

        public ResenasNegocio(Conexion context)
        {
            _context = context;
        }

        public List<Resenas> Consultar()
        => _context.Resenas
        .Include(r => r._LibroId)
        .Include(r => r._UsuarioId)
        .ToList();

        public Resenas Guardar(Resenas entidad)
        {
            _context.Resenas.Add(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public Resenas Modificar(Resenas entidad)
        {
            _context.Resenas.Update(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public bool Borrar(Resenas entidad)
        {
            _context.Resenas.Remove(entidad);
            _context.SaveChanges();
            return true;
        }

    }
}
