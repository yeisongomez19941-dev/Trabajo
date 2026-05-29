using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Libreria_Lecturas.Entidades
{
    public class Favoritos
    {
        public int Id { get; set; }
        public DateTime FechaMarcado { get; set; }
        public bool? Activo { get; set; }
        public int? UsuarioId { get; set; }
        public int? LibroId { get; set; }


        [ForeignKey("UsuarioId")]
        public Usuarios? _UsuarioId { get; set; }

        [ForeignKey("LibroId")]
        public Libros? _LibroId { get; set; }
    }
}
