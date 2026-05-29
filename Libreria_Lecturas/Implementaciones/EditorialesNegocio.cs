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

            public EditorialesNegocio(Conexion context)
            {
                _context = context;
            }

            public List<Editoriales> Consultar()
                => _context.Editoriales.ToList();

            public Editoriales Guardar(Editoriales entidad)
            {
                _context.Editoriales.Add(entidad);
                _context.SaveChanges();
                return entidad;
            }

            public Editoriales Modificar(Editoriales entidad)
            {
                _context.Editoriales.Update(entidad);
                _context.SaveChanges();
                return entidad;
            }

            public bool Borrar(Editoriales entidad)
            {
                _context.Editoriales.Remove(entidad);
                _context.SaveChanges();
                return true;
            }
        }
}
