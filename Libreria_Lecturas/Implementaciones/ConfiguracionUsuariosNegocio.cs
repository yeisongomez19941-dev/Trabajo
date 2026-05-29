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
        private readonly IAuditoriasNegocio _auditorias;
        public ConfiguracionUsuariosNegocio(Conexion context, IAuditoriasNegocio auditorias)
        {
            _context = context;
            _auditorias = auditorias;
        }

        public List<ConfiguracionUsuarios> Consultar()
            => _context.ConfiguracionUsuarios.ToList();

        public ConfiguracionUsuarios Guardar(ConfiguracionUsuarios entidad)
        {
            _context.ConfiguracionUsuarios.Add(entidad);
            _context.SaveChanges();
            _auditorias.Registrar("ConfiguracionUsuarios", "Crear",
               "Sistema",
               $"ConfiguracionUsuarios creado: {entidad.Id}");
            return entidad;
        }

        public ConfiguracionUsuarios Modificar(ConfiguracionUsuarios entidad)
        {
            _context.ConfiguracionUsuarios.Update(entidad);
            _context.SaveChanges();
            _auditorias.Registrar("ConfiguracionUsuarios", "Editar",
               "Sistema",$"ConfiguracionUsuarios editado: {entidad.Id}");
            return entidad;
        }

        public bool Borrar(ConfiguracionUsuarios entidad)
        {
            _context.ConfiguracionUsuarios.Remove(entidad);
            _context.SaveChanges();
            _auditorias.Registrar("ConfiguracionUsuarios", "Eliminar",
               entidad._UsuarioId?.Email ?? "Sistema",
               $"ConfiguracionUsuarios eliminado. Id: {entidad.Id}");
            return true;
        }
    }
}