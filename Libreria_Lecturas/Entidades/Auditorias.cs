using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Lecturas.Entidades
{
    namespace Libreria_Lecturas.Entidades
    {
        public class Auditoria
        {
            public int Id { get; set; }
            public string? Tabla { get; set; }        // Ej: "Libros", "Autores", "Usuarios"
            public string? Accion { get; set; }       // "Crear", "Modificar", "Eliminar"
            public string? UsuarioEmail { get; set; } // Quién hizo la acción
            public DateTime Fecha { get; set; }       // Cuándo
            public string? Detalle { get; set; }      // Ej: "Libro creado: El Principito"
        }
    }
}