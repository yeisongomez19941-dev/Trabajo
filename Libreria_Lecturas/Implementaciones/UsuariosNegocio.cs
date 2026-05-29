using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Lecturas.Implementaciones
{
    public class UsuariosNegocio : IUsuariosNegocio
    {
        private readonly Conexion _context;

        public UsuariosNegocio(Conexion context)
        {
            _context = context;
        }

        public List<Usuarios> Consultar()
            => _context.Usuarios.ToList();

        public Usuarios Guardar(Usuarios entidad)
        {
            _context.Usuarios.Add(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public Usuarios Modificar(Usuarios entidad)
        {
            _context.Usuarios.Update(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public bool Borrar(Usuarios entidad)
        {
            _context.Usuarios.Remove(entidad);
            _context.SaveChanges();
            return true;
        }

    }
}
