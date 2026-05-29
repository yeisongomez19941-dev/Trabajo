using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Libreria_Lecturas.Entidades
{
    public class ConfiguracionUsuarios
    {
        public int Id { get; set; }
        public bool? NotificacionesActivas { get; set; }
        public bool? TemaOscuro { get; set; }
        public int? UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuarios? _UsuarioId { get; set; }
    }
}
