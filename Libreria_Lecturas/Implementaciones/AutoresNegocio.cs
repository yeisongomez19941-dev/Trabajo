using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;

namespace Libreria_Lecturas.Implementaciones
{
    public class AutoresNegocio : IAutoresNegocio
    {
        private readonly Conexion _context;
        private readonly IAuditoriasNegocio _auditorias;

        public AutoresNegocio(Conexion context, IAuditoriasNegocio auditorias)
        {
            _context = context;
            _auditorias = auditorias;
        }

        public List<Autores> Consultar()
            => _context.Autores.ToList();

        public Autores Guardar(Autores entidad)
        {
            _context.Autores.Add(entidad);
            _context.SaveChanges();
            _auditorias.Registrar("Autores", "Crear",
                "Sistema",
                $"Autor creado: {entidad.Nombre}");
            return entidad;
        }

        public Autores Modificar(Autores entidad)
        {
            _context.Autores.Update(entidad);
            _context.SaveChanges();
            _auditorias.Registrar("Autores", "Modificar",
                "Sistema",
                $"Autor modificado. Id: {entidad.Id} - {entidad.Nombre}");
            return entidad;
        }

        public bool Borrar(Autores entidad)
        {
            _context.Autores.Remove(entidad);
            _context.SaveChanges();
            _auditorias.Registrar("Autores", "Eliminar",
                "Sistema",
                $"Autor eliminado. Id: {entidad.Id} - {entidad.Nombre}");
            return true;
        }
    }
}