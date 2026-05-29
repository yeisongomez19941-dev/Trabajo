using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;




namespace Libreria_Lecturas.Implementaciones
{
    public class AutoresNegocio : IAutoresNegocio
    {
        private readonly Conexion _context;

        public AutoresNegocio(Conexion context)
        {
            _context = context;
        }

        public List<Autores> Consultar()
        {
            return _context.Autores.ToList();
        }

        public Autores Guardar(Autores entidad)
        {
            _context.Autores.Add(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public Autores Modificar(Autores entidad)
        {
            _context.Autores.Update(entidad);
            _context.SaveChanges();
            return entidad;
        }

        public bool Borrar(Autores entidad)
        {
            _context.Autores.Remove(entidad);
            _context.SaveChanges();
            return true;
        }
    }
}