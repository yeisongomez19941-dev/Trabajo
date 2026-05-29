using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria_Lecturas.Entidades
{
    public class Recomendaciones
    {
        public int Id { get; set; }
        public string? Motivo { get; set; }
        public DateTime? Fecha { get; set; }
        public int? LibroId { get; set; }
        public int? UsuarioId { get; set; }

        [ForeignKey("LibroId")]
        public Libros? _LibroId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuarios? _UsuarioId { get; set; }
    
    }
}
