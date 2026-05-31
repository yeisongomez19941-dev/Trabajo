using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria_Lecturas.Entidades
{
    public class Notas
    {
        public int Id { get; set; }
        public int Pagina { get; set; }
        public string? Contenido { get; set; }
        public DateTime? Fecha { get; set; }
        public int? UsuarioId { get; set; }
        public int? LibroId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuarios? _UsuarioId { get; set; }

        [ForeignKey("LibroId")]
        public Libros? _LibroId { get; set; }
    }
}