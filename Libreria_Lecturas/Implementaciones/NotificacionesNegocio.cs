using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Lecturas.Implementaciones
{
    public class NotificacionesNegocio : INotificacionesNegocio
    {
        private readonly Conexion _context;

        public NotificacionesNegocio(Conexion context)
        {
            _context = context;
        }

        public List<Notificaciones> Consultar()
            => _context.Notificaciones.ToList();

        public Notificaciones Guardar(Notificaciones entidad)
        {
            _context.Notificaciones.Add(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public Notificaciones Modificar(Notificaciones entidad)
        {
            _context.Notificaciones.Update(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public bool Borrar(Notificaciones entidad)
        {
            _context.Notificaciones.Remove(entidad);
            _context.SaveChanges();
            return true;
        }

    }
}
