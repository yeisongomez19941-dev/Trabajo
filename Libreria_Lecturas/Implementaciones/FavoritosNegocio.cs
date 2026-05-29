using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Lecturas.Implementaciones
{
    public class FavoritosNegocio : IFavoritosNegocio
    {
        private readonly Conexion _context;

        public FavoritosNegocio(Conexion context)
        {
            _context = context;
        }

        // El original 
        public List<Favoritos> Consultar()
            => _context.Favoritos.ToList();

        // El nuevo con filtro por usuario
        public List<Favoritos> Consultar(int usuarioId)
            => _context.Favoritos
                .Where(f => f.UsuarioId == usuarioId)
                .Include(f => f._LibroId)
                .ToList();

        public Favoritos Guardar(Favoritos entidad)
        {
            _context.Favoritos.Add(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public Favoritos Modificar(Favoritos entidad)
        {
            _context.Favoritos.Update(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public bool Borrar(Favoritos entidad)
        {
            _context.Favoritos.Remove(entidad);
            _context.SaveChanges();
            return true;
        }

    }
}
