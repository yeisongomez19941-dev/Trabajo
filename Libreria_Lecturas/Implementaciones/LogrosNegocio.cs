using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Lecturas.Implementaciones
{
    public class LogrosNegocio : ILogrosNegocio
    {
        private readonly Conexion _context;

        public LogrosNegocio(Conexion context)
        {
            _context = context;
        }

        public List<Logros> Consultar()
            => _context.Logros.ToList();

        //consultar por id
        public List<Logros> Consultar(int usuarioId)
            => _context.Logros
                .Where(f => f.UsuarioId == usuarioId)
                .ToList();

        public Logros Guardar(Logros entidad)
        {
            _context.Logros.Add(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public Logros Modificar(Logros entidad)
        {
            _context.Logros.Update(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public bool Borrar(Logros entidad)
        {
            _context.Logros.Remove(entidad);
            _context.SaveChanges();
            return true;
        }

    }
}
