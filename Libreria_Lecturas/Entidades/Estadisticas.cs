
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria_Lecturas.Entidades
{
    public class Estadisticas
    {
        public int Id { get; set; }
        public int LibrosLeidos { get; set; }
        public int PaginasTotales { get; set; }
        public decimal PromedioPaginas { get; set; }
        public int? UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuarios? _UsuarioId { get; set; }
    }
}
