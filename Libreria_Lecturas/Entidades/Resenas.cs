using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Libreria_Lecturas.Entidades
{
    public class Resenas
    {
        public int Id { get; set; }
        public decimal Calificacion { get; set; }
        public string? Comentario { get; set; }
        public int? UsuarioId { get; set; }
        public int? LibroId { get; set; }


        [ForeignKey("UsuarioId")]
        public Usuarios? _UsuarioId { get; set; }

        [ForeignKey("LibroId")]
        public Libros? _LibroId { get; set; }

        public bool EsBuenaResena()
        {
            return Calificacion >= 4;
        }
    }

}
