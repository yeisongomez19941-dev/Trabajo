using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Lecturas.Implementaciones
{

        public class EditorialesNegocio : IEditorialesNegocio
        {
            private readonly Conexion _context;
            private readonly IAuditoriasNegocio _auditorias;

        public EditorialesNegocio(Conexion context, IAuditoriasNegocio auditorias)
            {
                _context = context;
                _auditorias = auditorias;
            }

            public List<Editoriales> Consultar()
                => _context.Editoriales.ToList();

            public Editoriales Guardar(Editoriales entidad)
            {
                _context.Editoriales.Add(entidad);
                _context.SaveChanges();
                 _auditorias.Registrar("CalendarioLecturas", "Crear",
                "Sistema", $"CalendarioLecturas creado: {entidad.Id}");
            return entidad;
        }

            public Editoriales Modificar(Editoriales entidad)
            {
                _context.Editoriales.Update(entidad);
                _context.SaveChanges();
                _auditorias.Registrar("CalendarioLecturas", "Editar",
                "Sistema",$"CalendarioLecturas editado: {entidad.Id}");
            return entidad;
        }

        //Cuando no tenemos el campo usuario en la entidad se hace de esta manera
        public bool Borrar(Editoriales entidad)
        {
            _context.Editoriales.Remove(entidad);
            _context.SaveChanges();
            _auditorias.Registrar("Editoriales", "Eliminar",
                "Sistema",
                $"Editorial eliminada. Id: {entidad.Id} - {entidad.Nombre}");
            return true;
        }
    }
}
