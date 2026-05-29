using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria_Lecturas.Entidades
{
    public class CalendarioLecturas
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public int PaginasLeidas { get; set; }
        public decimal TiempoMinutos { get; set; }
        public int? UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuarios? _UsuarioId { get; set; }
    }
}
