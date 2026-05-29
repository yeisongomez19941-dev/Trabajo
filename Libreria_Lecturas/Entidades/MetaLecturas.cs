using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Libreria_Lecturas.Entidades
{
    public class MetaLecturas
    {
        public int Id { get; set; }
        public int Ano { get; set; }
        public decimal CantidadObjetivo { get; set; }
        public int LibrosCompletos { get; set; }
        public int? UsuarioId { get; set; }


        [ForeignKey("UsuarioId")]
        public Usuarios? _UsuarioId { get; set; }

        public bool MetaCumplida()
        {
            return LibrosCompletos >= CantidadObjetivo;
        }
    }
}
