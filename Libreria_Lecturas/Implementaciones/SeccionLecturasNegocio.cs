using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Lecturas.Implementaciones
{
    public class SeccionLecturasNegocio : ISeccionLecturasNegocio
    {
        private readonly Conexion _context;

        public SeccionLecturasNegocio(Conexion context)
        {
            _context = context;
        }

        public List<SeccionLecturas> Consultar()
            => _context.SeccionLecturas.ToList();

        public SeccionLecturas Guardar(SeccionLecturas entidad)
        {
            _context.SeccionLecturas.Add(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public SeccionLecturas Modificar(SeccionLecturas entidad)
        {
            _context.SeccionLecturas.Update(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public bool Borrar(SeccionLecturas entidad)
        {
            _context.SeccionLecturas.Remove(entidad);
            _context.SaveChanges();
            return true;
        }

    }
}
