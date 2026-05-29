using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Lecturas.Implementaciones
{
    public class ConfiguracionUsuariosNegocio : IConfiguracionUsuariosNegocio
    {
        private readonly Conexion _context;

        public ConfiguracionUsuariosNegocio(Conexion context)
        {
            _context = context;
        }

        public List<ConfiguracionUsuarios> Consultar()
            => _context.ConfiguracionUsuarios.ToList();

        public ConfiguracionUsuarios Guardar(ConfiguracionUsuarios entidad)
        {
            _context.ConfiguracionUsuarios.Add(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public ConfiguracionUsuarios Modificar(ConfiguracionUsuarios entidad)
        {
            _context.ConfiguracionUsuarios.Update(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public bool Borrar(ConfiguracionUsuarios entidad)
        {
            _context.ConfiguracionUsuarios.Remove(entidad);
            _context.SaveChanges();
            return true;
        }
    }
}