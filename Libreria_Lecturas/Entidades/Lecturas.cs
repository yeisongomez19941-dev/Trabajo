using System.ComponentModel.DataAnnotations.Schema;


namespace Libreria_Lecturas.Entidades
{
    public class Lecturas
    {
        public int Id { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public bool Estado { get; set; }
        public int? UsuarioId { get; set; }
        public int? LibroId { get; set; }


        [ForeignKey("UsuarioId")]
        public Usuarios? _UsuarioId { get; set; }

        [ForeignKey("LibroId")]
        public Libros? _LibroId { get; set; }

        public List<ProgresoLecturas>? _ProgresoLecturas { get; set; }
    }
}
