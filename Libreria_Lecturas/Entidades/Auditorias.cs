using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Lecturas.Entidades
{
        public class Auditorias
        {
            public int Id { get; set; }
            public string? Tabla { get; set; }        // Qué entidad se modificó (Libros, Autores...)
            public string? Accion { get; set; }       // Crear, Modificar, Eliminar
            public string? UsuarioEmail { get; set; } // Quién lo hizo
            public DateTime Fecha { get; set; }       // Cuándo lo hizo
            public string? Detalle { get; set; }      // Qué cambio")
        }
}
