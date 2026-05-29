using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria_Lecturas.Entidades
{
    public class HistorialLecturas
    {
        public int Id { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? UsuarioId { get; set; }
        public int? LibroId { get; set; }
        public int? PaginasLeidas { get; set; }

        //se hace con el fin de poder generar estadisticas automaticamente a cada usuario

        [ForeignKey("UsuarioId")]
        public Usuarios? _UsuarioId { get; set; }

        [ForeignKey("LibroId")]
        public Libros? _LibroId { get; set; }
    }
}
