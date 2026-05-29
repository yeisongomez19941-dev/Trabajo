using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Lecturas.Entidades
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int LibrosLeidos { get; set; }
        public int PaginasLeidas { get; set; }

        public List<Lecturas>? _Lecturas { get; set; }
        public List<Favoritos>? _Favoritos { get; set; }
        public List<Resenas>? _Resenas { get; set; }
        public List<Notificaciones>? _Notificaciones { get; set; }
        public List<MetaLecturas>? _MetaLecturas { get; set; }
        public List<ConfiguracionUsuarios>? _ConfiguracionUsuarios { get; set; }

        public string TipoLector()
        {
            if (LibrosLeidos >= 20) return "Lector bueno";
            else if (LibrosLeidos >= 10) return "Lector intermedio";
            else if (LibrosLeidos >= 1) return "Lector principiante";
            else return "Lector nuevo";
        }
    }
}
